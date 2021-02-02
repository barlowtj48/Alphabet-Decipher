using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decipher
{
    class Word : List<Artifact>
    {
        private List<Artifact> word = new List<Artifact>();
        private List<string> potential_meanings = new List<string>();

        public Word(List<int> m_ids)
        {
            foreach(int id in m_ids)
            {
                word.Add(UniqueArtifacts.GetUniqueArtifact(id));
            }
        }

        public Word(List<Artifact> a)
        {
            word = a;
        }

        public int GetLength()
        {
            return word.Count;
        }

        public string Compound()
        {
            string output = "";
            foreach(Artifact a in word)
            {
                output += a.Letter();
            }
            return output;
        }

        public void AddPotentialMeaning(string meaning)
        {
            potential_meanings.Add(meaning);
        }
    }
}
