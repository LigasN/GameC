using Game.Engine.Items.Trophies;
using Game.Engine.Items;
using System;
using System.Collections.Generic;

namespace Game.Engine.Monsters
{
	[Serializable]
	class Scorpion : Monster
	{
		// Monster. Standard scorpion monster
		public Scorpion(int playerLevel)
		{
			Health = 20 + 10 * playerLevel;
			Strength = 15 + 2 * playerLevel;
			Armor = 50;
			Precision = 50 + 2 * playerLevel;
			MagicPower = 0;
			Stamina = 5 + 10 * playerLevel;
			XPValue = 50 + playerLevel;
			Name = "monster0003";
			BattleGreetings = "Ghhhzzz!";
			PublicName = "Scorpion";
		}
		public override List<StatPackage> BattleMove()
		{
			if (Stamina > 0)
			{
				Stamina -= 5;
				return new List<StatPackage>()
					{ new StatPackage("incised", 10, (5 * Strength + XPValue) / 10,
					(Strength + 2 * Precision + XPValue * 5) * (Stamina / 100) / 100, Precision * XPValue / 10000, MagicPower,
					("Ghhzzz!: : hp = " + 10 + " ,strength = " + (5 * Strength + XPValue) / 10 + " ,armor = " + ((2 * Strength + 5 * Precision + XPValue * 5) * Stamina / 50) / 10
					+ " ,precision = " + Precision * XPValue / 10000 + " ,magic = " + MagicPower))};
			}
			return new List<StatPackage>() { new StatPackage("none", 0, "Scorpion has no energy to attack anymore!") };
		}

		public override Item getTrophy()
		{
			return trophyFactory.getTrophy(Trophy.MonsterTypes.Scorpion);
		}

	}

}
