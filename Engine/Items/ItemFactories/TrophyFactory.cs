using Game.Engine.Items.Trophies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.ItemFactories
{
	public class TrophyFactory
	{
		public Item getTrophy(Trophy.MonsterTypes monsterType)
		{
			switch(monsterType)
			{
				case Trophy.MonsterTypes.Rat:
					return new RatTrophy();
				case Trophy.MonsterTypes.RatEvolved:
					return new EvolvedRatTrophy();
				case Trophy.MonsterTypes.Scorpion:
					return new ScorpionTrophy();
				case Trophy.MonsterTypes.ScorpionEmperor:
					return new ScorpionEmperorTrophy();
				case Trophy.MonsterTypes.ScorpionGiant:
					return new ScorpionGiantTrophy();
				default:
					throw new NotImplementedException();
			}
		}
	}
}
