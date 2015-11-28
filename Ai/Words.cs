using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ai
{
    class Words
    {
        string[] tenses = { "first", "second", "third" };
        string tense;
        string[] type = new string[1000];
        string retval = "dno";
        string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        enum categories {verb, noun, pronoun, adjective, conjunction,adverb,};
        public Words(string word)
        {
            int count = 0;
            for(int i= 0; i < word.Length; i++)
            {
                for(int b = 0; b < letters.Length; b++)
                {
                    
                    if (word[i].Equals(Convert.ToChar(letters[b])))
                    {
                        count++;
                    }else if (word[i].Equals(Convert.ToChar(letters[b].ToUpper())))
                    {
                        count++;
                    }

                }
            }

            if(count == word.Length)
            {
                checkWord(word);
            }
        }
        public string getType()
        {
            return this.retval;
        }
        public void setReturnVal(string val)
        {
            this.retval = val;

        }
        public void setType(string type, int pos)
        {
            this.type[pos] = type;
        }
        public string getTense()
        {
            return this.tense;
        }
        public void setTense(string newtense)
        {
            this.tense = newtense;
        }

        public string checkWord(string word)
        {
            string check;
            verb isVerb = new verb();
            noun isNoun = new noun();
            adjective isAdjective = new adjective();
            pronoun isPronoun = new pronoun();
            conjunction isConjunction = new conjunction();
            adverb isAdverb = new adverb();
            for(int i =0; i <9; i++)
            {
                check = isVerb.checker(i, word);
                if (check.Equals("verb")) { setReturnVal(check); break; }
                check = isNoun.checker(i, word);
                if (check.Equals("noun")) { setReturnVal(check); break; }
                check = isAdjective.checker(i, word);
                if (check.Equals("adjective")) { setReturnVal(check); break; }
                check = isPronoun.checker(i, word);
                if (check.Equals("pronoun")) { setReturnVal(check); break; }
                check = isConjunction.checker(i, word);
                if (check.Equals("conjunction")) { setReturnVal(check); break; }
                check = isAdverb.checker(i, word);
                if (check.Equals("adverb")) { setReturnVal(check); break; }
            }
            if (getType().Equals("dno")) { setReturnVal("X"); };
            return word;
        }

        public class verb
        {
            public string[] verbs = { "actionVerb", "transitiveVerb", "intrasitiveVerb", "auxiliaryVerb", "stativeVerb", "modalVerb", "phrasalVerb", "irregularVerb", "checkVerb" };
            public string checker(int method, string word)
            {
                string checkType = "not";
                switch (method)
                {
                    case 0:
                       checkType = actionVerb(word);
                        break;
                    case 1:
                        checkType = transitiveVerb(word);
                        break;
                    case 2:
                        checkType = intransitiveVerb(word);
                        break;
                    case 3:
                        checkType = auxiliaryVerb(word);
                        break;
                    case 4:
                        checkType = stativeVerb(word);
                        break;
                    case 5:
                        checkType = modalVerb(word);
                        break;
                    case 6:
                        checkType = phrasalVerb(word);
                        break;
                    case 7:
                        checkType = irregularVerb(word);
                        break;
                    case 8:
                        checkType = checkVerb(word);
                        break;
                }
                return checkType;
            }
            public string actionVerb(string word)
            {
                return word;
            }
            public string transitiveVerb(string word)
            {
                return word;
            }
            public string intransitiveVerb(string word)
            {
                return word;
            }
            public string auxiliaryVerb(string word)
            {
                return word;
            }
            public string stativeVerb(string word)
            {
                return word;
            }
            public string modalVerb(string word)
            {
                return word;
            }
            public string phrasalVerb(string word)
            {
                return word;
            }
            public string irregularVerb(string word)
            {
                return word;
            }
            public string checkVerb(string word)
            {
                return word;
            }
        }

        public class noun
        {
            public string checker(int method, string word)
            {
                string checkType = "not";
                switch (method)
                {
                    case 0:
                        checkType = pluralNoun(word);
                        break;
                    case 1:
                        checkType = checkNoun(word);
                        break;
                    default:
                        break;
                }
                return checkType;
            }
            public string pluralNoun(string word)
            {
                return word;
            }
            public string checkNoun(string word)
            {
                return word;
            }

        }
        public class adjective
        {
            public string checker(int method, string word)
            {
                string checkType = "not";
                switch (method)
                {
                    case 0:
                        checkType = articleAdjective(word);
                        break;
                    case 1:
                        checkType = positionAdjective(word);
                        break;
                    case 2:
                        checkType = degreeAdjective(word);
                        break;
                    case 3:
                        checkType = possessiveAdjective(word);
                        break;
                    case 4:
                        checkType = checkAdjective(word);
                        break;
                    default:
                        break;
                }
                return checkType;
            }
            public string articleAdjective(string word)
            {
                return word;
            }
            public string positionAdjective(string word)
            {
                return word;
            }
            public string degreeAdjective(string word)
            {
                return word;
            }
            public string possessiveAdjective(string word)
            {
                string[] set = { "my", "your", "his", "her", "its", "our", "your", "their" };
                return word;
            }
            public string checkAdjective(string word)
            {
                return word;
            }
        }
        public class pronoun
        {
            public string checker(int method, string word)
            {
                string checkType = "not";
                switch (method)
                {
                    case 0:
                        checkType = possessivePronoun(word);
                        break;
                    case 1:
                        checkType = objectPronoun(word);
                        break;
                    case 2:
                        checkType = subjectPronoun(word);
                        break;
                    case 3:
                        checkType = reflexivePronoun(word);
                        break;
                    case 4:
                        checkType = indefinitePronoun(word);
                        break;
                    case 5:
                        checkType = contractivePronoun(word);
                        break;
                    default:
                        break;
                }
                return checkType;
            }
            public string possessivePronoun(string word)
            {
                string[] set = { "mine", "yours", "his", "hers", "ours", "yours", "theirs" };
                return word;
            }
            public string objectPronoun(string word)
            {
                string[] set = { "me", "you", "him", "her", "it", "us", "them" };
                return word;
            }
            public string subjectPronoun(string word)
            {
                string[] set = { "i", "you", "he", "she", "it", "we", "they" };
                return word;
            }
            public string reflexivePronoun(string word)
            {
                string[] set = { "myself", "yourself", "himself", "herself", "itself", "ourselves", "yourselves", "themselves" };
                return word;
            }
            public string indefinitePronoun(string word)
            {
                return word;
            }
            public string contractivePronoun(string word)
            {
                return word;
            }
        }
        public class conjunction
        {
            public string checker(int method, string word)
            {
                string checkType = "not";
                switch (method)
                {
                    case 0:
                        checkType = coordinatingConjunction(word);
                        break;
                    case 1:
                        checkType = subordinatingConjunction(word);
                        break;
                    case 2:
                        checkType = correlativeConjunction(word);
                        break;
                    default:
                        break;
                }
                return checkType;
            }
            public string coordinatingConjunction(string word)
            {
                return word;
            }

            public string subordinatingConjunction(string word)
            {
                return word;
            }
            public string correlativeConjunction(string word)
            {
                return word;
            }
        }
        public class adverb
        {
            public string checker(int method, string word)
            {
                string checkType = "not";
                switch (method)
                {
                    case 0:
                        checkType = subordinatingAdverb(word);
                        break;
                    case 1:
                        checkType = contractiveAdverb(word);
                        break;
                    case 2:
                        checkType = checkAdverb(word);
                        break;
                    default:
                        break;
                }
                return checkType;
            }
            public string subordinatingAdverb(string word)
            {
                return word;
            }
            public string contractiveAdverb(string word)
            {
                return word;
            }
            public string checkAdverb(string word)
            {
                return word;
            }
        }
    }

    
}
