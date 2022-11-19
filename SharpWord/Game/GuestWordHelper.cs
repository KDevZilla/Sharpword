using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpWord.Game
{
    public class GuessWordHelper
    {
        public static void Guess()
        {
            //Need to implement
            /*
            int i;
            Word WCriteria = new Word();
            Dictionary<int, char> DicCorrectSpot = new Dictionary<int, char>();
            Dictionary<int, char> DicIncorrectSpot = new Dictionary<int, char>();
            List<Char> lstWrongSpot = new List<Char>();
            HashSet<Char> HshNotInTheWord = new HashSet<Char>();
            for (i = 0; i < lstGuestWord.Count; i++)
            {
                if (lstGuestWord[i].GetWordAsString() == "")
                {
                    break;
                }
                Word W = lstGuestWord[i];
                int j;

                for (j = 0; j < W.lstAlpha.Count; j++)
                {
                    switch (W.lstAlpha[j].Result)
                    {
                        case AlphaResult.CorrectSpot:
                            if (!DicCorrectSpot.ContainsKey(j))
                            {
                                DicCorrectSpot.Add(j, W.lstAlpha[j].Char[0]);
                            }
                            break;
                        case AlphaResult.WrongSpot:
                            lstWrongSpot.Add(W.lstAlpha[j].Char[0]);
                            if (!DicIncorrectSpot.ContainsKey(j))
                            {
                                DicIncorrectSpot.Add(j, W.lstAlpha[j].Char[0]);
                            }
                            break;
                        case AlphaResult.NotinTheWord:
                            if (!HshNotInTheWord.Contains(W.lstAlpha[j].Char[0]))
                            {
                                HshNotInTheWord.Add(W.lstAlpha[j].Char[0]);
                            }
                            break;
                    }
                }
            }

            List<String> lstWordFilter = new List<string>();
            List<String> lstWordsTemp = lstWords.ToList();
            for (i = 0; i < lstWordsTemp.Count; i++)
            {
                String WordCheck = lstWordsTemp[i];

                Boolean IsCorrectPostionValid = true;
                Boolean IsNotIncludeIncorrectChar = true;
                Boolean IsIncorrectPostionValid = true;
                foreach (int indexCorrectSpot in DicCorrectSpot.Keys)
                {
                    if (WordCheck[indexCorrectSpot] != DicCorrectSpot[indexCorrectSpot])
                    {
                        IsCorrectPostionValid = false;
                        continue;
                    }

                }

                if (!IsCorrectPostionValid)
                {
                    continue;
                }

                foreach (char chIncorrect in HshNotInTheWord)
                {
                    if (WordCheck.Contains(chIncorrect.ToString()))
                    {
                        IsNotIncludeIncorrectChar = false;
                        continue;
                    }
                }


                if (!IsNotIncludeIncorrectChar)
                {
                    continue;
                }
                int j = 0;
                for (j = 0; j < lstWrongSpot.Count; j++)
                {
                    if (!WordCheck.Contains(lstWrongSpot[j].ToString()))
                    {
                        IsIncorrectPostionValid = false;
                    }
                }
                foreach (int indexInCorrectSpot in DicIncorrectSpot.Keys)
                {
                    if (WordCheck[indexInCorrectSpot] == DicIncorrectSpot[indexInCorrectSpot])
                    {
                        IsIncorrectPostionValid = false;
                        continue;
                    }

                }

                if (!IsIncorrectPostionValid)
                {
                    continue;
                }

                lstWordFilter.Add(WordCheck);
            }
            StringBuilder strB = new StringBuilder();
            for (i = 0; i < lstWordFilter.Count; i++)
            {
                strB.Append(lstWordFilter[i]).Append(Environment.NewLine);
            }
            this.textBox2.Text = strB.ToString();
            */

        }
    }
}
