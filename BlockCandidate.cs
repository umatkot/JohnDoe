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

        public string TotalVoitesResult => @"{Name} has {VoiteCnt} voites"; 

        /// <summary>
        /// Количество голосов кандидата
        /// </summary>
        private int VoiteCnt { get; set; }

        public Candidate(string name)
        {
            Name = name;
            VoiteCnt = 0;
        }

        public void AddVoites(int voites) 
        {
            VoiteCnt += voites;
        }

        public override string ToString()
        {
            return $"{Name} - {VoiteCnt}";
        }
    }
}
