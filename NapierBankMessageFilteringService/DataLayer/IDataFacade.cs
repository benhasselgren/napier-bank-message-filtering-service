using Models;
using System.Collections.Generic;

namespace DataLayer
{
    /// <summary>
    /// Interface <c>IDataFacade</c> 
    /// An interface for DataFacade
    /// </summary>
    public interface IDataFacade
    {
        public void loadData(string file);
        public void saveData(List<Message> processedMessages);
        public void loadAbbreviations(List<Abbreviation> abbreviations);
    }
}
