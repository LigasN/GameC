﻿using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.RefinedMovements
{
	[Serializable]
	class FrighteningPitting : Skill
	{
		public FrighteningPitting() : base("Frightening Pitting", 40, 5)
		{
			PublicName = "Frightening Pitting: a chance to land multiplayed by 0 to 10 sum of precision and strength divided by 50 for HP and 20 for armor[cut]";
			RequiredItem = "Spear";
		}
		public override List<StatPackage> BattleMove(Player player)
		{
			StatPackage response = new StatPackage("cut");
			response.HealthDmg = (int)(Index.RNG(0, 10) * (player.Precision + player.Strength) / 50);
			response.ArmorDmg = (int)(Index.RNG(0, 10) * (player.Precision + player.Strength) / 20);
			response.CustomText = "You use frightening pitting! (" + response.HealthDmg + " damage on HP and " + response.ArmorDmg + " on armor. Cut damage.)";
			return new List<StatPackage>() { response };
		}
	}
}
