// Simulink3
// TSimClassLib
// TBlock.cs
// ---------------------------------------------
// Alex Samarkin
// Alex
// 
// 3:04 09 04 2022

using System;
using System.ComponentModel;
using System.Diagnostics;

namespace TSimClassLib
{
    public class TBlock : TTitle,TBlockInterface
    {
        [Category("TSystem"), Description("Parent system"), DefaultValue("")]
        [DisplayName("Исходная модель")]
        [NotifyParentProperty(true)]
        public TSystem Owner { get; set; } = null;

        #region Implementation of TBlockInterface

        public void Init()
        {
            Console.WriteLine($"Init block {((TTitle)this).ToString()}");
        }

        public void Reset()
        {
            Console.WriteLine($"Reset block {((TTitle)this).ToString()}");
        }

        public void Run()
        {
            if (Owner!=null)
            {
                Console.WriteLine($"Run block {((TTitle)this).ToString()}");
                Console.WriteLine($"Into system {Owner.ToString()} by Time {Owner.SimTimer.CurrentTime}");
                return;
            }
            Console.WriteLine("No systemes");
        }

        #endregion
    }
}