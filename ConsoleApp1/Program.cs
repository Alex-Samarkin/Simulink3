using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBaseBlocksLib;
using TSimClassLib;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Test1
            /*
            TTitle t = new TTitle();
            Console.WriteLine(t.ToString());
            TDescription d = new TDescription();
            Console.WriteLine(d);
            TSimTimer simt = new TSimTimer();
            simt.End = 6;
            Console.WriteLine(simt);

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine($"{i} {simt.CurrentTime} {simt.Num}");
                simt.Inc();
            }

            TSystem ts = new TSystem();
            TBlock bl = new TBlock();

            bl.Init();
            bl.Reset();
            bl.Run();
            ts.AddBlock(bl);
            bl.Run();
            ts.AddBlock(new TBlock());
            ts.AddBlock(new TBlock());

            ts.RunBlocks();

            ts.SimTimer.Reset();

            ts.RunAll();
            */
            #endregion

            #region Test2

            TConstBlock cb = new TConstBlock();  
            cb.Init();
            cb.SetParams(15);
            cb.Reset();
            for (int i = 0; i < 1000; i++)
            {
                cb.Run();
            }

            cb.ToConsole();

            TMultiConstBlock mcb = new TMultiConstBlock();
            mcb.Init();
            mcb.SetParams(new List<double>(){10,15,25});
            mcb.PortsParam.X = 100;
            mcb.Run();

            mcb.ToConsole();

            TTimeBlock t = new TTimeBlock();

            t.Init();
            t.SetParams();
            t.Reset();
           // t.Run();
           // t.Run();

            TSystem s = new TSystem();

            s.AddBlock(cb);
            s.AddBlock(mcb);
            s.AddBlock(t);

            s.RunAll();

            #endregion
            Console.ReadLine();
        }
    }
}
