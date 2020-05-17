using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Commision
{
	class Commission : DisplayItem
	{
		public enum PossibleContent
		{
			WoodComission,
			MonsterComission
		}

		PossibleContent content;
		public Commission(PossibleContent content, int amount = 0)
		{
			Name = "item0012";
			PublicName = "Commision";
			this.content = content;

			switch(content)
			{
				case PossibleContent.WoodComission:
					PublicTip = "I need help with wood. Please meet me somewhere. Short blond with red T-shirt";
					break;
				case PossibleContent.MonsterComission:
					PublicTip = "Our city needs some help with mosters. Please kill " + amount + " of these *** and bring me a trophy of each one!";
					break;
			}
		}
	}
}
