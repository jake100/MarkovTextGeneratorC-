
namespace MarkovProgram
{
    class Program
    {
        static void Main(String[] args)
        {

            MarkovTextGenerator generator = new MarkovTextGenerator();
            generator.Train("The quick brown fox jumps over the lazy dog.");
            string generatedText = generator.GenerateText(10);
            Console.WriteLine(generatedText);
        }
    }
}