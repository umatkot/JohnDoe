﻿namespace JohnDoe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string InputData =
@"1

3
John Doe
Jane Smith
Jane Austen
1 2 3
2 1 3
2 3 1
1 2 3
3 1 2";
            const int nTestBlocksMax = 20;

            string [] testData = InputData.Split("\r\n");

            var testBlocks = new List<TestBlock>() { new TestBlock() };

            foreach(var testLine in testData)
            {
                if(testLine.Replace(" ", "").Length == 0)
                {
                    testBlocks.Add(new TestBlock());
                    continue;
                }

                testBlocks.Last().InitBlock(testLine);
            }

            foreach(var testBlock in testBlocks.Where(tb => tb.Candidates.Count > 0))
            {
                var winner = testBlock.GetCandidate();
                Console.WriteLine(winner.Name);
            }

            Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }
    }
}