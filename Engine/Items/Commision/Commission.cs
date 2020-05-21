using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Commision
{
	public class Commission
	{
		public enum PossibleContent
		{
			WoodComission,
			MonsterComission
		}
		public bool signed { get; private set; }
		public string content { get; set; }
		public PossibleContent contentType { get; set; }
		public int amount { get; set; }

		public int monsterType { get; private set; }

		public Commission(string content, PossibleContent contentType, int amount = 0, int monsterType = -1)
		{
			this.contentType = contentType;
			this.amount = amount;
			this.content = content;
			this.monsterType = monsterType;
		}
		public void MakeSign()
		{
			signed = true;
		}
	}
}
