using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class DaughterFactory : MonsterFactory
    {
        private int encounterNumber = 0;
        public override Monster Create()
        {
            if (encounterNumber == 0)
            {
                encounterNumber++;
                return new Daughter();
            }

            else if (encounterNumber == 1)
            {
                encounterNumber++;
                return new Ghost("Bedziesz sluchac mojej playlisty az ci sie nie spodoba! (to znaczy do konca zycia)");
            }

            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new Daughter().GetImage();

            else if (encounterNumber == 1) return new Ghost().GetImage();

            else return null;
        }

    }
}
