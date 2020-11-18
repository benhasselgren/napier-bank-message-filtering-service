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
            if (!title.Equals(""))
            {
                var hashtag = Hashtags.FirstOrDefault(hashtag => hashtag.Title == title);

                if (hashtag != null)
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
            else
            {
                throw new Exception("Empty hashtag string");
            }
        }

        /// <summary>
        /// Method <c>addMention</c> 
        /// Adds a mention to mentions list
        /// </summary>
        public void addMention(string mention)
        {
            if(!mention.Equals(""))
            {
                //Create new mention and set username
                Mention m = new Mention();
                m.Username = mention;

                //Add mention to list
                this.Mentions.Add(m);
            }
            else
            {
                throw new Exception("Empty mention string");
            }
        }

        /// <summary>
        /// Method <c>addSir</c> 
        /// Adds a sir to sirs list
        /// </summary>
        public void addSir(string sortCode, string natureOfIncident)
        {
            if(!sortCode.Equals("") || !natureOfIncident.Equals(""))
            {
                //Create new sir and add it to sirs list
                Sir s = new Sir();
                s.SortCode = sortCode;
                s.NatureOfIncident = natureOfIncident;
                Sirs.Add(s);
            }
            else
            {
                throw new Exception("Empty sortcode or noi");
            } 
        }

        /// <summary>
        /// Method <c>addUrl</c> 
        /// Adds a sir to sirs list
        /// </summary>
        public void addUrl(string address)
        {
            if(!address.Equals(""))
            {
                //Create new url and it to quarantine list
                Url u = new Url();
                u.Address = address;
                QuarantineList.Add(u);
            }
            else
            {
                throw new Exception("Empty url string");
            }
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

        public void addMetrics(IMessageMetrics metrics)
        {
            foreach (var sir in metrics.getSirs()) Sirs.Add(sir);
            foreach (var mention in metrics.getMentions()) Mentions.Add(mention);
            foreach (var quarintine in metrics.getQuarantineList()) QuarantineList.Add(quarintine);
            foreach (var hashtag in metrics.getHashtags()) addHashtag(hashtag.Title);
        }
        public void reset()
        {
            Sirs.Clear();
            Mentions.Clear();
            QuarantineList.Clear();
            Hashtags.Clear();
        }
    }
}
