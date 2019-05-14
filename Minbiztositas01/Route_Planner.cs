using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minbiztositas01
{
    public class Route_Planner
    {
        //A fő metódus, ez adja vissza a végső költséget
        public int Planner(int[,] stations, int station_number, int trip_length, int fuel_capacity)
        {
            //kezdő pozíció
            int actual_position = 0;
            int actual_price = 0;
            int actual_fuel = fuel_capacity;
            int final_cost = 0;
            //segédváltozók
            int lowest_price = 0;
            int lowest_price_station = 0;
            int lowest_price_station_id = 0;
            int fuel = 0;
            for (int i = 0; i < station_number; i++)
            {
                lowest_price_station_id = Last_Available_Station(station_number, stations, i, fuel_capacity, actual_position);
                lowest_price_station = stations[lowest_price_station_id, 0];
                lowest_price = stations[lowest_price_station_id, 1];
                i = lowest_price_station_id;
                if (Full_or_Min(actual_price, lowest_price) == 0)
                {
                    fuel = (fuel_capacity - actual_fuel);
                    final_cost = final_cost + (fuel * actual_price);
                    actual_fuel = fuel_capacity - (lowest_price_station - actual_position);
                    actual_position = lowest_price_station;
                    actual_price = lowest_price;
                }
                else
                {
                    fuel = (lowest_price_station - actual_position - actual_fuel);
                    final_cost = final_cost + (fuel * actual_price);
                    actual_fuel = (actual_fuel + fuel) - (lowest_price_station - actual_position);
                    actual_position = lowest_price_station;
                    actual_price = lowest_price;
                }
            }
            return final_cost;
        }

        //megkeresi a következő kutat
        public int Last_Available_Station(int station_number, int[,] stations, int i, int fuel_capacity, int actual_position)
        {
            int lowest_price_station = stations[i, 0];
            int lowest_price = stations[i, 1];
            int lowest_price_station_id = i;
            for (int j = i + 1; j < station_number; j++)
            {
                if ((stations[j, 0] - fuel_capacity) > actual_position)
                {
                    break;
                }
                if (stations[j, 1] <= lowest_price_station)
                {
                    lowest_price_station = stations[j, 0];
                    lowest_price = stations[j, 1];
                    lowest_price_station_id = j;
                }
            }
            return lowest_price_station_id;
        }

        //eldönti, hogy tele tankoljunk, vagy csak annyit, hogy elérjük a következő állomást
        public int Full_or_Min(int actual_price, int lowest_price)
        {
            if (actual_price < lowest_price)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
