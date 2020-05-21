using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
	class AuthorityFactory : InteractionFactory
	{
		public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
		{
			return new List<Interaction> { new Special.Authority(parentSession) };
		}
	}
}
