// Simulink3
// TSimClassLib
// Class2.cs
// ---------------------------------------------
// Alex Samarkin
// Alex
// 
// 5:20 09 04 2022

using System.ComponentModel;

namespace TSimClassLib
{
    public class TConnector : TDescription, TBlockInterface
    {
        [Category("Block"), Description("Port from"), DefaultValue("")]
        [DisplayName("Порт-источник")]
        [NotifyParentProperty(true)]
        public TPort SourcePort { get; set; }=null;
        [Category("Block"), Description("Port from"), DefaultValue("")]
        [DisplayName("Порт-приемник")]
        [NotifyParentProperty(true)]
        public TPort DestinationPort { get; set; }=null;

        public double InValue { get=>SourcePort.Value; set=>SourcePort.Value=value; }
        public double OutValue { get => DestinationPort.Value; set => DestinationPort.Value = value; }
        public string InLabel { get => SourcePort.Label; set => SourcePort.Label = value; }
        public string OutLabel { get => DestinationPort.Label; set => DestinationPort.Label = value; }

        public void AddInValue(double value = 0, string label = null)
        {
            SourcePort.Add(value,label);
        }
        public void AddOutValue(double value = 0, string label = null)
        {
            DestinationPort.Add(value, label);
        }

    }
}