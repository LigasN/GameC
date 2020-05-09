using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.RefinedMovements
{
	[Serializable]
	class TwistPierce : Skill
	{
		public TwistPierce() : base("Twist Pierce", 40, 5)
		{
			PublicName = "Twist Pierce: a chance 100/225 of precision stat to land (0.25*Str + extra 20 points if you have more strength than 100) HP and 0.25*PR Armor damage [incised]";
			RequiredItem = "Sword";
		}
		public override List<StatPackage> BattleMove(Player player)
		{
			StatPackage response = new StatPackage("incised");
			if(Index.RNG(0, 225) < player.Precision)
			{
				response.HealthDmg = (int)(0.25 * player.Strength + ((player.Strength > 100) ? 20 : 0));
				response.ArmorDmg = (int)(0.25 * player.Precision);
				response.CustomText = "You use twist pierce! (" + response.HealthDmg + " damage on HP and " + response.ArmorDmg + " on armor. Incisied damage.)";
			}
			else
			{
				response.HealthDmg = 0;
				response.CustomText = "You just tried too hard and you missed!";
			}
			return new List<StatPackage>() { response };
		}
	}
}
