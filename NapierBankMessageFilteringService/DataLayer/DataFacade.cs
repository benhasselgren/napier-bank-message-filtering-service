using Microsoft.VisualBasic.FileIO;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace DataLayer
{
    /// <summary>
    /// Class <c>DataFacade</c> 
    /// A facade that the business layer can communicate with to create, load and save messages
    /// </summary>
    public class DataFacade : IDataFacade
    {
        // ------------------ Methods ------------------
        /// <summary>
        /// Method <c>loadMessages</c> 
        /// Loads messages from a file
        /// </summary>
        public List<string> loadData(string file)
        {
            List<string> data = new List<string>();

            using (StreamReader sr = new StreamReader(@file))
            {
                string currentLine;
                // currentLine will be null when the StreamReader reaches the end of file
                while ((currentLine = sr.ReadLine()) != null)
                {
                    data.Add(currentLine);
                }
            }
            return data;
        }

        /// <summary>
        /// Method <c>createMessage</c> 
        /// Creates a message from user input
        /// </summary>
        public void saveData(IList<Message> processedMessages, string filepath)
        {
            string json = JsonConvert.SerializeObject(processedMessages.ToArray());

            //write string to file
            string file = filepath + "\\processed-messages.txt";

            System.IO.File.WriteAllText(@file, json);
        }

        /// <summary>
        /// Method <c>saveMessage</c> 
        /// Saves processed messaged to a json file
        /// </summary>
        public void loadAbbreviations(IList<Abbreviation> abbreviations)
        {
            //Get abbreviations file path
            string path = @"C:\\Users\\Ben Hasselgren\\source\\repos\\benhasselgren\\napier-bank-message-filtering-service\\NapierBankMessageFilteringService\\DataLayer\\Data\\abbreviations.csv";

            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        //Create new abbreviation
                        Abbreviation a = new Abbreviation();
                        a.Abbrv = fields[0];
                        a.Translation = fields[1];

                        //Add it to abbreviations list
                        abbreviations.Add(a);
                    }
                }
            }
        }
    }
}
