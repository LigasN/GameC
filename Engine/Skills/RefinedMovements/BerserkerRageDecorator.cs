using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.RefinedMovements
{
	[Serializable]
	class BerserkerRageDecorator : SkillDecorator
	{// decorator for BerserkerRage class
		public BerserkerRageDecorator(Skill skill) : base("Berserker Rage", 40, 5, skill)
		{
			MinimumLevel = Math.Max(4, skill.MinimumLevel) + 3;
			PublicName = "COMBO - Berserker Rage: a chance equal to half of your strength stat to land 0.5*Str Hp, " +
				"0.25*Str Precision damage [incised] AND " + decoratedSkill.PublicName.Replace("COMBO - ", "");
			RequiredItem = "Axe";
		}
		public override List<StatPackage> BattleMove(Player player)
		{
			StatPackage response = new StatPackage("incised");
			if(Index.RNG(0, 200) < player.Strength)
			{
				response.HealthDmg = (int)(0.5 * player.Strength);
				response.PrecisionDmg = (int)(0.25 * player.Strength);
				response.CustomText = "You use berserker rage! (" + response.HealthDmg + " damage on HP and " + response.PrecisionDmg + " on precision. Incisied damage.)";
			}
			else
			{
				response.HealthDmg = 0;
				response.CustomText = "You just tried too hard and you missed!";
			}
			List<StatPackage> combo = decoratedSkill.BattleMove(player);
			combo.Add(response);
			return combo;
		}
	}
}
