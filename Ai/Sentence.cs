using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ai
{
    class Sentence 
    {
        Concept concept = new Concept();
        int size = 0;
        string returnVal;
        public Sentence(string sentence)
        {
            
            parseSentence(sentence);
        }
        public void setReturn(string returnType)
        {
            this.returnVal = returnType;
        }
        public string getReturn()
        {
            return this.returnVal;
        }
        public void setSize(int newsize)
        {
            this.size = newsize;
        }
        public int getSize()
        {
            return this.size;
        }

        public void parseSentence(string sentence)
        {
            Words[] wordtype = new Words[1000];
            char[] seperators = {' ', '.', ',', ';' };
            string[] words = new string[1000];
            int i, b;
            //Could do a string split.
            for(i = 0, b = 0; i < sentence.Length; i++)
            {
                switch (sentence[i])
                {
                    case ' ':
                        b++;
                        break;
                    case '.':
                        b++;
                        break;
                    case ',':
                        b++;
                        break;
                    case ';':
                        b++;
                        break;
                    default:
                        words[b] += sentence[i];
                        break;
                }

            }
           
            
            System.Console.WriteLine(b);
            
            setSize(b);
            for(i =0; i <= b; i++)
            {
                wordtype[i] = new Words(words[i]);
                System.Console.WriteLine(wordtype[i].getType());
            }

            sendout(wordtype);
        }

        public void sendout(Words[] mywordTypes)
        {
            string returntype = "";
            for(int i= 0; i <= getSize(); i++)
            {
                returntype += mywordTypes[i].getType() + " ";

            }

            setReturn(returntype);
        }

    }
}
