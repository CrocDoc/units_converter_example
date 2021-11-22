using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Clear up usings

namespace UnitConvertor
{

    public static class UnitHelper
    {

        /// <summary>
        /// Move the dictionary into App.config with a custom config section. This way the dataset can be changed without need of redeploying
        /// and doesn't take memory space when the program builds. 
        /// </summary>
            

        //Dictinary for holding Metric SI Prefix which will be used accross the library
        public readonly static Dictionary<string, double> SIPrefix = new Dictionary<string, double>()
        {
            {"deci" , -1},
            {"centi",-2},
            {"milli", -3},
            {"micro", -6},
            {"nano", -9},
            {"pico", -12},
            {"femto", -15},
            {"atto", -18},
            {"zepto", -21},
            {"yocto", -24},
            {"deca", 1},
            {"hecto", 2},
            {"kilo", 3},
            {"Mega", 6},
            {"Giga", 9},
            {"Tera", 12},
            {"Peta", 15},
            {"Exa", 18},
            {"Zetta", 21},
            {"Yotta", 24 }
        };

        /// <summary>
        /// No need for this if the input has separated value and unit
        /// </summary>
        /// <returns></returns>

        // Method helps tp prase the input string into quantity,Convert from, Convert To
        internal static string ParseInput(string s)
        {
            string prefixVal;
            double quantity;

                s = s.Replace(" ", "");
                var digits = new StringBuilder();
                foreach (var x in s)
                {
                    if (char.IsDigit(x))
                    {
                        digits.Append(x);
                    }
                    else
                    {
                        break;
                    }
                }

                quantity = digits.Length>0?double.Parse(digits.ToString()):1;
                s = s.Substring(digits.Length, s.Length - digits.Length);

                foreach (var item in SIPrefix)
                {
                    if (findString(item.Key,s))
                    {
                        prefixVal = item.Key;
                        s = s.Substring(prefixVal.Length, s.Length - prefixVal.Length);
                        s = getBaseUnit(s);
                        quantity = quantity * Math.Pow(10,SIPrefix[prefixVal]);
                        s = quantity + "#" + prefixVal + "#" + s;
                        return s;

                    } 
                }

                        s= getBaseUnit(s);
                    return quantity + "#" + s;
            
        }

        /// <summary>
        /// No need for this if the input has separated value and unit
        /// Naming doesn't make sense as return type is bool
        /// Inconsistent method naming
        /// </summary>
        /// <returns></returns>

        //Method helps to find a word in another word
        internal static bool findString(string For,string In)
        {
            var Forlen = For.Length;
            var Inlen = In.Length;
            var count = 0;

            for(int i=0;i<Forlen;i++)
            {
                for(int j=i;j<Inlen;j++)
                {
                    if (For[i].ToString().ToUpper() == In[j].ToString().ToUpper())
                    {
                        count++;
                        break;
                    }
                break;
                }
            }

            if(Forlen==count)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// No need for this if the input has separated value and unit
        /// Inconsistent method naming
        /// </summary>
        /// <returns></returns>

        //Method helps to identify the base units(From,To) from input string
        internal static string getBaseUnit(string input)
        {
            string prefixVal;
            input = input.Replace(" ", "");
            var digits = new StringBuilder();
            foreach (var x in input)
            {
                if (char.IsDigit(x))               
                    digits.Append(x);                
                else               
                    break;              
            }

            double quantity = digits.Length > 0 ? double.Parse(digits.ToString()) : 1;
            input = input.Substring(digits.Length, input.Length - digits.Length);

            foreach (var item in SIPrefix)
            {
                if (findString(item.Key, input))
                {
                    prefixVal = item.Key;
                    input = input.Substring(prefixVal.Length, input.Length - prefixVal.Length);
                    
                    break;
                }
            }

            foreach (var unit in Units.BaseUnits.Keys)
            {
                if (findString(input, unit))
                {
                    input = unit;
                    break;
                }
                else if (input == "foot")
                {
                    input = "feets";
                    break;
                }
            }

        return input;
        }
    }
}
