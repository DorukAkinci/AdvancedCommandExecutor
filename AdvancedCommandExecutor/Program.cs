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
            string _operation = "";
            List<string> _output = new List<string>();

            if (args.Count() == 0)
            {
                Console.WriteLine("Default Command is set: AdvancedCommandExecutor --perm \"echo {TEST|DEMO} {1|2}!\"");
                Console.WriteLine("Also you can use --sequential operation.");
                _input = "echo {TEST|DEMO} {1|2}!";
            }
            else
            {
                _operation = args[0];
                _input = args[1];
            }

            switch (_operation)
            {
                case "--sequential":
                case "-sequential":
                case "--seq":
                case "-seq":
                case "--s":
                case "-s":
                    _output = Spintax.CreateSequentialList(_input);
                    break;

                case "--permutation":
                case "-permutation":
                case "--perm":
                case "-perm":
                case "--p":
                case "-p":
                    _output = Spintax.CreateAllPossiblePermutations(_input);
                    break;

                default:
                    Console.WriteLine("Default operation --permutation is selected.");
                    _output = Spintax.CreateAllPossiblePermutations(_input);
                    break;
            }


            PrintList(_output);
            Console.WriteLine("These commands will be executed. Do you want to start the processes.(y/n)");

            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                foreach (var _cmd in _output)
                    StartTheProcess(_cmd);
            }
        }
    }
}
