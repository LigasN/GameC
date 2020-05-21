using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Special
{
	abstract class Principal : ConsoleInteraction
	{
		public Principal(GameSession ses): base(ses)
		{
		}
		virtual protected int SearchForCommision(Items.Commision.Commission.PossibleContent content )
		{
			var commisions = parentSession.currentPlayer.Commisions;
			for(int i = 0; i < commisions.Count(); ++i)
			{
				if(commisions[i].contentType == content)
				{
					return i;
				}
			}
			return -1;
		}
	}
}
