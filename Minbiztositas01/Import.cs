using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Minbiztositas01
{
    public class Import
    {
        public int Data_Importer(string path, ref int trip_length, ref int station_number, ref int fuel_capacity)
        {
            try
            {
                FileStream file = new FileStream(path, FileMode.Open);
                StreamReader reader = new StreamReader(file);
                string[] data = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    data[i] = reader.ReadLine();
                }
                reader.Close();
                file.Close();
                trip_length = Convert.ToInt32(data[0]);
                fuel_capacity = Convert.ToInt32(data[1]);
                station_number = Convert.ToInt32(data[2]);
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Station_Importer(string path, int station_number, ref int[,] stations, int trip_length)
        {
            try
            {
                FileStream file = new FileStream(path, FileMode.Open);
                StreamReader reader = new StreamReader(file);
                SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
                List<string> list = new List<string>();
                while (!reader.EndOfStream)
                {
                    list.Add(reader.ReadLine());
                }
                reader.Close();
                file.Close();
                for (int i = 3; i < station_number + 3; i++)
                {
                    string[] cut = list[i].Split(' ');
                    dict.Add(Convert.ToInt32(cut[0]), Convert.ToInt32(cut[1]));
                }
                dict.Add(trip_length, 0);
                int j = 0;
                foreach (var kpv in dict)
                {
                    stations[j, 0] = kpv.Key;
                    stations[j, 1] = kpv.Value;
                    j++;
                }
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
