using System;
using System.Collections.Generic;

namespace DDHLab1
{
    public class MobileGame
    {
        public int playableHours;
        protected string difficulty;
        public string PEGI;
        public MobileGame()
        {
            playableHours = 0;
            difficulty = "Default difficulty. ";
            PEGI = "R rated for being default. ";
        }
        public MobileGame(int _playableHours, string _difficulty, string _PEGI)
        {
            playableHours = _playableHours;
            difficulty = _difficulty;
            PEGI = _PEGI;
        }
        public string Play()
        {
            return "The Game started. Difficulty: \"" + difficulty + "\". " + "PEGI rating: \"" + PEGI + "\". ";
        }
        public string AutoSave()
        {
            return "Game saved. ";
        }
        public string Pause()
        {
            return "Game paused. ";
        }
    }
    class Character
    {
        public string name;
        public Character()
        {
            name = "Default Character";
        }
        public Character( string _name )
        {
            name = _name;
        }
    }
    class RPG : MobileGame
    {
        public int characterLevel;
        public Dictionary<string, int> attributes = new Dictionary<string, int>();
        public RPG()
        {
            characterLevel = 0;
            attributes.Add("Defaultness", 100);
        }
        public RPG(int _playableHours, string _difficulty, string _PEGI, int _characterLevel, Dictionary<string, int> _attributes) : base(_playableHours, _difficulty, _PEGI)
        {
            characterLevel = _characterLevel;
            attributes = _attributes;
        }
        public string NewCharacter(Character character)
        {
            return "Character " + character.name + " was created. ";
        }
        public string DeleteCharacter(Character character)
        {
            return "Character " + character.name + " deleted";
        }
    }
    class Vehicle
    {
        public string name;
        public Vehicle()
        {
            name = "Default Vehicle";
        }
        public Vehicle( string _name )
        {
            name = _name;
        }
    }
    class RacingGame : MobileGame
    {
        public string currentVehicle;
        protected List<Vehicle> ownedVehicles;
        public RacingGame()
        {
            ownedVehicles[0] = new Vehicle();
            currentVehicle = ownedVehicles[0].name;
        }
        public RacingGame(int _playableHours, string _difficulty, string _PEGI, string _currentVehicle, List<Vehicle> _ownedVehicles) : base(_playableHours, _difficulty, _PEGI)
        {
            currentVehicle = _currentVehicle;
            ownedVehicles = _ownedVehicles;
        }
        public string BuyVehicle(Vehicle vehicle)
        {
            ownedVehicles.Add(vehicle);
            return "Bought a " + vehicle.name + ". ";
        }
        public string SellVehicle(Vehicle vehicle)
        {
            ownedVehicles.Remove(vehicle);
            return vehicle.name + " sold.";
        }
        public string ListOwnedVehicles()
        {
            string ownedVehiclesList = "Owned Vehicles: ";
            for( int i = 0; i < ownedVehicles.Count; i++)
            {              
                if( i == ownedVehicles.Count - 1)                
                    ownedVehiclesList += ownedVehicles[i].name + ". ";              
                else
                    ownedVehiclesList += ownedVehicles[i].name + ", ";
            }
            return ownedVehiclesList;
        }
    }
    class LogicBasedGame : MobileGame
    {
        public int timeLeft;
        public int maxTime;
        public LogicBasedGame()
        {
            maxTime = 3600;
            timeLeft = maxTime;
        }
        public LogicBasedGame(int _playableHours, string _difficulty, string _PEGI, int _maxTime) : base(_playableHours, _difficulty, _PEGI)
        {
            maxTime = _maxTime;
            timeLeft = maxTime;         
        }
        public string Restart()
        {
            timeLeft = maxTime;
            return "Game restarted. Time left is " + maxTime + " s.";
        }
    }
    class Chess : LogicBasedGame
    {
        public int numberOfFigures;
        public Chess()
        {
            numberOfFigures = 16;
        }
        public Chess(int _playableHours, string _difficulty, string _PEGI, int _timeLeft, int _numberOfFigures) : base(_playableHours, _difficulty, _PEGI, _timeLeft)
        {
            numberOfFigures = _numberOfFigures;
        }
        public string Surrender()
        {
            return "A player has decided to forfeit the game. ";
        }
        public string MoveFigure(string current, string destination)
        {
            return "Figure moved from " + current + " to " + destination + ". ";
        }
    }
    class Puzzle : LogicBasedGame
    {
        public int piecesTotal;
        protected int piecesLeft;
        public Puzzle()
        {
            piecesTotal = 3000;
            piecesLeft = piecesTotal;
        }
        public Puzzle(int _playableHours, string _difficulty, string _PEGI, int _timeLeft, int _piecesTotal) : base(_playableHours, _difficulty, _PEGI, _timeLeft)
        {
            piecesTotal = _piecesTotal;
            piecesLeft = piecesTotal;
        }
        public string ShowHint()
        {
            return "Hint: Get better!";
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            MobileGame mg = new MobileGame(100, "Hardcore", "R");
            Console.WriteLine(mg.Play());
            Console.WriteLine(mg.AutoSave());
            Console.WriteLine(mg.Pause());

            Console.WriteLine("");

            Dictionary<string, int> myAttributes = new Dictionary<string, int>
            {
                { "Lameness", 100 },
                { "Genereic attribute", 69 }
            };
            RPG rpg = new RPG(100, "Hard enough", "13+", 1, myAttributes);
            Character roger = new Character("Roger");
            Console.WriteLine(" | " + rpg.Play());
            Console.WriteLine(" | " + rpg.NewCharacter(roger));
            Console.WriteLine(" | " + rpg.DeleteCharacter(roger));

            Console.WriteLine("");

            Vehicle defVehicle = new Vehicle();
            List<Vehicle> myVehicles = new List<Vehicle>
            {
                defVehicle
            };
            RacingGame rg = new RacingGame(20, "Easy", "3+", myVehicles[0].name, myVehicles);
            Console.WriteLine(" | " + rg.Play());
            Console.WriteLine(" | " + rg.ListOwnedVehicles());
            Console.WriteLine(" | " + rg.BuyVehicle(new Vehicle("Volk$WAGen")));
            Console.WriteLine(" | " + rg.ListOwnedVehicles());
            Console.WriteLine(" | " + rg.SellVehicle(defVehicle));
            Console.WriteLine(" | " + rg.ListOwnedVehicles());

            Console.WriteLine("");

            LogicBasedGame lbg = new LogicBasedGame(5, "High IQ needed", "0+", 7200);
            Console.WriteLine(" | " + lbg.Play());
            Console.WriteLine(" | " + lbg.Restart());

            Console.WriteLine("");

            Chess chess = new Chess(2, "ez pz", "-2+", 60, 48);
            Console.WriteLine(" | " + " | " + chess.Play ());
            Console.WriteLine(" | " + " | " + chess.MoveFigure("C3", "B4"));
            Console.WriteLine(" | " + " | " + chess.Surrender());

            Console.WriteLine("");

            Puzzle puzzle = new Puzzle(1, "Family friendly", "3+", 54400, 3000);
            Console.WriteLine(" | " + " | " + puzzle.Play());
            Console.WriteLine(" | " + " | " + puzzle.ShowHint());
        }
    }
}
