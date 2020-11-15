using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    /// <summary>
    /// Class <c>EmailMessage</c> 
    /// Inherits from ProcessedMessage 
    /// Outlines an Email message
    /// </summary>
    public class EmailMessage : Message
    {
        // ------------------ Properties ------------------
        public string MessageSubject { get; set; }    
        public string SortCode { get; set; }
        public string NatureOfIncident { get; set; }
    }
}
