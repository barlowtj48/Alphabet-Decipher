using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Decipher decypher = new Decipher(@"C:\Users\Thomas\Documents\GitHub\Alphabet Decipher\Decipher\code.txt");
            decypher.Decrypt();
        }
    }
}
