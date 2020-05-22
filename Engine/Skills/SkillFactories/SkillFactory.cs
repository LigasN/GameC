using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SkillFactories
{
	interface SkillFactory
	{
		List<Skill> AvailableSkillsList(Player player);

		// interface for all skill factories
		Skill CreateSkill(Player player);
	}
}
