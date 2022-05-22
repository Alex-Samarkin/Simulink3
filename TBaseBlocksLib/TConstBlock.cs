// Simulink3
// TBaseBlocksLib
// TConstBlock.cs
// ---------------------------------------------
// Alex Samarkin
// Alex
// 
// 15:34 10 04 2022

using System;
using System.ComponentModel;
using TSimClassLib;

namespace TBaseBlocksLib
{
    public class TConstBlock : TBlockWithPorts
    {
        [Category("Property"), Description("Const"), DefaultValue("0")]
        [DisplayName("Порт Константа")]
        [NotifyParentProperty(true)]
        public TPort ConstPort { get; set; }
        [Category("Property"), Description("Const"), DefaultValue("0")]
        [DisplayName("Константа")]
        [NotifyParentProperty(true)]
        public double Value { get; set; }
        [Category("Property"), Description("Const Label"), DefaultValue("0")]
        [DisplayName("Метка константы")]
        [NotifyParentProperty(true)]
        public string Label { get; set; }

        public TConstBlock(TPort constPort = null, double newConst = default, double labelOfConst = default)
        {
            //ConstPort = constPort ?? throw new ArgumentNullException(nameof(constPort));
            //Const = newConst;
            //LabelOfConst = labelOfConst;

            ConstPort = PortsOUT.XPort;
            Value = ConstPort.Value;
            Label = ConstPort.Label;

            TTitle t = this;
            t.Title = "Const block";
            t.SubTitle = $"Value = {Value}";
            t.Author = "AIS";

        }

        #region Implementation of TBlockInterface

        public override void Init()
        {
            // throw new System.NotImplementedException();
            base.Init();
            /*
                PortsIN.ClearData();
                PortsOUT.ClearData();
                PortsParam.ClearData();
                PortsTemporaryData.ClearData();
            */
            
            Console.WriteLine($"Init Const Block, {(TTitle)this}");
        }

        #region Overrides of TBlock

        public void SetParams(double value=0, string label = "")
        {
            base.SetParams();

            Value = value;
            Label = label;
        }

        public override void SetParams()
        {
            base.SetParams();

            Value = default;
            Label = default;
        }

        #endregion

        public override void Reset()
        {
            //throw new System.NotImplementedException();
            base.Reset();
            /*
                PortsIN.ClearData();
                PortsOUT.ClearData();
                PortsParam.ClearData();
                PortsTemporaryData.ClearData();
            */

            Console.WriteLine($"Reset Const Block, {(TTitle)this}");
            double tmp = Value;
            string l = Label;
            
        }

        public override void Run()
        {
            // throw new System.NotImplementedException();
            Console.WriteLine($"Run Const Block, {(TTitle)this}");
            double c = Value;
            string l = Label;

            ConstPort.Add(c,l);

        }

        #endregion

    }
}