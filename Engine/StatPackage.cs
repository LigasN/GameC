using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Game.Engine
{
    // wrapper class for a bunch of statistics
    // meant to be used during battles and interactions

    // predefined damage types:
    // PHYSICAL DAMAGE - cut, incised (po polsku: rany kłute i cięte)
    // MAGIC DAMAGE - fire, air, water, earth
    // OTHERS - poison
    public class StatPackage
    {

        //----TaskG1-G2--------------------------

        // Needed for operations on all damages
        public enum Statistics
        {
            Health,
            Strength,
            Armor,
            Precision,
            MagicPower,
            Stamina, // it is a stat too
            Size // just size of this enum
        }

        public List<int> getDmgStatistics()
        {
            return new List<int> { HealthDmg, StrengthDmg, ArmorDmg, PrecisionDmg, MagicPowerDmg };
        }
        public void addToSpecificDmgStatistic(Statistics statistic, int deltaValue)
        {
            switch(statistic)
            {
                case Statistics.Health:
                    HealthDmg += deltaValue;
                    break;
                case Statistics.Strength:
                    StrengthDmg += deltaValue;
                    break;
                case Statistics.Armor:
                    ArmorDmg += deltaValue;
                    break;
                case Statistics.Precision:
                    PrecisionDmg += deltaValue;
                    break;
                case Statistics.MagicPower:
                    MagicPowerDmg += deltaValue;
                    break;
                case Statistics.Stamina:
                    MagicPowerDmg += deltaValue;
                    break;
                case Statistics.Size:
                default:
                    throw new ValueUnavailableException();
            }
        }

        //----!TaskG1-G2--------------------------

        public int HealthDmg { get; set; }
        public int StrengthDmg { get; set; }
        public int ArmorDmg { get; set; }
        public int PrecisionDmg { get; set; }
        public int MagicPowerDmg { get; set; }
        public string DamageType { get; set; }
        public string CustomText { get; set; }
        public StatPackage(string dmgType)
        {
            DamageType = dmgType;
        }
        public StatPackage(string dmgType, int hp)
        {
            DamageType = dmgType;
            HealthDmg = hp;
        }
        public StatPackage(string dmgType, int hp, string text)
        {
            DamageType = dmgType;
            HealthDmg = hp;
            CustomText = text;
        }
        public StatPackage(string dmgType, int hp, int strength, int armor, int precision, int magic, string text)
        {
            DamageType = dmgType;
            HealthDmg = hp;
            StrengthDmg = strength;
            ArmorDmg = armor;
            PrecisionDmg = precision;
            MagicPowerDmg = magic;
            CustomText = text;
        }
        
    }
}
