using System;
using System.Collections.Generic;

class MarkovTextGenerator
{
    private Dictionary<string, List<string>> probibilities;

    public MarkovTextGenerator()
    {
        probibilities = new Dictionary<string, List<string>>();
    }

    public void Train(string text)
    {

        string[] words = text.Split(' ');

        // Iterate over the words
        for (int i = 0; i < words.Length - 1; i++)
        {
            // Get the current word and the word that follows it
            string currentWord = words[i];
            string nextWord = words[i + 1];

            // Check if we've already seen the current word
            if (probibilities.ContainsKey(currentWord))
            {
                // If we have, add the next word to the list of possible next words
                probibilities[currentWord].Add(nextWord);
            }
            else
            {
                // If we haven't, create a new list with the next word
                probibilities[currentWord] = new List<string> {nextWord};
            }
        }
    }

    public string GenerateText(int length)
    {
        // random word
        string currentWord = probibilities.Keys.ToArray()[new Random().Next(0, probibilities.Keys.Count)];
        string result = currentWord;

        // Generate new words until we reach the desired length
        while (result.Split(' ').Length < length)
        {
            // Get the list of possible next words
            List<string> nextWords = probibilities[currentWord];

            // Choose a random next word
            currentWord = nextWords[new Random().Next(0, nextWords.Count)];

            // Add the next word to the result
            result += " " + currentWord;
        }

        return result;
    }
}
