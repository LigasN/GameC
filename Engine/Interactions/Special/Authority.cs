using Game.Engine.Items.Trophies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.Engine.Interactions.Special
{
	class Authority : Principal
	{
		public Authority(GameSession ses) : base(ses)
		{
			Name = "interaction0006";
			Enterable = false;
		}
		protected override int SearchForCommision(Items.Commision.Commission.PossibleContent content)
		{
			var commisions = parentSession.currentPlayer.Commisions;
			for(int i = 0; i < commisions.Count(); ++i)
			{
				if(commisions[i].contentType == content)
				{
					if(parentSession.CheckItem(Trophy.MonsterTypeEnum2ImgName((Trophy.MonsterTypes)commisions[i].monsterType)))
					{
						return i + commisions.Count();
					}
					else
						return i;
				}
			}
			return -1;
		}
		private void SignEvery()
		{
			for(int i = 0; i < parentSession.currentPlayer.Commisions.Count(); ++i)
			{
				if(parentSession.currentPlayer.Commisions[i].monsterType >= 0)
				{
					parentSession.currentPlayer.Commisions[i].MakeSign();
				}
			}
		}
		protected override void RunContent()
		{
			parentSession.SendText("Hello somebody! What you want?");
			var commisions = parentSession.currentPlayer.Commisions;
			var commisionIndex = SearchForCommision(Items.Commision.Commission.PossibleContent.MonsterComission);
			if(commisionIndex >= 0)
			{
				parentSession.SendText("Ach Ok! Commision? Have you done this task or you came for my blessing?");

				if(commisionIndex >= commisions.Count())
				{
					commisionIndex -= commisions.Count();
					var trophiesAmount = 0;

					while(parentSession.CheckItem(Trophy.MonsterTypeEnum2ImgName((Trophy.MonsterTypes)commisions[commisionIndex].monsterType)))
					{
						parentSession.RemoveItem(Trophy.MonsterTypeEnum2ImgName((Trophy.MonsterTypes)commisions[commisionIndex].monsterType));
						++trophiesAmount;
						if(trophiesAmount >= commisions[commisionIndex].amount)
						{
							parentSession.SendText("O! Ok! Nice... That's your money! (+ " + commisions[commisionIndex].amount * (commisions[commisionIndex].monsterType + 1) * 10
								+ " Gold)");
							parentSession.UpdateStat(8, commisions[commisionIndex].amount * (commisions[commisionIndex].monsterType + 1) * 10);
							parentSession.currentPlayer.Commisions.RemoveAt(commisionIndex);
							break;
						}
					}
					if(commisions.Count() > commisionIndex)
					{
						if(trophiesAmount < commisions[commisionIndex].amount)
						{
							parentSession.SendText("O! Ok! Nice... Thanks for help! It is only " + (commisions[commisionIndex].amount - trophiesAmount) + " more to kill!");
							parentSession.currentPlayer.Commisions[commisionIndex].amount = parentSession.currentPlayer.Commisions[commisionIndex].amount - trophiesAmount;
							parentSession.SendText("A yes yes your money for the work you've done. Please take! (+ " + commisions[commisionIndex].amount * (commisions[commisionIndex].monsterType + 1) * 10 + " Gold)");
							parentSession.UpdateStat(8, trophiesAmount * (commisions[commisionIndex].monsterType + 1) * 10);
						}
					}
				}
				else
				{
					parentSession.SendText("Yeah... I see.. Only blessing. You have that. All your commisions issued by Municipal Office are signed. Please go and do the trick.");
					SignEvery();
				}
			}
			else
			{
				parentSession.SendText("If nothing, why are you starring at me? Are you ill or sth?");
			}

		}
	}
}
