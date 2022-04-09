// Simulink3
// TSimClassLib
// TPort.cs
// ---------------------------------------------
// Alex Samarkin
// Alex
// 
// 4:47 09 04 2022

using System.Collections.Generic;
using System.ComponentModel;

namespace TSimClassLib
{
    public class TPort : TDescription
    {
        [Category("Data"), Description("Data"), DefaultValue("0")]
        [DisplayName("Числовые данные")]
        [NotifyParentProperty(true)]
        public List<double> Data { get; set; } = new List<double>();

        [Category("Data"), Description("Labels"), DefaultValue("0")]
        [DisplayName("Текстовые данные")]
        [NotifyParentProperty(true)]
        public List<string> Labels { get; set; } = new List<string>();

        [Category("Block"), Description("Parent block"), DefaultValue("0")]
        [DisplayName("Блок, к которому относится порт")]
        [NotifyParentProperty(true)]
        public TBlock Owner { get; set; } = null;

        public double Value { get=>Data[Data.Count-1]; set=>Data[Data.Count-1]=Value; }
        public string Label { get => Labels[Labels.Count - 1]; set => Data[Labels.Count - 1] = Value; }

        public void Add(double value, string label = "")
        {
            Data.Add(value);
            Labels.Add(label);
        }

    }
}