using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JohnDoe
{
    internal class Round
    {
        List<int> Items { get; set; }

        /// <summary>
        /// Разбирает бюллетень по голосам
        /// </summary>
        /// <param name="line"></param>
        public Round(string line) {

            var voites = line.Split();

            Items = MakeVoitesMap(voites);
        }

        List<int> MakeVoitesMap(string[] numbers)
        {
            var voites = new List<int>();
            foreach(var number in numbers)
            {
                if(uint.TryParse(number, out var voite))
                {
                    int voiteVal = Math.Abs(Convert.ToInt32(number));
                    voites.Add(voiteVal);
                    continue;
                }

                //Учитывается только правильный бюллетень
                voites.Clear();
            }

            return voites;
        }

        public IEnumerable<Candidate> ComposeRound(List<Candidate> candidates)
        {
            int index = 0;
            foreach (var candidate in candidates)
            {
                //Учитывается только правильный бюллетень
                if (Items.Count != candidates.Count)
                    continue;

                candidate.AddVoites(Items[index++]);
                yield return candidate;
            }
        }
    }
}
