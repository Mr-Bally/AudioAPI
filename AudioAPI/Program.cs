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

            var data = DummyData.GetData(10).ToList();

            data.ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
}
