using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ai
{
    class Words
    {

        /*
            A few basic rules need to be applied to find the rest of the words, things ending in
            'ily' or 'ly' could be adverbs, Things ending in 'ed' or 'ing' usually verbs again 'nt' wil be a verb.
            I dont know how to seperate adjectives from nouns. I suppose Adjectives are properties, so we may be able
            to break them down that way, other than that we would have to program it to cypher through a dictionary making
            new concepts as it went along. Which is plausable. It seems to catch quite alot so far so it shouldnt take much
            effort.

        */
        string[] tenses = { "first", "second", "third" };
        string tense;
        string[] type = new string[1000];
        string retval = "dno";
        string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        enum categories { verb, noun, pronoun, adjective, conjunction, adverb, };
        public Words(string word)
        {
            int count = 0;
            for (int i = 0; i < word.Length; i++)
            {
                for (int b = 0; b < letters.Length; b++)
                {

                    if (word[i].Equals(Convert.ToChar(letters[b])))
                    {
                        count++;
                    }
                    else if (word[i].Equals(Convert.ToChar(letters[b].ToUpper())))
                    {
                        count++;
                    }

                }
            }

            if (count == word.Length)
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
            for (int i = 0; i < 9; i++)
            {
                check = isVerb.checker(i, word);
                if (check.Equals(word)) { }
                else { setReturnVal(check); break; }
                check = isNoun.checker(i, word);
                if (check.Equals(word)) { }
                else { setReturnVal(check); break; }
                check = isAdjective.checker(i, word);
                if (check.Equals(word)) { }
                else { setReturnVal(check); break; }
                check = isPronoun.checker(i, word);
                if (check.Equals(word)) { }
                else { setReturnVal(check); break; }
                check = isConjunction.checker(i, word);
                if (check.Equals(word)) { }
                else { setReturnVal(check); break; }
                check = isAdverb.checker(i, word);
                if (check.Equals(word)) { }
                else { setReturnVal(check); break; }
            }
            if (getType().Equals("dno")) { setReturnVal("X"); };
            return word;
        }

        public class verb
        {
            public string[] verbs = { "actionVerb", "transitiveVerb", "intrasitiveVerb", "auxiliaryVerb", "stativeVerb", "modalVerb", "phrasalVerb", "irregularVerb", "checkVerb" };
            public string checker(int method, string word)
            {
                string checkType = word;
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
                string[] set = { "be", "am", "are", "is", "was", "were", "being", "do", "did", "does", "doing" };
                return word;
            }
            public string stativeVerb(string word)
            {
                return word;
            }
            public string modalVerb(string word)
            {
                string[] set = { "can", "could", "may", "might", "must", "shall", "should", "will", "would" };
                for (int i = 0; i < set.Length; i++)
                {
                    if (word.Equals(set[i])) { return "modal verb"; }
                }
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
                for(int i = 0; i < word.Length; i++)
                {
                    if (i == word.Length - 1)
                    {
                        if (word[i].Equals('g')) { if (word[i - 1].Equals('n')) { if (word[i - 2].Equals('i')) { return "new verb"; } } }
                    }
                }
                for (int i = 0; i < word.Length; i++)
                {
                    if (i == word.Length - 1)
                    {
                        if (word[i].Equals('d')) { if (word[i - 1].Equals('e')) { return "new verb"; } }
                    }
                }
                for (int i = 0; i < word.Length; i++)
                {
                    if (i == word.Length - 1)
                    {
                        if (word[i].Equals('t')) { if (word[i - 1].Equals('n')) { return "new verb"; } }
                    }
                }
                for (int i = 0; i < word.Length; i++)
                {
                    if (i == word.Length - 1)
                    {
                        if (word[i].Equals('s')) { if (word[i - 1].Equals('e')) { if (word[i - 2].Equals('i')) { return "new verb"; } } }
                    }
                }
                return word;
            }
        }

        public class noun
        {
            public string checker(int method, string word)
            {
                string checkType = word;
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
                string checkType = word;
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
                string[] set = { "the", "a", "an" };
                for (int i = 0; i < set.Length; i++)
                {
                    if (word.Equals(set[i])) { return "article"; }
                }
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
                for (int i = 0; i < set.Length; i++)
                {
                    if (word.Equals(set[i])) { return "posseive adjective"; }
                }
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
                string checkType = word;
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
                for (int i = 0; i < set.Length; i++)
                {
                    if (word.Equals(set[i])) { return "possessive pronoun"; }
                }
                return word;
            }
            public string objectPronoun(string word)
            {
                string[] set = { "me", "you", "him", "her", "it", "us", "them" };
                for (int i = 0; i < set.Length; i++)
                {
                    if (word.Equals(set[i])) { return "objective pronoun"; }
                }
                return word;
            }
            public string subjectPronoun(string word)
            {
                string[] set = { "i", "you", "he", "she", "it", "we", "they" };
                for (int i = 0; i < set.Length; i++)
                {
                    if (word.Equals(set[i])) { return "subjective pronoun"; }
                }
                return word;
            }
            public string reflexivePronoun(string word)
            {
                string[] set = { "myself", "yourself", "himself", "herself", "itself", "ourselves", "yourselves", "themselves" };
                for (int i = 0; i < set.Length; i++)
                {
                    if (word.Equals(set[i])) { return "reflexive pronoun"; }
                }
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
                string checkType = word;
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
                string[] set = { "for", "and", "nor", "but", "or", "yet", "so" };
                for (int i = 0; i < set.Length; i++)
                {
                    if (word.Equals(set[i])) { return "conjunction"; }
                }
                return word;
            }

            public string subordinatingConjunction(string word)
            {
                //we have words that require pre-requisite words, multiple words, logic needs applying, can still increment through becasue of the spaces, also some simple logic can be applied here i think.
                string[] set = { "after", "although", "as", "as if", "as long as", "as much as", "as soon as", "as though", "because", "before", "even","even if", "even though","if", "if only", "if when", "if then",
                    "inasmuch", "in order that", "just as", "lest", "now", "now since", "now that", "now when" , "once", "provided", "provided that", "rather than", "since", "so that", "supposing", "than", "that", "though",
                    "til","unless", "until","when", "whenever", "where","whereas", "where if","wherever", "whether", "which", "while", "who", "whoever", "why" };
                for (int i = 0; i < set.Length; i++)
                {
                    if (word.Equals(set[i])) { return "subordinate conjunction"; }
                }
                return word;
            }
            public string correlativeConjunction(string word)
            {
                //connecting words that connect pars of a sentence when used to do so anyway, needs a set of logic to determine 
                string[] set = {"both / and", "not only / but also","either / or", "neither / nor", "whether / or", "as / as", "such / that", "scarecely / when", "as many / as", "no sooner / than", "rather / than" };
                for (int i = 0; i < set.Length; i++)
                {
                    if (word.Equals(set[i])) { return "correlative conjunction"; }
                }
                
                return word;
            }
        }
        public class adverb
        {
            public string checker(int method, string word)
            {
                string checkType = word;
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
            //Adverbs are fairly numerious, they ask How? "easilly, hapilly, slowly". How often? "always, never, sometimes, often",. When....and Where.
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
                for (int i = 0; i < word.Length; i++)
                {
                    if (i == word.Length - 1)
                    {
                        if (word[i].Equals('y')) { if (word[i - 1].Equals('l')) { return "new adverb"; } }
                    }
                }
                return word;
            }
        }
        public class determiner
        {
            public string checker(int method, string word)
            {
                string checkType = "not";
                switch (method)
                {
                    case 0:
                        checkType = determines(word);
                        break;
                     default:
                        break;
                }
                return checkType;
            }

            public string determines(string word)
            {
                string[] set = { "its" };
                for (int i = 0; i < set.Length; i++)
                {
                    if (word.Equals(set[i])) { return "determiner"; }
                }
                return word;
            }

        }

    }
    
}
