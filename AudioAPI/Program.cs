using AudioAPIConsole;
using System;
using System.Linq;

namespace AudioAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Audio API Test Console");
               
        }

        private static void InsertDataToDb()
        {
            var data = DummyData.GetData(10).ToList();

            // Add call to AudioService to insert dummy data
        }
    }
}
