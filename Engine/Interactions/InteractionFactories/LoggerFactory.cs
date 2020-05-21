using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
	class LoggerFactory : InteractionFactory
	{
		public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
		{
			return new List<Interaction> { new Special.Logger(parentSession) };
		}
	}
}
