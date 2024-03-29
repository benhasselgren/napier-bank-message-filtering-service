﻿using Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    /// <summary>
    /// Interface <c>IMessageMetrics</c> 
    /// An interface for MessageMetrics
    /// </summary>
    public interface IMessageMetrics
    {
        public void addHashtag(string title);
        public void addSir(string sortCode, string natureOfIncident);
        public void addMention(string mention);
        public void addUrl(string address);
        public IList<Sir> getSirs();
        public IList<Mention> getMentions();
        public IList<Hashtag> getHashtags();
        public IList<Url> getQuarantineList();
        public void addMetrics(IMessageMetrics messageMetrics);
        public void reset();
    }
}
