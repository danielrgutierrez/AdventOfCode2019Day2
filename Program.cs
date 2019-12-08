using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019Day2
{
    enum OpCode { Add = 1, Multiply = 2, End = 99 }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new List<int>();
            try
            {
                using (StreamReader sr = new StreamReader("input.txt"))
                {
                    string strProgram;
                    while ((strProgram = sr.ReadLine()) != null)
                    {
                        input = strProgram.Split(',').Select(int.Parse).ToList();
                    }

                    RestoreProgramState(ref input);
                    ProcessIntCodeProgram(ref input);
                    Console.WriteLine($"Part 1: The value left at position 0 is {input[0]}.");
                }
            }
            catch (IOException e)
            {
                Console.Write($"Error reading the file: {e.Message}");
            }
        }

        static void ProcessIntCodeProgram(ref List<int> program)
        {
            var index = 0;
            var programFinished = false;
            while (index < program.Count && !programFinished)
            {
                switch ((OpCode)program[index])
                {
                    case OpCode.Add:
                        program[program[index + 3]] = program[program[index + 1]] + program[program[index + 2]];
                        break;
                    case OpCode.Multiply:
                        program[program[index + 3]] = program[program[index + 1]] * program[program[index + 2]];
                        break;
                    case OpCode.End:
                    default:
                        programFinished = true;
                        break;
                }
                index += 4;
            }
        }

        static void PrintIntCodeProgram(List<int> program)
        {
            for (int i = 0; i < program.Count; i++)
            {
                if (i > 0 && i % 4 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write($"{program[i]},");
            }
        }

        static void RestoreProgramState(ref List<int> program)
        {
            // before running the program, replace position 1 with the value 12 and replace position 2 with the value 2.
            program[1] = 12;
            program[2] = 2;
        }
    }
}
