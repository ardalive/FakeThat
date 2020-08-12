using System;

namespace FakeThat
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Launcher launcher = new Launcher(args);
                launcher.Go();
            }
            catch(Exception e) {Console.WriteLine($"Catch в Main : {e.Message}"); }
        }
    }
}