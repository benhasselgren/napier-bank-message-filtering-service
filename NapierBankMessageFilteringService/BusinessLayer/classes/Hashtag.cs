using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Classes
{
    /// <summary>
    /// Class <c>Hashtag</c> 
    /// A class that outlines a hashtag
    /// </summary>
    class Hashtag
    {
        // ------------------ Instance Variables ------------------
        private string title;
        private int count;

        // ------------------ Constructors ------------------
        /// <summary>
        /// Constructor <c>title</c> 
        /// </summary>
        public Hashtag(string title)
        {
            this.title = title;
            this.count = 1;
        }

        // ------------------ Getters/Setters ------------------
        public string Title { get => title; set => title = value; }
        public int Count { get => count; set => count = value; }

        // ------------------ Methods ------------------
        /// <summary>
        /// Method <c>incrementCount</c> 
        /// Increases count by 1
        /// </summary>
        public void incrementCount()
        {
            this.Count++;
        }
    }
}
