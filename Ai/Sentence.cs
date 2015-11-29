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
        Words[] wordtype = new Words[1000];
        char[] seperators = { ' ', '.', ',', ';' };
        string[] words = new string[1000];
        string[] types = new string[1000];
        int size = 0;
        string returnVal;
        string cleaned;
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
        public void setClean(string cleanS)
        {
            this.cleaned += " " + cleanS;
        }
        public string getClean()
        {
            return this.cleaned;
        }
        public void setSize(int newsize)
        {
            this.size = newsize;
        }
        public int getSize()
        {
            return this.size;
        }
        public void setWord(string word, int pos)
        {
            this.words[pos] = word;
        }
        public string getWord(int pos)
        {
            return this.words[pos];
        }
        public void setType(string type, int pos)
        {
            this.types[pos] = type;
        }
        public string getType(int pos)
        {
            return this.types[pos];
        }

        public void parseSentence(string sentence)
        {
            
            int i, b ,c;
            //Could do a string split.
            for(i = 0, b = 0, c =0 ; i < sentence.Length; i++)
            {
                switch (sentence[i])
                {
                    case ' ':
                        if (c > 0) { }
                        else { b++; }
                        c++;
                        break;
                    case '.':
                        if (c > 0) { }
                        else { b++; }
                        c++;
                        break;
                    case ',':
                        if (c > 0) { }
                        else { b++; }
                        c++;
                        break;
                    case ';':
                        if (c > 0) { }
                        else { b++; }
                        c++;
                        break;
                    default:
                        words[b] += sentence[i];
                        c = 0;
                        break;
                }

            }
           
            
            System.Console.WriteLine(b);
            
            setSize(b);
            for(i =0; i <= b; i++)
            {
                setWord(words[i], i);
                setClean(words[i]);
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
                setType(mywordTypes[i].getType(), i);
                returntype += mywordTypes[i].getType() + " /";

            }

            setReturn(returntype);
        }

    }
}
