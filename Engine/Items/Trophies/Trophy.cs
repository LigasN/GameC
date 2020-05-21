using Game.Engine.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Trophies
{
	public class Trophy : Item
	{
		public enum MonsterTypes
		{
			Rat,
			RatEvolved,
			Scorpion,
			ScorpionEmperor,
			ScorpionGiant,
			Size    // Just size of enum
		}
		public Trophy(MonsterTypes monsterType) : base(MonsterTypeEnum2ImgName(monsterType))
		{
			PublicName = "Trophy of the " + MonsterTypeEnum2String(monsterType);
			GoldValue = 10;
		}

		public static string MonsterTypeEnum2String(MonsterTypes monsterType)
		{
			switch(monsterType)
			{
				case MonsterTypes.Rat:
					return "Rat";
				case MonsterTypes.RatEvolved:
					return "Rat Evolved";
				case MonsterTypes.Scorpion:
					return "Scorpion";
				case MonsterTypes.ScorpionEmperor:
					return "Scorpion Emperor";
				case MonsterTypes.ScorpionGiant:
					return "Scorpion Giant";
				default:
					throw new NotImplementedException();
			}
		}
		public static string MonsterTypeEnum2ImgName(MonsterTypes monsterType)
		{
			return "item00" + (13 + (int)monsterType);
		}

	}
}
