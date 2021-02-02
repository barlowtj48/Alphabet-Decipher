using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decipher
{
    static class UniqueArtifacts
    {
        private static List<Artifact> uniqueArtifacts = new List<Artifact>();

        public static bool SetUniqueArtifacts(List<int> ids)
        {
            if(uniqueArtifacts.Count == 0)
            {
                foreach(int id in ids)
                {
                    uniqueArtifacts.Add(new Artifact(id));
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public static List<Artifact> GetUniqueArtifactsList()
        {
            return uniqueArtifacts;
        }
        public static Artifact GetUniqueArtifact(int id)
        {
            return uniqueArtifacts.Find(x => x.getID() == id);
        }
    }
}
