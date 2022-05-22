// Simulink3
// TBaseBlocksLib
// TMultiConst.cs
// ---------------------------------------------
// Alex Samarkin
// Alex
// 
// 18:42 10 04 2022

using System;
using System.Collections.Generic;
using System.ComponentModel;
using TSimClassLib;

namespace TBaseBlocksLib
{
    public class TMultiConstBlock : TBlockWithPorts
    {
        [Category("Property"), Description("Count of const"), DefaultValue("0")]
        [DisplayName("Число констант")]
        [NotifyParentProperty(true)]
        public int CountOfConst {
            get
            {
                return PortsParam.Ports.Count;
            }
            set
            {
                if (value<CountOfConst&&value>5)
                {
                    PortsParam.Ports.RemoveRange(value,CountOfConst-value-1);
                }
            }
            }

        public virtual void SetParams(List<double> param_list = null, List<string> param_labels = null)
        {
            var pl = param_list ?? new List<double>() { 0, 1, 2, 3 };
            var plb = param_labels ?? new List<string>();

            while (pl.Count<4)
            {
                pl.Add(0);
            }

            if (pl.Count>plb.Count)
            {
                for (int i = plb.Count; i < pl.Count; i++)
                {
                    plb.Add($"{i} {pl[i]}");
                }
            }

            CountOfConst = pl.Count;
            PortsParam.ClearData();

            int j = 0;
            foreach (TPort paramPort in PortsParam.Ports)
            {
                paramPort.Add(pl[j],plb[j]);
                j++;
            }
        }

        public override void Init()
        {
            base.Init();

            Title = "Multiconstant block";
        }

        public override void Reset()
        {
            base.Reset();
        }

        public override void Run()
        {
            Console.WriteLine("Run multiconst block");
            for (int i = 0; i < CountOfConst; i++)
            {
                double d = PortsParam.Ports[i].Value;
                string l = PortsParam.Ports[i].Label;
                PortsOUT.Ports[i].Add(d,l);
            }
        }
    }
}