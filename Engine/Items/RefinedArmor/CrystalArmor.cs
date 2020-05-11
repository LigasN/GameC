using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.RefinedArmor
{
	[Serializable]
	class CrystalArmor : Item
	{
		private Engine.StatPackage.Statistics player_sBestStat;
		private int player_sBestStatValue;
		private int bonus;

		public CrystalArmor() : base("item0010")
		{
			PublicName = "CrystalArmor";
			PublicTip = "Armor for every class of warrior. Bonuses: " +
						"\n- Every attack belong to other attack classes You get gives You additional 5% to Your class attack dmg statistics. " +
						"E.G. if you are a magician then any other kind of attack you receive, gives you 10% to Your magic dmg statistics." +
						"\n- On start you get additional 20 points to every statistic plus double this value for your main skill";
			GoldValue = 200;
			HpMod = 20;
			StrMod = 20;
			ArMod = 20;
			PrMod = 20;
			MgcMod = 20;
			StaMod = 20;
		}
		public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
		{
			var dmg = (int)((player_sBestStatValue * (float)bonus) / 100);
			pack.addToSpecificDmgStatistic(player_sBestStat, dmg);
			return pack;
		}
		public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
		{
			var statistics = pack.getDmgStatistics();
			if(player_sBestStat != (StatPackage.Statistics)statistics.IndexOf(statistics.Max()))
				bonus += 5;
			return pack;

		}
		public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
		{
			base.ApplyBuffs(currentPlayer, otherItems);
			List< int >statistics = currentPlayer.getStatistics();
			player_sBestStat = (Engine.StatPackage.Statistics)statistics.IndexOf(statistics.Max());
			player_sBestStatValue = statistics[(int)player_sBestStat];
			currentPlayer.AddToSpecificStatistic(player_sBestStat, 20);
		}
	}
}
