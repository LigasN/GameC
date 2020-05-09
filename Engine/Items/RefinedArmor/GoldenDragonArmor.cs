using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.RefinedArmor
{
	[Serializable]
	class GoldenDragonArmor : Item
	{
		private int bonus;
		public GoldenDragonArmor() : base("item0011")
		{
			PublicName = "GoldenDragonArmor";
			PublicTip = "As much Hp's damage You once receive as much point of damage spread for every possible damage stat You will cause to Your opponent in Your next turn()additionally.";
			GoldValue = 150;
			ArMod = 40;
		}
		public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
		{
			var stats = pack.getDmgStatistics();
			for(int i = 0; i < (int)StatPackage.Statistics.Size - 1; ++i)
			{
				pack.addToSpecificDmgStatistic((StatPackage.Statistics)i, bonus / (int)StatPackage.Statistics.Size);
			}
			return pack;
		}
		public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
		{
			bonus = pack.HealthDmg;
			return pack;
		}
	}
}
