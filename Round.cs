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
        List<uint> Items { get; set; }

        /// <summary>
        /// Разбирает бюллетень по голосам
        /// </summary>
        /// <param name="line"></param>
        public Round(string line) {

            var voites = line.Split();

            Items = MakePenltiesMap(voites);
        }

        List<uint> MakePenltiesMap(string[] numbers)
        {
            var penalties = new List<uint>();
            foreach(var number in numbers)
            {
                if(uint.TryParse(number, out uint penalty) && penalty != 0)
                {
                    uint penaltyVal = (uint)Math.Abs(penalty);
                    penalties.Add(penaltyVal);
                    continue;
                }

                //Учитывается только правильный бюллетень
                penalties.Clear();
            }

            return penalties;
        }

        public IEnumerable<Candidate> ComposeRound(List<Candidate> candidates)
        {
            int index = 0;
            foreach (var candidate in candidates)
            {
                //Учитывается только правильный бюллетень
                if (Items.Count != candidates.Count)
                    continue;

                candidate.AddPenaltes(Items[index++]);
                yield return candidate;
            }
        }
    }
}
