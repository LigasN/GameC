using System;

namespace Game.Engine.Monsters.MonsterFactories
{
	[Serializable]
	class ScorpionEmperorFactory : MonsterFactory
	{    // this factory produces scorpion emperor and it's guard

		private int encounterNumber = 0; // how many times has this factory been used already?
		public override Monster Create(int playerLevel)
		{
			if (encounterNumber == 0) // if this is the first time, return a Rat
			{
				encounterNumber++;
				return new ScorpionGiant(playerLevel);
			}
			else if (encounterNumber == 1) // if this is the second time, return a RatEvolved
			{
				encounterNumber++;
				return new ScorpionEmperor(playerLevel);
			}
			else return null; // no more to fight with
		}
		public override System.Windows.Controls.Image Hint()
		{
			if (encounterNumber == 0) return new ScorpionGiant(0).GetImage();
			else if (encounterNumber == 1) return new ScorpionEmperor(0).GetImage();
			else return null;
		}
	}
}
