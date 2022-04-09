// Simulink3
// TSimClassLib
// TPortsGroup.cs
// ---------------------------------------------
// Alex Samarkin
// Alex
// 
// 4:55 09 04 2022

using System.Collections.Generic;
using System.ComponentModel;

namespace TSimClassLib
{
    public class TPortsGroup : TDescription
    {
        [Category("Ports"), Description("Ports group"), DefaultValue("")]
        [DisplayName("Группа портов")]
        [NotifyParentProperty(true)]
        public List<TPort> Ports { get; set; } = new List<TPort>(){new TPort(), new TPort(), new TPort(), new TPort()};

        [Category("Ports"), Description("Port X"), DefaultValue("")]
        [DisplayName("Порт X")]
        [NotifyParentProperty(true)]
        public TPort XPort
        {
            get => Ports[1];
        }
        public TPort YPort
        {
            get => Ports[2];
        }
        public TPort ZPort
        {
            get => Ports[3];
        }
        public TPort TimePort
        {
            get => Ports[0];
        }

        public double X { get=>XPort.Value; set=>XPort.Value=value; }
        public double Y { get => YPort.Value; set => YPort.Value = value; }
        public double Z { get => ZPort.Value; set => ZPort.Value = value; }
        public double Time { get => TimePort.Value; set => TimePort.Value = value; }

        public string XLabel { get => XPort.Label; set => XPort.Label = value; }
        public string YLabel { get => YPort.Label; set => YPort.Label = value; }
        public string ZLabel { get => ZPort.Label; set => ZPort.Label = value; }
        public string TimeLabel { get => TimePort.Label; set => TimePort.Label = value; }

        public void AddX(double value = 0, string label = "")
        {
            XPort.Add(value,label??"");
        }
        public void AddY(double value = 0, string label = "")
        {
            YPort.Add(value, label ?? "");
        }
        public void AddZ(double value = 0, string label = "")
        {
            ZPort.Add(value, label ?? "");
        }
        public void AddTime(double value = 0, string label = "")
        {
            TimePort.Add(value, label ?? "");
        }


    }
}