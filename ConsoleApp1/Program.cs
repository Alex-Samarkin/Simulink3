using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TSimClassLib;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Console.ReadLine();
        }
    }
}
