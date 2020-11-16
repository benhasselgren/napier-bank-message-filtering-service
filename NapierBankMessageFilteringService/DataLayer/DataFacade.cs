﻿using Microsoft.VisualBasic.FileIO;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

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
        public void loadData(string file)
        {

        }

        /// <summary>
        /// Method <c>createMessage</c> 
        /// Creates a message from user input
        /// </summary>
        public void saveData(List<Message> processedMessages)
        {

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
