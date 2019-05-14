using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minbiztositas01
{
    class Program
    {
        static void Main(string[] args)
        {
            int final_cost = 0;
            try
            {
                Import import = new Import();
                Route_Planner route_planner = new Route_Planner();
                string path = @"C:\Users\Peti\Desktop\route.txt";
                int trip_length = 0;
                int fuel_capacity = 0;
                int station_number = 0;
                if (import.Data_Importer(path, ref trip_length, ref station_number, ref fuel_capacity) == 0)
                {
                    Console.WriteLine("Alap adatok beolvasva");
                }
                else
                {
                    throw new Exception();
                }
                int[,] stations = new int[station_number + 1, 2];
                if (import.Station_Importer(path, station_number, ref stations, trip_length) == 0)
                {
                    Console.WriteLine("Kutak beolvasva");
                }
                else
                {
                    throw new Exception();
                }
                final_cost = route_planner.Planner(stations, station_number, trip_length, fuel_capacity);
            }
            catch (Exception)
            {
                Console.WriteLine("Hiba történt");
            }
            finally
            {
                Console.WriteLine("az út költsége: "+final_cost);
                Console.ReadLine();
            }
        }
    }
}
