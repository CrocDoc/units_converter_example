using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConvertor
{
    public class LengthConvertor : Units // Inherting Unit Abstract Base class to implement UnitConversion method 
    {
        public override string UnitConversion(string from, string to)
        {
            
            string MetricPrefixFrom=string.Empty,
                   MetricPrefixTo = string.Empty;
            string unitFrom, unitTo;
            double valueToWorkon = 0,
                   valueFromConvert = 0,
                   valueToConvert = 0;

            //Calling Parse input value to gather qantity, unit from and unit to
            string[] ParsedFrom = UnitHelper.ParseInput(from).Split('#');
            string[] ParsedTo = UnitHelper.ParseInput(to).Split('#');

            if (ParsedFrom.Length == 3)
            {
                valueFromConvert = Convert.ToDouble(ParsedFrom[0]);
                MetricPrefixFrom = ParsedFrom[1];
                unitFrom = ParsedFrom[2];
            }
            else
            {
                valueFromConvert = Convert.ToDouble(ParsedFrom[0]);
                unitFrom = ParsedFrom[1];
            }

            if (ParsedTo.Length == 3)
            {
                valueToConvert = Convert.ToDouble(ParsedTo[0]);
                MetricPrefixTo = ParsedTo[1];
                unitTo = ParsedTo[2];
            }
            else
            {
                valueToConvert = Convert.ToDouble(ParsedTo[0]);
                unitTo = ParsedTo[1];
            }

            try
            {
                // In the below if statement 2nd condition will make sures that similar unit types are used for conversion.
                if (UnitsConversionRates[unitFrom] > 0 && BaseUnits[unitFrom]==BaseUnits[unitTo])
                {
                    //Main Conversion logic

                    if (unitFrom.Contains("meters"))
                        valueToWorkon = valueFromConvert;
                    else
                        valueToWorkon = valueFromConvert / UnitsConversionRates[unitFrom];

                    if (!unitTo.Contains("meters"))
                        valueToWorkon = valueToWorkon * UnitsConversionRates[unitTo];

                    if(MetricPrefixTo.Length>0)
                        valueToWorkon = valueToWorkon / Math.Pow(10, UnitHelper.SIPrefix[MetricPrefixTo]);

                }

                return valueToWorkon + " " + to;
            }
            catch
            {
                throw new Exception("Input units are incorrect!");
            }
        }
    }
}
