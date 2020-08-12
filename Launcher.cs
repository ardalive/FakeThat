using System;

namespace FakeThat
{
    class Launcher
    {
        string language;
        int repeats;
        double messRate;
        public Launcher(string[] args) {
            ParseLanguage(args);
            ParseRepeats(args);
            ParseMessRate(args);
        }
        public void Go() 
        {
            var ldl = new LocaleDataLoader(language);
            var locale = Delegate(language, ldl);
            Repeat(locale, repeats, messRate, ldl);
        }
        private void ParseLanguage(string[] args) 
        {
            if (args.Length < 2) throw new Exception("At least 2 arguments are required");
            language = args[0];
            if(language != "be_BY" && language != "ru_RU" && language != "en_US")
                throw new Exception("Supported locales are: en_US, ru_RU, be_BY");
        }
        private void ParseRepeats(string[] args)
        {
                if (!Int32.TryParse(args[1], out repeats))
                    throw new Exception("Amount of output logs is required");
        }
        private void ParseMessRate(string[] args)
        {
            if (args.Length < 3 || !Double.TryParse(args[2], out messRate)) messRate = 0;
        }
        private DefaultLocale Delegate(string lang, LocaleDataLoader ldl) 
        {
            if      (lang == "be_BY") { return new LocaleBy(lang, ldl); }
            else if (lang == "ru_RU") { return new LocaleRu(lang, ldl); }
            else                      { return new LocaleEn(lang, ldl); }
        }
        private void Repeat(DefaultLocale locale, int repeats, double messRate, LocaleDataLoader ldl) 
        {
            for (var i = 0; i < repeats; i++) 
            {
                Console.WriteLine(MessUp.DoMess(locale.GenerateLog(), ldl.data.Alphabet, messRate));
            }
        }
        //static string ConsoleLang() 
        //{
        //    Console.WriteLine("Please specify output language. Currently we support: en_US, ru_RU, be_BY. English by default.");
        //    string language = Console.ReadLine();
        //    return (language == "be_BY" || language == "ru_RU" || language == "en_US") ? language : "en_US";
        //}
        //static int ConsoleRepeats() 
        //{
        //    Console.WriteLine("How many logs do you want to generate?");
        //    int repeats;
        //    if (Int32.TryParse(Console.ReadLine(), out repeats)) { return repeats; }
        //    else return 1;
        //}
        //static double ConsoleMessRate() {
        //    Console.WriteLine("Would you like to specify deviation rate? Default value: 0");
        //    double messRate;
        //    if (Double.TryParse(Console.ReadLine(), out messRate)) { return messRate; }
        //    else return 0;
        //}
    }
}
