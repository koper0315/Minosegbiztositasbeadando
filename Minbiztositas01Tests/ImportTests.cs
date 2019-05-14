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
    public class ImportTests
    {
        public string path;
        public int trip_length;
        public int fuel_capacity;
        public int station_number;
        public int[,] stations = new int[4, 2];
        public Import import=new Import();

        [TestMethod()]
        public void Data_ImporterTest()
        {
            path= @"C:\Users\Peti\Desktop\route.txt";
            Assert.AreEqual(0, import.Data_Importer(path, ref trip_length, ref station_number, ref fuel_capacity));

            path = @"C:\Users\Peti\Desktop\hiba.txt";
            Assert.AreEqual(-1, import.Data_Importer(path, ref trip_length, ref station_number, ref fuel_capacity));
        }

        [TestMethod()]
        public void Station_ImporterTest()
        {
            path = @"C:\Users\Peti\Desktop\route.txt";
            Assert.AreEqual(0, import.Station_Importer(path, station_number, ref stations, trip_length));

            path = @"C:\Users\Peti\Desktop\hiba.txt";
            Assert.AreEqual(-1, import.Station_Importer(path, station_number, ref stations, trip_length));
        }
    }
}