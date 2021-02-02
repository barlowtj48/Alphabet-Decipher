using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decipher
{
    class Artifact
    {
        private List<char> meanings;
        private int uid;
        private char current_meaning;
        
        public Artifact(int m_id)
        {
            uid = m_id;
            meanings = "etaoinsrhdlucmfywgpbvkxqjz".ToList(); //sorted by frequency of most popular in English to increase efficiency (a bit)
            current_meaning = meanings.First();
        }

        public Artifact(Artifact a)
        {
            this.meanings = new List<char>(a.meanings);
            this.uid = a.uid;
            this.current_meaning = a.current_meaning;
        }

        public char NextDestructive()
        {
            meanings.Remove(current_meaning);
            current_meaning = meanings.First();
            return current_meaning;
        }

        public void RemoveChar(char a)
        {
            meanings.Remove(a);
        }

        public char Letter()
        {
            return current_meaning;
        }

        public char Next()
        {
            if(meanings.Count == 1)
            {
                throw new System.InvalidOperationException("Last meaning reached. No further meanings are possible.");
            }
            current_meaning = meanings[meanings.IndexOf(current_meaning) + 1];
            return current_meaning;
        }

        public int getID() { return uid; }
        public int getLength() { return meanings.Count; }

        public override bool Equals(object obj)
        {
            return this.getID() == (obj as Artifact).getID();
        }
        public override int GetHashCode()
        {
            return this.getID();
        }

    }
}
