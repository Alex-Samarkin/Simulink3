// Simulink3
// TSimClassLib
// TBlockWithPort.cs
// ---------------------------------------------
// Alex Samarkin
// Alex
// 
// 5:15 09 04 2022

namespace TSimClassLib
{
    public class TBlockWithPorts:TBlock,TBlockInterface
    {
        public TPortsGroup PortsIN { get; set; } = new TPortsGroup();
        public TPortsGroup PortsOUT { get; set; } = new TPortsGroup();
        public TPortsGroup PortsParam { get; set; } = new TPortsGroup();
        public TPortsGroup PortsTemporaryData { get; set; } = new TPortsGroup();

        #region Implementation of TBlockInterface

        public void Init()
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public void Run()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}