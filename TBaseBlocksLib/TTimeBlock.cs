// Simulink3
// TBaseBlocksLib
// TTimeBlock.cs
// ---------------------------------------------
// Alex Samarkin
// Alex
// 
// 20:15 10 04 2022

using System;
using System.Collections.Generic;
using TSimClassLib;

namespace TBaseBlocksLib
{
    public class TTimeBlock : TBlockWithPorts
    {
        public List<double> SimTime { get; set; } = null;

        #region Overrides of TBlockWithPorts

        public override void Init()
        {
            base.Init();
            SimTime = PortsOUT.TimePort.Data ?? new List<double>();
        }

        public override void Reset()
        {
            base.Reset();
            SimTime = PortsOUT.TimePort.Data ?? new List<double>();
        }

        public override void Run()
         {
            Console.WriteLine("Run TTime block");
            base.Run();
            TSimTimer t = null;
            if (Owner != null)
            {
                t = Owner.SimTimer ?? (new TSimTimer());
            }
            else
            {
                t = new TSimTimer();
            }
            SimTime.Add(t.CurrentTime);
            Console.WriteLine($"Append new time {SimTime[SimTime.Count-1]}");
        }

        public override void ToConsole()
        {
            base.ToConsole();
        }

        #endregion
    }
}