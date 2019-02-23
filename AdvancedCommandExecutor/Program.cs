using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;


namespace AdvancedCommandExecutor
{
    class Program
    {
        static void PrintList(List<string> List)
        {
            foreach (var text in List)
                Console.WriteLine(text);
        }

        static void StartTheProcess(string cmd)
        {
            Process _proc = new Process();
            _proc.StartInfo.FileName = "cmd.exe";
            _proc.StartInfo.Arguments = "/k " + cmd;
            _proc.Start();
        }

        static void Main(string[] args)
        {
            string _input;
            if (args.Count() == 0)
                _input = "echo {TEST|DEMO} {1|2|3}!";
            else
                _input = args[0];

            List<string> _allPossiblePermutations = Spintax.CreateAllPossiblePermutations(_input);

            PrintList(_allPossiblePermutations);
            Console.WriteLine("All possible permutations are listed. Do you want to start the processes.(y/n)");

            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                foreach (var _cmd in _allPossiblePermutations)
                    StartTheProcess(_cmd);
            }
            Console.ReadKey();
        }
    }
}
