using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConvertor;

// Clear up usings

namespace UnitConvertor
{
    class Program
    {
        /// <summary>
        /// Separate quantity and quantity unit into two different inputs in order to avoid input handling.
        /// List list of accepted parameters to the user to avoid incorrect inputs.
        /// Input value should be validated rightaway in order to eliminate unnecessary object alocation.
        /// </summary>

        static void Main(string[] args)
        {
            string result;
            string from, to;            

            Console.WriteLine("Enter quantity and conversion unit to convert: ");
            from = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter conversion unit to: ");
            to = Console.ReadLine();
            Console.WriteLine();

            result= UnitsFactory.Convertor(from,to);

            Console.WriteLine(from + " = " + result);

            Console.ReadLine();
        }
    }
}
