using AudioAPIConsole;
using DAL;
using System;

namespace AudioAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Audio API Test Console");

            var dummyData = new DummyData(new AudioService(new AudioRepository()));
            dummyData.PopulateTable(1);
        }
    }
}
