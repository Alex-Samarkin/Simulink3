// Simulink3
// TSimClassLib
// TBlockWithPort.cs
// ---------------------------------------------
// Alex Samarkin
// Alex
// 
// 5:15 09 04 2022

using System;

namespace TSimClassLib
{
    public class TBlockWithPorts:TBlock,TBlockInterface
    {
        public TPortsGroup PortsIN { get; set; } = new TPortsGroup();
        public TPortsGroup PortsOUT { get; set; } = new TPortsGroup();
        public TPortsGroup PortsParam { get; set; } = new TPortsGroup();
        public TPortsGroup PortsTemporaryData { get; set; } = new TPortsGroup();

        #region Implementation of TBlockInterface

        public override void Init()
        {
            PortsIN.ClearData();
            PortsOUT.ClearData();
            PortsParam.ClearData();
            PortsTemporaryData.ClearData();
            
            // throw new System.NotImplementedException();
            Console.WriteLine($"Init BlockWithPorts, {(TTitle)this}");
        }

        public override void Reset()
        {
            PortsIN.ClearData();
            PortsOUT.ClearData();
            PortsParam.ClearData();
            PortsTemporaryData.ClearData();

            // throw new System.NotImplementedException();
            Console.WriteLine($"Reset BlockWithPorts, {(TTitle)this}");
        }

        public override void Run()
        {
            // throw new System.NotImplementedException();
            Console.WriteLine($"Run BlockWithPorts, {(TTitle)this}");
        }

        #endregion

        public virtual void ToConsole()
        {
            Console.WriteLine((TTitle)this);
            Console.WriteLine("---------------------");
            PortsIN.ToConsole();
            PortsOUT.ToConsole();
            PortsParam.ToConsole();
            PortsTemporaryData.ToConsole();
        }
    }
}