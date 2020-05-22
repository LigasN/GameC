using System;
using System.Collections.Generic;
using Game.Engine.Skills.SkillFactories;
using Game.Engine.Monsters.MonsterFactories;
using Game.Engine.Items;
using Game.Engine.Items.ItemFactories;
using Game.Engine.Items.BasicArmor;
using Game.Engine.Interactions;
using Game.Engine.Interactions.InteractionFactories;
using Game.Engine.Items.RefinedArmor;
using Game.Engine.Items.Trophies;

namespace Game.Engine
{
	// contains information about skills, items and monsters that will be available in the game
	public partial class Index
	{
		private static List<SkillFactory> magicSkillFactories = new List<SkillFactory>()
		{
			new BasicSpellFactory()
		};

		private static List<SkillFactory> weaponSkillFactories = new List<SkillFactory>()
		{
			new BasicWeaponMoveFactory(),
			new RefinedMovementsFactory()
		};

		private static List<Item> items = new List<Item>()
		{
			new BasicStaff(),
			new BasicSpear(),
			new BasicAxe(),
			new BasicSword(),
			new SteelArmor(),
			new AntiMagicArmor(),
			new BerserkerArmor(),
			new GrowingStoneArmor(),
			new Thanos_sglow(),
			new CrystalArmor(),
			new GoldenDragonArmor(),
			new RatTrophy(),
			new EvolvedRatTrophy(),
			new ScorpionTrophy(),
			new ScorpionEmperorTrophy(),
			new ScorpionGiantTrophy()
		};

		private static List<ItemFactory> itemFactories = new List<ItemFactory>()
		{
			new BasicArmorFactory(),
			new RefinedArmorFactory()
		};

		private static List<MonsterFactory> monsterFactories = new List<MonsterFactory>()
		{
			new Monsters.MonsterFactories.RatFactory(),
			new Monsters.MonsterFactories.ScorpionFactory(),
			new Monsters.MonsterFactories.ScorpionEmperorFactory()
		};

		private static List<InteractionFactory> interactionFactories = new List<InteractionFactory>()
		{
			new SkillForgetFactory(),
			new GymirHymirFactory(),
			new CommisionBoardFactory(),
			new AuthorityFactory(),
			new LoggerFactory(),
			new UnivesityFactory()
		};

	}
}
