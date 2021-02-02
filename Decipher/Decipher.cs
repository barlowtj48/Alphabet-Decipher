using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//RETHINK BUT WITH INTEGERS
//UNIQUE ARTIFACTS ARE ALREADY ARTIFACTS, MAYBE EVERYTHING IS List<int> UNTIL THEN...

namespace Decipher
{
    class Decipher
    {
        private List<Word> words = new List<Word>();
        private List<string> dictionary = Properties.Resources.english.Split('\n').ToList();
        public Decipher(string file_path)
        {
            List<List<int>> input_ids = new List<List<int>>();

            input_ids = ParseInput(System.IO.File.ReadAllText(file_path));
            InitializeUniqueArtifacts(input_ids);
            InitializeWords(input_ids);
        }

        private List<List<int>> ParseInput(string input)
        {
            //Read in file to into list of all character ids
            List<List<int>> content_ids = new List<List<int>>();
            List<int> numbers = new List<int>();
            List<Artifact> words = new List<Artifact>();

            foreach (string line in input.Split('\n')) //split for each "word"
            {
                string[] ids = line.Split(' ');
                foreach (var item in ids) //split for each letter id
                {
                    int number;
                    if (Int32.TryParse(item, out number))
                    {
                        numbers.Add(number);
                    }
                }
                content_ids.Add(new List<int>(numbers)); //add each word(list of letter IDs) to list
                numbers.Clear();
            }
            return content_ids;
        }

        private void InitializeUniqueArtifacts(List<List<int>> content_ids)
        {
            //differentiate unique IDs and establish structure of unknown letters
            List<int> unique_ids = new List<int>();
            foreach (List<int> word in content_ids)
            {
                foreach (int letter in word)
                {
                    if (!unique_ids.Contains(letter)) //numbers is a list of unique IDs
                    {
                        unique_ids.Add(letter);
                    }
                }
            }
            UniqueArtifacts.SetUniqueArtifacts(unique_ids);
        }

        private void InitializeWords(List<List<int>> input_ids)
        {
            Word single_word;
            foreach(List<int> words_ids in input_ids)
            {
                single_word = new Word(words_ids);
                words.Add(single_word);
            }
        }

        public string Decrypt()
        {
            //it is likely faster to construct words based on length and repeat letters before considering word options
            words.Sort((a, b) => a.GetLength().CompareTo(b.GetLength()));

            foreach (Word word in words)
            {
                foreach(Artifact a in word) //length of the alphabet isn't changing. right? (punctuation, capitals)
                {
                    Artifact actual = UniqueArtifacts.GetUniqueArtifact(a.getID());
                    char current = actual.Letter();
                    for (int i = 0; i < actual.getLength(); i++)
                    {
                        if (dictionary.Contains(word.Compound())) //only 1 exact match for each word should exist
                        {
                            word.AddPotentialMeaning(word.Compound());
                            current = actual.Next();
                        }
                        else
                        {
                            current = actual.NextDestructive();
                        }
                    }
                }
            }
            return " ";
        }
    }
}
