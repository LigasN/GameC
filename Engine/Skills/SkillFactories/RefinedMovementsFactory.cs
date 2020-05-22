using Game.Engine.CharacterClasses;
using Game.Engine.Skills.RefinedMovements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.SkillFactories
{
	[Serializable]
	class RefinedMovementsFactory : SkillFactory
	{
		public List<Skill> AvailableSkillsList(Player player)
		{
			List<Skill> playerSkills = player.ListOfSkills;
			Skill known = CheckContent(playerSkills); // check what movements from the RefinedMovements category are known by the player already
			if(known == null) // no RefinedMovements known - we will return one of them
			{
				List<Skill> movementSkills = new List<Skill> { new TwistPierce(), new FrighteningPitting(), new BerserkerRage() };
				var possibleSkills = movementSkills.FindAll(m => m.MinimumLevel > player.Level);
				if(possibleSkills.Count != 0)
					return possibleSkills;
				return null;
			}
			else if(known.decoratedSkill == null) // a RefinedMovements has been already learned, use decorator to create a combo
			{
				List<Skill> movementSkills = new List<Skill> { new TwistPierceDecorator(known), new FrighteningPittingDecorator(known), new BerserkerRageDecorator(known) };
				List<Skill> tmp = new List<Skill>();
				var possibleSkills = movementSkills.FindAll(m => m.MinimumLevel > player.Level);
				if(possibleSkills.Count != 0)
					return possibleSkills;
				return null;
			}
			else
				return null; // a combo of RefinedMovements has been already learned - this factory doesn't offer double combos so we stop here
		}

		// this factory produces skills from RefinedMovements directory
		public Skill CreateSkill(Player player)
		{
			List<Skill> tmp = AvailableSkillsList(player);
			if(tmp.Count == 0)
				return null;
			return tmp[Index.RNG(0, tmp.Count)]; // use Index.RNG for safe random numbers
		}
		private Skill CheckContent(List<Skill> skills) // wrapper method for checking
		{
			foreach(Skill skill in skills)
			{
				if(skill is TwistPierce || skill is TwistPierceDecorator || skill is FrighteningPitting || skill is FrighteningPittingDecorator || skill is BerserkerRage || skill is BerserkerRageDecorator)
					return skill;
			}
			return null;
		}
	}
}
