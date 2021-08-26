using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConvertor;

namespace UnitConvertor
{
    //This Factory class helps to instantiate objects for specific Unit class based on the unit type
    public static class UnitsFactory
    {      
        public static string Convertor(string from, string to)
        {
            //Here the input will be parsed and validate and finally the correct unit is fetched from Dictionary irrespective of grammer
            string currentBaseUnit = UnitHelper.getBaseUnit(from);
            string ConvertedValue=string.Empty;

            Units obj;

            try
            {
                if (Units.BaseUnits[currentBaseUnit] == "length")
                    obj=new LengthConvertor();// Implementation of polymorphism 
                else
                    obj=new DataConvertor();// Implementation of polymorphism 

                if (obj != null)
                    ConvertedValue=obj.UnitConversion(from, to);

                return ConvertedValue;
            }
            catch
            {
                throw new Exception("Measurement Unit/Unit type does not exists!");
            }
            
           
        }
    }
}
