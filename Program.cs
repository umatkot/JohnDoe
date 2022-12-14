namespace JohnDoe
{
    internal class Program
    {

        static string InputData { get; set; }

        static void Main(string[] args)
        {
            const string TestData =
@"1

3
AAA John Doe
BBB Jane Smith
CCC Jane Austen
1 2 3
2 1 3
2 3 1
1 2 3
3 1 2";

            if (args.Length == 1 && args[0].Replace(" ", "") != "")
            {
                /*Имеется заданный параметр - файл с блоками*/
                using (var file = File.OpenText(args[0]))
                {
                    InputData = file.ReadToEnd();
                    file.Close();
                }
            }
            else
            {
                InputData = TestData;
            }

            //Максимальный размер бюллетеня в кандидатах
            const int TestBlocksMaxSize = 20;

            InputData = InputData.Replace("\r", "");

            string[] testData = InputData.Split("\n");

            var testBlocks = new List<TestBlock>() { new TestBlock(TestBlocksMaxSize) };

            foreach(var testLine in testData)
            {
                if(testLine.Replace(" ", "").Length == 0)
                {
                    testBlocks.Add(new TestBlock(TestBlocksMaxSize));
                    continue;
                }

                testBlocks.Last().InitBlock(testLine);
            }

            foreach(var testBlock in testBlocks.Where(tb => tb.Candidates != null && tb.Candidates.Count > 0))
            {
                var winner = testBlock.GetCandidate();
                Console.WriteLine(winner.Name);
            }

            //Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }
    }
}