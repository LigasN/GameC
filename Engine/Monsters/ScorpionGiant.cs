using Game.Engine.Items;
using Game.Engine.Items.Trophies;
using System;
using System.Collections.Generic;

namespace Game.Engine.Monsters
{
	[Serializable]
	class ScorpionGiant : Monster
	{
		// Monster. The biggest/strongest in scorpion group
		public ScorpionGiant(int playerLevel)
		{
			Health = 30 + 10 * playerLevel;
			Strength = 15 + 2 * playerLevel;
			Armor = 80;
			Precision = 70 + 2 * playerLevel;
			MagicPower = 0;
			Stamina = 5 + 10 * playerLevel;
			XPValue = 60 + playerLevel;
			Name = "monster0004";
			BattleGreetings = "You will die before crossing this doorstep!";
			PublicName = "Scorpion Giant";
		}
		public override List<StatPackage> BattleMove()
		{
			if(Stamina > 0)
			{
				Stamina -= 5;
				return new List<StatPackage>()
					{ new StatPackage("incised", 10, (5 * Strength + XPValue) / 10,
					((2 * Strength + 5 * Precision + XPValue * 5) * Stamina / 50) / 10, Precision * XPValue / 10000, MagicPower,
					("Guh!: hp = " + 10 + " ,strength = " + (5 * Strength + XPValue) / 10 + " ,armor = " + ((2 * Strength + 5 * Precision + XPValue * 5) * Stamina / 50) / 10
					+ " ,precision = " + Precision * XPValue / 10000 + " ,magic = " + MagicPower)) };
			}
			return new List<StatPackage>() { new StatPackage("none", 0, "Scorpion Giant has no energy to attack anymore!") };
		}

		public override Item getTrophy()
		{
			return trophyFactory.getTrophy(Trophy.MonsterTypes.ScorpionGiant);
		}
	}

}
