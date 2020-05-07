using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
	[Serializable]
	class ScorpionFactory : MonsterFactory
	{    // this factory produces scorpion emperor and it's guard

		private int encounterNumber = 0; // how many times has this factory been used already?
		public override Monster Create(int playerLevel)
		{
			if (encounterNumber == 0) // if this is the first time, return a Rat
			{
				encounterNumber++;
				return new Scorpion(playerLevel);
			}
			else return null; // no more rats to fight
		}
		public override System.Windows.Controls.Image Hint()
		{
			if (encounterNumber == 0) return new Scorpion(0).GetImage();
			else return null;
		}
	}

}
