using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Clear up usings

namespace UnitConvertor
{
    //This is the abstract class which is holding the unit conversion rates and base units with unit types
    //Reason why i did not use the interface instead of Abstract is, it will make the code Redundant. I have to create below Dictionaries in all the convertor class 
    //In future this class can be extended to implement other unit types by adding its conversion rates and baseUnits values in below dictionaries. And implement Unitconversion method in the derived class for other unit types.

    /// <summary>
    /// Move the dictionary into App.config with a custom config section. This way the dataset can be changed without need of redeploying
    /// and doesn't take memory space when the program builds.
    /// 
    /// As LengthConvertor and DataConvertors in case of removing the dictionaries will inherit only the abstract method UnitConversion
    /// I would change this to an Interface as this class says that each child that inherits this class needs to implement their own
    /// implementation of UnitConversion.
    /// </summary>

    public abstract class Units
    {
        public static Dictionary<string, double> UnitsConversionRates = new Dictionary<string, double>()
        {
            { "meters",1},//meter 
            { "feets",3.280839895}, //feet
            {"inches", 39.37007874}, //inches
            {"bits", 1}, //bit
            {"bytes", 0.125} // bytes
        };

        public static Dictionary<string, string> BaseUnits = new Dictionary<string, string>()
        {
            { "meters","length"},//meter
            { "feets","length"}, //feet
            {"inches","length"}, //inches
            {"bits", "data"}, //bit
            {"bytes", "data"} // bytes
        };

        public abstract string UnitConversion(string from, string to);
       
    }


}
  