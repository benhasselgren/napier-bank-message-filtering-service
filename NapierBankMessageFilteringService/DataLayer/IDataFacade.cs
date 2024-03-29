﻿using Models;
using System.Collections.Generic;

namespace DataLayer
{
    /// <summary>
    /// Interface <c>IDataFacade</c> 
    /// An interface for DataFacade
    /// </summary>
    public interface IDataFacade
    {
        public List<string> loadData(string file);
        public void saveData(IList<Message> processedMessages, string filename);
        public void loadAbbreviations(IList<Abbreviation> abbreviations);
    }
}
