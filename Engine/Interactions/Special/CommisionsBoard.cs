using Game.Engine.Items;
using Game.Engine.Items.Trophies;
using Game.Engine.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.Engine.Interactions.Special
{
	class CommisionsBoard : ImageInteraction
	{
		public CommisionsBoard(GameSession ses) : base(ses)
		{
			Name = "interaction0005";
			Enterable = false;
		}
		private List<Tuple<string, Items.Commision.Commission.PossibleContent, int, int>> getRandCommisions()
		{
			List < Tuple<string, Items.Commision.Commission.PossibleContent, int, int>> commisionsList
				= new List < Tuple<string, Items.Commision.Commission.PossibleContent, int, int>> ();

			for(var i = 0; i < Index.RNG(0, 6); ++i)
			{
				if(Index.RNG(0, 2) == 1)
				{
					var amountToLog = Index.RNG(2,10);
					commisionsList.Add(new Tuple<string, Items.Commision.Commission.PossibleContent, int, int>
										("Hello,\n" +
										"needed help with logging. Any helping hand is welcome\n" +
										"Especially if you have worked with wood already! Come\n" +
										"to me(look for small blond boy in red T-shirt). I need\n" +
										"to log " + amountToLog + " trees with\n" +
										amountToLog * 10 + "salary.\n" +
										"Waiting with hope,\n" +
										"Bob\n",
										Items.Commision.Commission.PossibleContent.WoodComission, amountToLog, -1));
				}
				else
				{
					int typeNr = Index.RNG(0, (int)Trophy.MonsterTypes.Size);
					string monsterName = Trophy.MonsterTypeEnum2String((Trophy.MonsterTypes)typeNr);
					int amount = Index.RNG(1, 6);

					commisionsList.Add(new Tuple<string, Items.Commision.Commission.PossibleContent, int, int>
										("Hi,\n" +
										"authorities of this village needs help in fighting with\n" +
										monsterName + " in amount of " + amount + " of them.\n" +
										"Look for tall dark haired men. Salary set to " + amount * (typeNr + 1)  * 10 + ".\n" +
										"Yours faithfully,\n" +
										"Municipal Office.",
										Items.Commision.Commission.PossibleContent.MonsterComission, amount, typeNr));
				}
			}

			return commisionsList;
		}
		protected override void RunContent()
		{
			List<string> commisionsList = new List<string>{"Nah! Nothing for me..." };
			var commisionsProps = getRandCommisions();
			for(int i = 0; i < commisionsProps.Count(); ++i)
			{
				commisionsList.Add(commisionsProps[i].Item1);
			}
			var choice = parentSession.ListBoxInteractionChoice(commisionsList) - 1;

			if(choice < 0)
				return;

			parentSession.currentPlayer.Commisions.Add(new Items.Commision.Commission(commisionsProps[choice].Item1, commisionsProps[choice].Item2,
				commisionsProps[choice].Item3, commisionsProps[choice].Item4));
		}
	}
}
