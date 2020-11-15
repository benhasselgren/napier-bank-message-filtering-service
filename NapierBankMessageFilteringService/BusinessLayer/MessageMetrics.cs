using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    /// <summary>
    /// Class <c>MessageMetrics</c> 
    /// A class that contains all the metrics for messages
    /// </summary>
    public class MessageMetrics : IMessageMetrics
    {
        // ------------------ Constructor ------------------
        public MessageMetrics()
        {
            Hashtags = new List<Hashtag>();
            Mentions = new List<Mention>();
            Sirs = new List<Sir>(); ;
        }

        // ------------------ Properties ------------------
        public IList<Hashtag> Hashtags { get; set; }
        public IList<Mention> Mentions { get; set; }
        public IList<Sir> Sirs { get; set; }

        // ------------------ Methods ------------------
        /// <summary>
        /// Method <c>addHashtag</c> 
        /// Adds a hashtag to hashtags list
        /// </summary>
        public void addHashtag(string title)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method <c>addMention</c> 
        /// Adds a mention to mentions list
        /// </summary>
        public void addMention(string mention)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method <c>addSir</c> 
        /// Adds a sir to sirs list
        /// </summary>
        public void addSir(string sortCode, string natureOfIncident)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method <c>getHashtags</c> 
        /// returns a list of hashtags
        /// </summary>
        public List<Hashtag> getHashtags()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method <c>getMentions</c> 
        /// returns a list of mentions
        /// </summary>
        public List<Mention> getMentions()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method <c>getSirs</c> 
        /// returns a list of sirs
        /// </summary>
        public List<Sir> getSirs()
        {
            throw new NotImplementedException();
        }
    }
}
