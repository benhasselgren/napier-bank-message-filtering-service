using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    /// <summary>
    /// Class <c>MessageMetrics</c> 
    /// A class that contains all the metrics for messages
    /// </summary>
    public class MessageMetrics : IMessageMetrics
    {
        // ------------------ Properties ------------------
        public IList<Hashtag> Hashtags { get; set; }
        public IList<Mention> Mentions { get; set; }
        public IList<Sir> Sirs { get; set; }
        public IList<Url> QuarantineList { get; set; }

        // ------------------ Constructor ------------------
        public MessageMetrics()
        {
            Hashtags = new List<Hashtag>();
            Mentions = new List<Mention>();
            QuarantineList = new List<Url>();
            Sirs = new List<Sir>(); ;
        }


        // ------------------ Methods ------------------
        /// <summary>
        /// Method <c>addHashtag</c> 
        /// Adds a hashtag to hashtags list
        /// </summary>
        public void addHashtag(string title)
        {
            var hashtag = Hashtags.FirstOrDefault(hashtag => hashtag.Title == title);

            if(hashtag != null)
            {
                //If hashtag already exists then increment hashtag count by 1
                hashtag.Count++;
            }
            else
            {
                //Create a new hasthtag, set title, set count to 0 and add to hashtags list
                Hashtag ht = new Hashtag();
                ht.Title = title;
                ht.Count = 1;
                Hashtags.Add(ht);
            }
        }

        /// <summary>
        /// Method <c>addMention</c> 
        /// Adds a mention to mentions list
        /// </summary>
        public void addMention(string mention)
        {
            //Create new mention and set username
            Mention m = new Mention();
            m.Username = mention;

            //Add mention to list
            this.Mentions.Add(m);
        }

        /// <summary>
        /// Method <c>addSir</c> 
        /// Adds a sir to sirs list
        /// </summary>
        public void addSir(string sortCode, string natureOfIncident)
        {
            //Create new sir and add it to sirs list
            Sir s = new Sir();
            s.SortCode = sortCode;
            s.NatureOfIncident = natureOfIncident;
            Sirs.Add(s);
        }

        /// <summary>
        /// Method <c>addUrl</c> 
        /// Adds a sir to sirs list
        /// </summary>
        public void addUrl(string address)
        {
            //Create new url and it to quarantine list
            Url u = new Url();
            u.Address = address;
            QuarantineList.Add(u);
        }

        /// <summary>
        /// Method <c>getHashtags</c> 
        /// returns a list of hashtags
        /// </summary>
        public IList<Hashtag> getHashtags()
        {
            //Sort the list by descending order
            Hashtags.OrderByDescending(x => x.Count);
            return Hashtags;
        }

        /// <summary>
        /// Method <c>getMentions</c> 
        /// returns a list of mentions
        /// </summary>
        public IList<Mention> getMentions()
        {
            return Mentions;
        }

        /// <summary>
        /// Method <c>getSirs</c> 
        /// returns a list of sirs
        /// </summary>
        public IList<Sir> getSirs()
        {
            return Sirs;
        }

        /// <summary>
        /// Method <c>getQuarantineList</c> 
        /// returns a list of sirs
        /// </summary>
        public IList<Url> getQuarantineList()
        {
            return QuarantineList;
        }
    }
}
