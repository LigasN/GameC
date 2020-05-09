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
			Health = 40 + 10 * playerLevel;
			Strength = 15 + 2 * playerLevel;
			Armor = 70;
			Precision = 100 + 2 * playerLevel;
			MagicPower = 0;
			Stamina = 5 + 10 * playerLevel;
			XPValue = 100 + playerLevel;
			Name = "monster0003";
			BattleGreetings = "Ghhhzzz!";
		}
		public override List<StatPackage> BattleMove()
		{
			if (Stamina > 0)
			{
				Stamina -= 5;
				return new List<StatPackage>()
					{ new StatPackage("incised", 10, (5 * Strength + XPValue) / 10,
					(Strength + 2 * Precision + XPValue * 5) * (Stamina / 100) / 100, Precision * XPValue / 10000, MagicPower,
					("Ghhzzz!: hp = " + 10 + " ,strength = " + (5 * Strength + XPValue) / 10 + " ,armor = " + (Strength + 2 * Precision + XPValue * 5) * (Stamina / 100) / 100 
					+ " ,precision = " + Precision * XPValue / 10000 + " ,magic = " + MagicPower))};
			}
			return new List<StatPackage>() { new StatPackage("none", 0, "Scorpion has no energy to attack anymore!") };
		}

	}

}
