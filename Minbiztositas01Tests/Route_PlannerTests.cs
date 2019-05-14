using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minbiztositas01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minbiztositas01.Tests
{
    [TestClass()]
    public class Route_PlannerTests
    {
        public Route_Planner route_planner = new Route_Planner();
        public int[,] stations = new int[4, 2];
        
        [TestMethod()]
        public void PlannerTest()
        {
            stations[0, 0] = 20;
            stations[0, 1] = 100;
            stations[1, 0] = 30;
            stations[1, 1] = 10;
            stations[2, 0] = 50;
            stations[2, 1] = 60;
            stations[3, 0] = 70;
            stations[3, 1] = 70;

            Assert.AreEqual(1500, route_planner.Planner(stations, 4, 100, 50));
        }

        [TestMethod()]
        public void Last_Available_StationTest()
        {
            stations[0, 0] = 20;
            stations[0, 1] = 100;
            stations[1, 0] = 30;
            stations[1, 1] = 10;
            stations[2, 0] = 50;
            stations[2, 1] = 60;
            stations[3, 0] = 70;
            stations[3, 1] = 70;

            Assert.AreEqual(1, route_planner.Last_Available_Station(4, stations, 0, 50, 0));
            Assert.AreEqual(2, route_planner.Last_Available_Station(4, stations, 2, 50, 30));
        }

        [TestMethod()]
        public void Full_or_MinTest()
        {
            Assert.AreEqual(0, route_planner.Full_or_Min(10, 15));
            Assert.AreEqual(1, route_planner.Full_or_Min(15, 10));
            Assert.AreEqual(1, route_planner.Full_or_Min(15, 15));
        }
    }
}