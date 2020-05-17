using Game.Engine.Items;
using Game.Engine.Items.Trophies;
using System;
using System.Collections.Generic;
using System.Windows.Navigation;

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
			Armor = 60;
			Precision = 100 + 2 * playerLevel;
			MagicPower = 0;
			Stamina = 5 + 10 * playerLevel;
			XPValue = 100 + playerLevel;
			Name = "monster0005";
			BattleGreetings = "How it is possible that You killed my guard!";
			PublicName = "Scorpion Emperor";
		}
		public override List<StatPackage> BattleMove()
		{
			if(Stamina > 0)
			{
				Stamina -= 5;
				return new List<StatPackage>()
					{ new StatPackage("incised", 10, (5 * Strength + XPValue) / 10,
					(Strength + 2 * Precision + XPValue * 5) * (Stamina / 100) / 100, Precision * XPValue / 10000, MagicPower,
					("Hah!: : hp = " + 10 + " ,strength = " + (5 * Strength + XPValue) / 10 + " ,armor = " + ((2 * Strength + 5 * Precision + XPValue * 5) * Stamina / 50) / 10
					+ " ,precision = " + Precision * XPValue / 10000 + " ,magic = " + MagicPower))};
			}
			return new List<StatPackage>() { new StatPackage("none", 0, "Scorpion Emperor has no energy to attack anymore!") };
		}

		public override Item getTrophy()
		{
			return trophyFactory.getTrophy(Trophy.MonsterTypes.ScorpionEmperor);
		}
	}

}
