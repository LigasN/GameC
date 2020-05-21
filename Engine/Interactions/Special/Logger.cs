using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Special
{
	class Logger : Principal
	{
		public Logger(GameSession ses) : base(ses)
		{
			Name = "interaction0007";
			Enterable = false;
		}
		protected override void RunContent()
		{
			parentSession.SendText("Hello good person! Who are You?");
			var commisions = parentSession.currentPlayer.Commisions;
			var commisionIndex = SearchForCommision(Items.Commision.Commission.PossibleContent.WoodComission);
			if(commisionIndex >= 0)
			{
				parentSession.SendText("Ach Ok! Commision? I am very that you come. Please go with me!");
				parentSession.Wait(1000);
				parentSession.SendText(".");
				parentSession.Wait(1000);
				parentSession.SendText(".");
				parentSession.Wait(1000);
				parentSession.SendText(".");
				parentSession.Wait(1000);

				parentSession.SendText("Oh! So much thank you my friend! That was awesome! You've helped me very much! That's your money! (+ " +
					commisions[commisionIndex].amount * 10 + " Gold)");
				parentSession.UpdateStat(8, commisions[commisionIndex].amount * 10);
				parentSession.currentPlayer.Commisions.RemoveAt(commisionIndex);
			}
			else
			{
				parentSession.SendText("I see that you have nothing for me.. So meybe coffee?");
			}

		}
	}
}
