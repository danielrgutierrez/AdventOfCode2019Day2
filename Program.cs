using System;
using System.Collections.Generic;

namespace AdventOfCode2019Day2
{
    enum OpCode { Add = 1, Multiply = 2, End = 99 }

    class Program
    {
        static void Main(string[] args)
        {

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
    }
}
