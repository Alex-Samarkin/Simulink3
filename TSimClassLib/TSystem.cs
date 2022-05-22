// Simulink3
// TSimClassLib
// TSystem.cs
// ---------------------------------------------
// Alex Samarkin
// Alex
// 
// 2:54 09 04 2022

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TSimClassLib
{
    public class TSystem : TTitle
    {
        public TSimTimer SimTimer { get; set; } = new TSimTimer();

        public List<TBlock> Blocks { get; set; } = new List<TBlock>();

        public List<TConnector> Connectors { get; set; } = new List<TConnector>();

        public void AddBlock(TBlock block)
        {
            block.Id = Blocks.Count;
            block.Owner = this;
            Blocks.Add(block);
        }

        public void RunBlocks()
        {
            Console.WriteLine("Run blocks");
            foreach (var block in Blocks)
            {
                block.Run();
            }
        }

        public void ExchangeData()
        {
            Console.WriteLine("Exchange data between blocks");
        }

        public void NextTime()
        {
            Console.WriteLine("Inc time for next step");
            SimTimer.Inc();
            Console.WriteLine($"Current timer is {SimTimer}");
        }

        public void Step()
        {
            RunBlocks();
            ExchangeData();
            NextTime();
        }

        public void RunAll()
        {
            while (!SimTimer.ItsEndTime)
            {
                Step();
            }

            Console.WriteLine("Thats all");
        }

    }
}