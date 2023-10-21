using System;
using System.Collections.Generic;
using Game.Engine.Interactions;
using Game.Engine.Skills;

namespace Game.Engine
{
    [Serializable]
    class MetaMapMatrix
    {
        // world parameters
        private const int maps = 5; // how many maps in total in the game world // must be minimum 2 
        private const int minPortals = 6; // number of portals
        private const int shops = 3; // number of shops in the game world
        private const int interactions = 8; // approximate number of all interactions (including shops) in the game world (not strictly guaranteed due to quest constraints)
        private const int monsters = 6; // monsters per single map
        private const int walls = 20; // approximate number of walls per single map (not strictly guaranteed due to movement constraints)
        
       
        private GameSession parentSession;
        private List<Interaction> interactionList;
        public List<Interaction> QuestElements { get; private set; } // shared between all maps
        // connections between maps
        private int[,] adjacencyMatrix = new int[maps, maps]; // a graph containing individual boards and connections between them
        private int[] visited; 
        private int lastNumber;
        private int currentNumber; 
        // maps
        private MapMatrix[] matrix; // an array containing all boards in the game

        public MetaMapMatrix(GameSession parent)
        {
            parentSession = parent;
            // create adjacency matrix
            Random rng = new Random();
            for (int i = 0; i < minPortals; i++)
            {
                int a = rng.Next(maps);
                int b = rng.Next(maps);
                if (a == b || adjacencyMatrix[a, b] == 1) { i--; continue; }
                adjacencyMatrix[a, b] = 1;
                adjacencyMatrix[b, a] = 1;
            }
            while (!CheckConnectivity())
            {
                int a = rng.Next(maps);
                int b = rng.Next(maps);
                if (a == b || adjacencyMatrix[a, b] == 1) continue;
                adjacencyMatrix[a, b] = 1;
                adjacencyMatrix[b, a] = 1;
            }
            // generate interactions
            GenerateInteractions();
            // create maps
            matrix = new MapMatrix[maps];
            int totalIntNumber = interactionList.Count;
            for (int i = 0; i < maps; i++)
            {
                List<Interaction> tmp;
                if (i == maps - 1)  tmp = interactionList;
                else
                {
                    tmp = new List<Interaction>();
                    for (int u = 0; u < (totalIntNumber / maps + 1); u++)
                    {
                        if (interactionList.Count == 0) break;
                        int index = rng.Next(interactionList.Count);
                        tmp.Add(interactionList[index]);
                        interactionList.RemoveAt(index);
                    }
                }
                matrix[i] = new MapMatrix(parentSession, MakePortalsList(i), tmp, rng.Next(1000 * maps), (monsters, walls));
            }
        }

        public MapMatrix GetCurrentMatrix(int codeNumber)
        {
            // get the currently used board
            lastNumber = currentNumber;
            currentNumber = codeNumber;
            return matrix[codeNumber];
        }
        public int GetPreviousMatrixCode()
        {
            // for display when portal hopping
            // each board has its own individual code, which is used by portals to remember which portal leads where
            // example: let's say we have a board with code 34
            // this means that portals leading to that board will be encoded as 2034 value everywhere in the game
            return lastNumber;
        }

        private bool CheckConnectivity()
        {
            // utility: check if the adjacencyMatrix represents a fully connected graph
            visited = new int[maps];
            SearchAndMark(0);
            for (int i = 0; i < maps; i++)
            {
                if (visited[i] == 0) return false;
            }
            return true;
        }
        private void SearchAndMark(int nodeNumber)
        {
            // utility for the CheckConnectivity method
            visited[nodeNumber] = 1;
            for (int i = 0; i < maps; i++)
            {
                if (visited[i] == 1) continue;
                if (adjacencyMatrix[i, nodeNumber] == 0) continue;
                SearchAndMark(i);
            }
        }
        private List<int> MakePortalsList(int node)
        {
            // utility method for converting from matrix to list of portals
            List<int> ans = new List<int>();
            for (int i = 0; i < maps; i++)
            {
                if (adjacencyMatrix[i, node] == 1) ans.Add(i);
            }
            return ans;
        }
        private void GenerateInteractions()
        {
            // fill the game world with interactions
            interactionList = new List<Interaction>();
            QuestElements = Index.MainQuestFactory.CreateInteractionsGroup(parentSession);
            interactionList.AddRange(QuestElements);
            for (int i = 0; i < shops; i++) interactionList.Add(new ShopInteraction(parentSession));
            for (int i = shops + QuestElements.Count; i < interactions; i++) 
            {
                List<Interaction> tmp = Index.DrawInteractions(parentSession);
                if (tmp != null) interactionList.AddRange(tmp);
            }
        }

        // in-game map modifications
        public void AddMonsterToRandomMap(Monsters.MonsterFactories.MonsterFactory factory)
        {
            int mapNumber = currentNumber;
            while (mapNumber == currentNumber) mapNumber = Index.RNG(0, maps); // random map other than the current one
            while (true)
            {
                int x = Index.RNG(2, matrix[mapNumber].Width - 2);
                int y = Index.RNG(2, matrix[mapNumber].Height - 2);
                if (!matrix[mapNumber].ValidPlace(x, y))
                {
                    continue;
                }
                matrix[mapNumber].Matrix[y, x] = 1000;
                matrix[mapNumber].MonDict.Add(matrix[mapNumber].Width * y + x, factory);
                break;
            }
        }
        public void AddInteractionToRandomMap(Interaction interaction)
        {
            int mapNumber = currentNumber;
            while(mapNumber == currentNumber ) mapNumber = Index.RNG(0, maps); // random map other than the current one
            while(true)
            {
                int x = Index.RNG(2, matrix[mapNumber].Width - 2);
                int y = Index.RNG(2, matrix[mapNumber].Height - 2);
                if(!matrix[mapNumber].ValidPlace(x,y))
                {
                    continue;
                }
                if (matrix[mapNumber].Interactions.ContainsKey(matrix[mapNumber].Width * y + x)) continue;
                matrix[mapNumber].Interactions.Add(matrix[mapNumber].Width * y + x, interaction);
                matrix[mapNumber].Matrix[y, x] = 3000 + Int32.Parse(interaction.Name.Replace("interaction", ""));
                break;
            }
        }

    }
}
