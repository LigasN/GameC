using System;
using System.Collections.Generic;

namespace Game.Engine.Monsters
{
	[Serializable]
	class ScorpionEmperor : Monster
	{
		// Monster. The most important in scorpion group
		public ScorpionEmperor(int playerLevel)
		{
			Health = 40 + 10 * playerLevel;
			Strength = 15 + 2 * playerLevel;
			Armor = 70;
			Precision = 100 + 2 * playerLevel;
			MagicPower = 0;
			Stamina = 5 + 10 * playerLevel;
			XPValue = 100 + playerLevel;
			Name = "monster0005";
			BattleGreetings = "Jakim cudem pokonałeś straż!";
		}
		public override List<StatPackage> BattleMove()
		{
			if (Stamina > 0)
			{
				Stamina -= 5;
				return new List<StatPackage>()
					{ new StatPackage("incised", 10, (5 * Strength + XPValue),
					(Strength + 2 * Precision + XPValue * 5) * (Stamina / 100) / 100, Precision * XPValue / 10000, MagicPower,
					"Hah!") };
			}
			return new List<StatPackage>() { new StatPackage("none", 0, "Scorpion Emperor has no energy to attack anymore!") };
		}

	}

}
