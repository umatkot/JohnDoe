using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnDoe
{
    internal class Candidate
    {

        public string Name { get; set; }

        public string TotalPenaltyResult => $"{Name} has {Penalties} voites"; 

        /// <summary>
        /// Количество голосов кандидата
        /// </summary>
        private uint Penalties { get; set; }

        public Candidate(string name)
        {
            Name = name;
            Penalties = 0;
        }

        public void AddPenaltes(uint penalty) 
        {
            Penalties += penalty;
        }

        public override string ToString()
        {
            return $"{Name, 15} - {Penalties}".PadRight(30);
        }
    }
}
