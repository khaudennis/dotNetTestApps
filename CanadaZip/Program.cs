using System;
using System.Collections.Generic;
using System.Linq;

namespace CanadaZip
{
    class Program
    {
        public static List<Province> provinces = new List<Province> { };

        static void Main(string[] args)
        {
            createList();
            whatTerritory("L4G 6V9");
            Console.WriteLine(isValid("ON", "L4G 6V9"));

            whatTerritory("B3T 8L4");
            Console.WriteLine(isValid("NS", "B3T 8L4"));

            whatTerritory("J1T 5G1");
            Console.WriteLine(isValid("QC", "J1T 5G1"));

            whatTerritory("E7G 4N3");
            Console.WriteLine(isValid("NB", "E7G 4N3"));

            whatTerritory("E4E 5G1");
            Console.WriteLine(isValid("ON", "E4E 5G1"));

            whatTerritory("N7A 1R8");
            Console.WriteLine(isValid("ON", "N7A 1R8"));

            Console.WriteLine(isValid("ON", "N7A1R8"));
        }

        static bool isValid(string territory, string zipCode)
        {
            if (zipCode.Length != 7) return false;

            if (zipCode.StartsWith("X"))
            {
                return territory.ToLower() == provinces.Find(x => x.Prefix.Contains(zipCode.Substring(0, 3))).Code.ToLower() ? true : false;
            }
            else
            {
                return territory.ToLower() == provinces.Find(x => x.Prefix.Contains(zipCode.Substring(0, 1))).Code.ToLower() ? true : false;
            }
        }

        static void whatTerritory(string zipCode)
        {
            Province result;

            if (zipCode.StartsWith("X"))
            {
                result = provinces.Find(x => x.Prefix.Contains(zipCode.Substring(0, 3)));
            }
            else
            {
                result = provinces.Find(x => x.Prefix.Contains(zipCode.Substring(0, 1)));
            }

            Console.WriteLine(result.Code);
        }

        static void createList()
        {
            provinces = new List<Province>
            {
                new Province() { Code="NL", Prefix=new string[] { "A"} },
                new Province() { Code="NS", Prefix=new string[] { "B"} },
                new Province() { Code="PE", Prefix=new string[] { "C"} },
                new Province() { Code="NB", Prefix=new string[] { "E"} },
                new Province() { Code="QC", Prefix=new string[] { "G", "H", "J" } },
                new Province() { Code="ON", Prefix=new string[] { "K", "L", "M", "N"} },
                new Province() { Code="MB", Prefix=new string[] { "R"} },
                new Province() { Code="SK", Prefix=new string[] { "S"} },
                new Province() { Code="AB", Prefix=new string[] { "T"} },
                new Province() { Code="BC", Prefix=new string[] { "V"} },
                new Province() { Code="NU", Prefix=new string[] { "X0A", "X0B", "X0C"} },
                new Province() { Code="NT", Prefix=new string[] { "X0E", "X0G", "X1A"} },
                new Province() { Code="YT", Prefix=new string[] { "Y" } }
            };
        }

        internal class Province
        {
            public string Code { get; set; }
            public string[] Prefix { get; set; }
        }
    }
}
