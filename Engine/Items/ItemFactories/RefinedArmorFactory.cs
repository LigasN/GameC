using Game.Engine.Items.RefinedArmor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.ItemFactories
{
	[Serializable]
	class RefinedArmorFactory : ItemFactory
	{
		// produce items from refined armor directory
		public Item CreateItem()
		{
			List<Item> refinedArmor = new List<Item>()
			{
				new Thanos_sglow(),
				new CrystalArmor(),
				new GoldenDragonArmor()
			};
			return refinedArmor[Index.RNG(0, refinedArmor.Count)];
		}

		public Item CreateNonMagicItem()
		{
			List<Item> refinedArmor = new List<Item>()
			{
				new Thanos_sglow(),
				new GoldenDragonArmor()
			};
			return refinedArmor[Index.RNG(0, refinedArmor.Count)];
		}

		public Item CreateNonWeaponItem()
		{
			List<Item> refinedArmor = new List<Item>()
			{
				new Thanos_sglow(),
				new CrystalArmor(),
				new GoldenDragonArmor()
			};
			return refinedArmor[Index.RNG(0, refinedArmor.Count)];
		}
	}
}
