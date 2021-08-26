using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConvertor;

namespace UnitConvertor
{
    class Program
    {
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
