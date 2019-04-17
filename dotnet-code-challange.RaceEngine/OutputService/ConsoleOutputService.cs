using dotnet_code_challange.RaceEngine.Interface;
using dotnet_code_challange.RaceEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dotnet_code_challange.RaceEngine.OutputService
{
    public class ConsoleOutputService : IOutputService
    {
        /// <summary>
        /// Prints output in console
        /// </summary>
        /// <param name="output"></param>
        public void GenerateOutput(List<Horse> output)
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine($"                    Horse List");
            Console.WriteLine("-----------------------------------------------------------");
            
            foreach(var horse in output.OrderByDescending(h => h.Price))
            {
                Console.WriteLine($"  Name:  {horse.Name}\n  Price:  {horse.Price}\n  Jockey: {horse.Jockey}\n");
            }

            Console.WriteLine("\n\n");
        }
    }
}
