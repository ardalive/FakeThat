using System;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace FakeThat
{
    class LocaleDataLoader
    {
        private string lang;
        public Data data;

        public LocaleDataLoader(string l) 
        {
            this.lang = l;
            this.Loader();
        }
        public void Loader() 
        {
            using (StreamReader file = File.OpenText(@$"{GetProjectDirectory()}\\{this.lang}.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                this.data = (Data)serializer.Deserialize(file, typeof(Data));
            }
        }
        public string GetProjectDirectory() 
        {
            string s = Environment.CurrentDirectory;
            Regex regex = new Regex(@"^.+(FakeThat)");
            Match match = regex.Match(s);
            return match.ToString();
        }
    }
}
