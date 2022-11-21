using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpWord.Game
{
    public enum AlphaResult
    {
        CorrectSpot=1,
        WrongSpot=2,
        NotinTheWord=3
    }
    public class Word
    {
        public string GetWordAsString()
        {
            int i;
            StringBuilder strB = new StringBuilder();
            for(i=0;i<lstAlphabet.Count;i++)
            {
                strB.Append(lstAlphabet[i].Character);
            }
            return strB.ToString();

        }
        public List<Alphabet> lstAlphabet = new List<Alphabet>();
        public Boolean IsItContainChar(Char pChar)
        {
            int i;
            for(i=0;i<lstAlphabet.Count;i++)
            {
                if(lstAlphabet [i].Character ==pChar)
                {
                    return true;
                }
            }
            return false;
        }
        
        public Word Clone()
        {
            Word NewWord = new Word(this.WordValue);
            return NewWord;
        }
        private String WordValue = "";

        public Word(String pWord)
        {
            WordValue = pWord;
            Parse(pWord);
        }
        public Word()
        {

        }
        public Boolean IsCorrect(Word AnswerWord)
        {
            int i = 0;

            Boolean IsCorrect = true;
            if(lstAlphabet.Count != AnswerWord.GetWordAsString().Length )
            {
                IsCorrect = false;
            }
            // Set CorrectSpot
            List<Boolean> lstHasCheckedAlpha = new List<bool>();
          
            for (i = 0; i < lstAlphabet.Count ; i++)
            {
                Alphabet AlphaAnswer = AnswerWord.lstAlphabet[i];
                lstAlphabet[i].Result = AlphaResult.NotinTheWord;
                lstHasCheckedAlpha.Add(false);
                if(lstAlphabet [i].Character == AlphaAnswer.Character  )
                {
                    lstAlphabet[i].Result = AlphaResult.CorrectSpot;
                    lstHasCheckedAlpha[i] = true;
                }
            }

            for (i = 0; i < lstAlphabet.Count; i++)
            {

                int j;
                for (j = 0; j < lstAlphabet.Count; j++)
                {
                    if (i == j ||
                        lstHasCheckedAlpha[j]) {
                        continue;
                    }
                    Alphabet AlphaAnswer = AnswerWord.lstAlphabet[j];

                    if (lstAlphabet[i].Character == AlphaAnswer.Character)
                    {

                        lstHasCheckedAlpha[j] = true;
                        lstAlphabet[i].Result = AlphaResult.WrongSpot;
                    }
                }
            }

            for (i = 0; i < lstAlphabet.Count; i++)
            {
                if (lstAlphabet[i].Result == AlphaResult.NotinTheWord ||
                    lstAlphabet[i].Result == AlphaResult.WrongSpot)
                {
                    IsCorrect = false;
                }
            }
            return IsCorrect;

        }

        
        public void Parse(String PWord)
        {
            int i;
            lstAlphabet = new List<Alphabet>();
            for(i=0;i < PWord.Length;i++)
            {
                Alphabet Alpha = new Alphabet(PWord.Substring(i, 1).ToCharArray ()[0]);
                lstAlphabet.Add(Alpha);
            }
        }


        public void AddChar(Char Char)
        {
            
           
         
            
            Alphabet Alpha = new Alphabet(Char);
            lstAlphabet.Add(Alpha);
            
        }
        public void RemoveLastChar()
        {
            if(lstAlphabet.Count   ==0)
            {
                return;
            }
            lstAlphabet.RemoveAt(lstAlphabet.Count - 1);
        }
    }
    public class Alphabet
    {
        private AlphaResult _Result = AlphaResult.NotinTheWord;
        public AlphaResult Result
        {
            get {
                return _Result;
            }
            set
            {
                _Result = value;
            }
        }
        public Char Character ='\0';
        /*
        public void Verify(String pCharAnswer)
        {
            if(Character.Equals (pCharAnswer))
            {

            }
        }
        */
        public Alphabet (Char pChar)
        {
            Character = pChar;
        }
        
    }
}
