using Game.Engine.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Special
{
	class University : ListBoxInteraction
	{
		public University(GameSession ses) : base(ses)
		{
			Name = "interaction0008";
			Enterable = false;
		}
		protected override void RunContent()
		{
			parentSession.SendText("\nWelcome on the University! Your current skills look impressively.");
			List<Skill> playerSkills = parentSession.currentPlayer.ListOfSkills;
			foreach(Skill sk in playerSkills)
			{
				parentSession.SendText("\t- " + sk.ToString());
			}
			parentSession.SendText("\nWhat about learning something new? Only 50 gold for any skill you want!");
			parentSession.SendText("\t- Yes, why not?(press y)\n\t- No no thanks...(press n)");
			var learn = parentSession.GetValidKeyResponse(new List<string>() { "Y", "N"}).Item1;
			if(learn == "y" || learn == "Y")
			{
				if(parentSession.currentPlayer.Gold > 50)
				{
					parentSession.SendText("We can offer you:");
					List <Skill> availableSkills = Index.AllAvailableSkills(parentSession.currentPlayer);
					List<string> choices = new List<string>();
					foreach(Skill sk in availableSkills)
					{
						parentSession.SendText(sk.ToString());
						choices.Add(sk.ToString());
					}
					choices.Add("Thank you, I have changed my mind");
					int choice = GetListBoxChoice(choices);
					if(choice < choices.Count - 1)
					{
						parentSession.currentPlayer.ListOfSkills.Add(availableSkills[choice]);
						parentSession.UpdateStat(8, -50);
					}
					parentSession.SendText("\n");
				}
				else
					parentSession.SendText("But I must know that I'm not wasting my time on You. You do not have money? So.. Sorry.");
			}
			parentSession.SendText("See you soon!");
		}
	}
}
