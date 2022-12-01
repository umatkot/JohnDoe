using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnDoe
{
    internal class TestBlock
    {
        public List<Candidate> Candidates { get; set; }
        uint CandidatesCount = 0;
        uint CurrentRoundIndex = 0;
        /// <summary>
        /// данный блок реализуется тоько благодаря содержанию основанные на валидации блоков информации
        /// </summary>
        public void InitBlock(string parseData)
        {
            //Читает количество блоков
            if(CandidatesCount == 0)
            {
                if(!uint.TryParse(parseData, out CandidatesCount))
                {
                    throw new InvalidCastException("Read blocks count");
                }
                Candidates = new List<Candidate>();
                return;
            }
            else if(CandidatesCount > Candidates.Count)//Читает кандидатов
            {
                Candidates.Add(new Candidate(parseData));
                return;
            }

            /*Читает бюллетени*/
            var round = new Round(parseData);

            CurrentRoundIndex++;

            Console.WriteLine($"Candidate       voites");

            foreach (var candidate in round.ComposeRound(Candidates))
            {
                Console.WriteLine(candidate);
            }

            Console.WriteLine($"Work round {CurrentRoundIndex}");
        }

        /// <summary>
        /// Выигрывает первый кандидат, у которого меньше "штрафов" - т.е. выше рейтинг
        /// </summary>
        /// <returns></returns>
        public Candidate GetCandidate()
        {
            return Candidates.OrderByDescending(c => c.TotalVoitesResult).First();
        }
    }
}
