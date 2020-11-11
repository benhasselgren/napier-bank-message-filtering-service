using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Classes
{
    /// <summary>
    /// Class <c>FileSingleton</c> 
    /// A singleton class that stores an instance of a file location that needs to be read
    /// </summary>
    class FileSingleton
    {
        // ------------------ Instance Variables ------------------
        private string inputFile;

        // ------------------ Constructors ------------------
        /// <summary>
        /// Constructor <c>Empty</c> 
        /// A constrcutor that takes no input
        /// </summary>
        public FileSingleton()
        {
        }

        /// <summary>
        /// Constructor <c>inputFile</c> 
        /// A constrcutor that takes an input file
        /// </summary>
        public FileSingleton(string inputFile)
        {
            this.inputFile = inputFile;
        }

        // ------------------ Getters/Setters ------------------
        public string InputFile { get => inputFile; set => inputFile = value; }
    }
}
