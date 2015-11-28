using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ai
{
    class Concept
    {
        Sentence sentence;
        public Concept()
        {
           

        }
        public void setSentence(Sentence sent) {
            this.sentence = sent;
        }
        public Sentence getSentence() {
            return this.sentence;
        }

        public void sendSentence(string insentence)
        {
            sentence = new Sentence(insentence);
            setSentence(sentence);
            // sentence.getReturn();
        }
        public string getSentenceReturn()
        {

            return getSentence().getReturn();
        }
    }
}
