using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.RefinedArmor
{
    [Serializable]
    class Thanos_sglow : Item
	{
        public Thanos_sglow() : base("item0009")
        {
            PublicName = "Thanos_sglow";
            PublicTip = "makes Your strength double and stamina 70%";
            GoldValue = 100;
            ArMod = 10;
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.StrengthBuff += currentPlayer.Strength * 2;
            currentPlayer.StaminaBuff += (int)((float)currentPlayer.Stamina * 0.75);
        }
    }
}
