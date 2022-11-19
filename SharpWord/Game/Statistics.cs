using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpWord.Game
{
    [Serializable]
    public class Statistics
    {
        public int Played { get;  set; }
        public int NumberWin { get; set; }
        public double WinPercent { get; private  set; }
        public int CurrentSteak { get; set; }
        public int MaxSteak { get; set; }
        public int[] DisTributeGuess { get; set; }
        public int LatestGuessWinNumber { get; private set; }
        public void Calculate()
        {
            WinPercent =(double) NumberWin / (double)Played  * 100D;

        }
        int NumberMaxAllowGuess ;
        public Statistics (int pNumberofMaxAllowGuess)
        {
            ExplicitConstructor(pNumberofMaxAllowGuess);

        }
        private void ExplicitConstructor(int pNumberofMaxAllowGuess)
        {
            NumberMaxAllowGuess = pNumberofMaxAllowGuess;
            DisTributeGuess = new int[NumberMaxAllowGuess];
        }

        public Statistics()
        {
            ExplicitConstructor(6);
        }
        public void SetLost()
        {
            Played++;
            LatestGuessWinNumber = -1;
            CurrentSteak = 0;
            Calculate();
        }

        
        public void SetWonByNumber(int  NumbeGuess)
        {
            AddDistributeGuess(NumbeGuess);
            Played++;
            NumberWin++;
            CurrentSteak++;
            LatestGuessWinNumber = NumbeGuess;
            if(MaxSteak < CurrentSteak)
            {
                MaxSteak++;
            }

            Calculate();
        }
        private  void AddDistributeGuess(int NumberGuess)
        {
            if(NumberGuess < 0 || NumberGuess > 6)
            {
                throw new Exception( String.Format ("NumberGuess is {0} which is invalid", NumberGuess));
            }


            DisTributeGuess[NumberGuess]++;

        }

    }
}
