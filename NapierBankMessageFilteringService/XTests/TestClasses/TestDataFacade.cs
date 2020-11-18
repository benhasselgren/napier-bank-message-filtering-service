using DataLayer;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XTests.TestClasses
{
    class TestDataFacade : IDataFacade
    {
        public void loadAbbreviations(IList<Abbreviation> abbreviations)
        {
            Abbreviation a1 = new Abbreviation();
            a1.Abbrv = "LOL";
            a1.Translation = "Laughing out loud";
            abbreviations.Add(a1);
            Abbreviation a2 = new Abbreviation();
            a2.Abbrv = "LTM";
            a2.Translation = "Laugh to myself";
            Abbreviation a3 = new Abbreviation();
            abbreviations.Add(a2);
            a3.Abbrv = "LYLAS";
            a3.Translation = "Love you like a sis";
            abbreviations.Add(a3);
        }

        public List<string> loadData(string file)
        {
            throw new NotImplementedException();
        }

        public void saveData(IList<Message> processedMessages, string filename)
        {
            throw new NotImplementedException();
        }

        public string saveData(IList<Message> processedMessages, string filename, string TESTMODE)
        {
            return JsonConvert.SerializeObject(processedMessages.ToArray());
        }
    }
}
