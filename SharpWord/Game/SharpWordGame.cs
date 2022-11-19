using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpWord.UI;
using System.Threading.Tasks;

namespace SharpWord.Game
{
    public class SharpWordGame
    {
        HashSet<string> lstWords = new HashSet<string>();
        private string WordAnswer = "";
        private void SetWordAnswer()
        {
            SetWordAnswerForTestingPurpose("");
        }
        public Statistics statistic { get; set; }
        private void SetStatisticLost()
        {
            if(statistic ==null)
            {
                Log("statistic is null so there is no need to set value");
                return;
            }
            statistic.SetLost();
        }
        private void SetStattisticWinByNumber(int NumberWin)
        {
            if(statistic ==null)
            {
                Log("statistic is null so there is no need to set value");
                return;
            }
            statistic.SetWonByNumber(NumberWin);
        }
        public event EventHandler HasFinishedUpdateStatistic;

        public enum GameStateEnum
        {
            Playing,
            Finished

        }
        private GameStateEnum _GameState = GameStateEnum.Playing;
        public GameStateEnum GameState
        {
            get
            {
                return _GameState;
            }
        }
        public ILog logObj = null;
        private void Log(String message)
        {
            if(logObj ==null)
            {
                return;
            }
            logObj.Log(message);
        }
        ISharpWordUI UI = null;
        private String wordFilePath { get;  set; }
        public SharpWordGame(ISharpWordUI pUI,String pwordFilePath)
        {
            UI = pUI;
            UI.SetGame(this);
            wordFilePath = pwordFilePath;
            this.InitialGame();
                
        }
        public void ClearUI()
        {
            UI.ClearUI();
        }
        public void SetTheme(Theme theme)
        {
            UI.SetTheme(theme);
        }
        public delegate void ActionMethod();
      
        private void RemoveChar()
        {
            Log("RemoveChar ");
            Log("CurrentWordIndex ::" + CurrentWordIndex.ToString ());
            
            int RemoveCharIndex = CurrentGuessWord.lstAlphabet.Count - 1;

            Log("RemoveCharIndex ::" + RemoveCharIndex.ToString());
            UI.RemoveChar(CurrentWordIndex, RemoveCharIndex );
            CurrentGuessWord.RemoveLastChar();
            

            //UI.RenderCurrentWord(CurrentGuessWord.GetWordAsString());
        }
        private void RiseHasFinishedUpdateStattisticEvent()
        {
            if(HasFinishedUpdateStatistic ==null)
            {
                Log(" HasFinishedUpdateStatistic is null. No need to raise");
                //You can throw new Exception if you like
                return;
            }


            Log(" HasFinishedUpdateStatistic is not null. The program is going to raise");
            HasFinishedUpdateStatistic(this, null);

        }
        private AnswerResultEnum _LatestResult = AnswerResultEnum.NotIntheWordList;
        public AnswerResultEnum LatestResult
        {
            get
            {
                return _LatestResult;
            }
        }
        private void SubmitAnswer()
        {
            AnswerResultEnum AnswerResult = CheckAnswer();
            // ActionMethod NextAction = null;
            _LatestResult = AnswerResult;
            Log(" SubmitAnswer::Begin");
            switch (AnswerResult)
            {
                case AnswerResultEnum.NotIntheWordList:
                    UI.RenderIncorrectRow(CurrentWordIndex);
                    break;
                case AnswerResultEnum.Correct:
                    Log(" SubmitAnswer::Correct");
                    _GameState = GameStateEnum.Finished;
                    UI.RenderAttemptWord();                    
                    UI.RenderKeyBoard(DicTriecChar);
                    UI.RenderWin();
                    SetStattisticWinByNumber (CurrentWordIndex);
                    RiseHasFinishedUpdateStattisticEvent();
                    break;
                case AnswerResultEnum.InTheWordListButNotCorrect:
                    Log(" SubmitAnswer::InTheWordListButNotCorrect");
                    UI.RenderAttemptWord();
                    Log(" SubmitAnswer::RenderAttemptWord");
                    UI.RenderKeyBoard(DicTriecChar);

                    Log(" SubmitAnswer::RenderKeyBoard");
                    
                    if (!IsThereChanceLeft)
                    {
                        Log(" SubmitAnswer::The game is not end yet");
                        MoveTONextGuessWord();
                        Log(" SubmitAnswer::MovetoNextGuessWord");
                        Log(" SubmitAnswer::CurrentWordIndex" + CurrentWordIndex.ToString());
                        // NextAction = null;
                    }
                    else
                    {
                        Log(" SubmitAnswer::The game is end");
                        UI.RenderLost();
                        SetStatisticLost();
                        RiseHasFinishedUpdateStattisticEvent();
                        Log(" SubmitAnswer::RenderLost");
                        _GameState = GameStateEnum.Finished;


                    }

                    


                    break;
            }
            Log(" SubmitAnswer::End");
        }
        private void Operation(String KeyData)
        {
            if (_GameState == GameStateEnum.Finished)
            {
                Log("      [Operation] The Game State is finsiehd ");
                return;
            }
            if (KeyData.ToUpper().Equals("BACK") ||
                KeyData.ToUpper().Equals("DEL") ||
                KeyData.ToUpper ().Equals ( "⌫"))
            {

                if (!IsThereAnyCharLeftToRemove)
                {
                    Log("      [Operation] there is no Char Left To Remove ");

                    return;
                }

                RemoveChar();
                Log("      [Operation] Remove Char");
                return;
            }

            if (KeyData.ToUpper().Equals("ENTER") ||
                KeyData.ToUpper().Equals("RETURN"))
            {

                SubmitAnswer();
                return;

            }

            if (IsReachLastCharInWord)
            {
                Log("      [Operation] IsReachLastCharInWord is true ");
                return;
            }

            CurrentGuessWord.AddChar(KeyData.ToCharArray ()[0]);
            UI.RenderCurrentWord(KeyData);
            Log("      [Operation] RenderCurentWord ");
            return;
        }
        public void EnterChar(String KeyData)
        {
            Log("EnterChar Begin");
            if(UI.IsInputBlocked ())
            {
                Log(" Input is blocked");
                Log(" EnterChar end");

                return;
            }


            try
            {
               

                UI.BlockInput();
                Log(" BlockInput");
                //Log(" Before Operation " + KeyData);
                Log("   ### Operation " + KeyData);
                Operation(KeyData);
                Log("   After Operation");
                //Log(" After Operation " + KeyData);
            }
            catch (Exception ex)
            {
                //Write Log
                throw;
            }
            finally
            {
                UI.UnBlockInput();
                Log(" UnblockInput");
            }

            


        }
        private Boolean IsThereAnyCharLeftToRemove
        {
            get
            {
               return CurrentGuessWord.lstAlphabet.Count > 0;
            }
        }
        private Boolean IsReachLastCharInWord
        {
            get
            {
                return CurrentGuessWord.lstAlphabet.Count >= this.MaxCharInWord;
            }
        }
       

        public void SetWordAnswerForTestingPurpose(String SpecificWord)
        {
            int FirstIndex = 0;
            int LastIndex = lstWords.Count - 1;
            int WordAnswerIndex = GetRandomNumber(FirstIndex, LastIndex);


            int i;
            List<String> tempListWOrkd = lstWords.ToList();
            if (SpecificWord != "")
            {
                for (i = 0; i < lstWords.Count; i++)
                {
                    if (tempListWOrkd[i] == SpecificWord)
                    {
                        WordAnswerIndex = i;
                        break;

                    }
                }
            }
            WordAnswer = tempListWOrkd[WordAnswerIndex];
            WWordAnswer = new Word(WordAnswer);

            //  this.Text = WordAnswer;

        }

        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }
        private void LoadListWord()
        {
            if(wordFilePath.Trim ().Length ==0)
            {
                throw new Exception("Word file path is blank, please set this value");
            }

            LoadListWord(this.wordFilePath);
        }

        private void LoadListWord(String pwordFilePath)
        {
            if (!System.IO.File.Exists(pwordFilePath))
            {
                throw new Exception(String.Format("word file path which is {0} does not exits", pwordFilePath));
            }

            System.IO.StreamReader SR = new System.IO.StreamReader(pwordFilePath);
            String SRWord = SR.ReadToEnd();
            SR.Close();

            string[] arrWork = SRWord.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int i;
            StringBuilder strB = new StringBuilder();

            for (i = 0; i < arrWork.Length; i++)
            {
                string strword = arrWork[i];

                lstWords.Add(strword);
            }

        }
        public Word WWordAnswer = null;

        public List<Char> lstAlphaUsed = new List<Char>();
        private List<Word> _lstGuessWord = new List<Word>();

        public List<Word> lstGuessWord
        {
            get { return _lstGuessWord; }
        }

        public Word CurrentGuessWord
        {
            get
            {
                return _lstGuessWord[CurrentWordIndex];

            }
        }
        public Word PreviousGuessWord
        {
            get
            {
                if(CurrentWordIndex <=0)
                {
                    throw new Exception(String.Format("CurrentWordIndex is {0} which is incorrect", CurrentWordIndex));
                }
                return _lstGuessWord[CurrentWordIndex - 1];
            }
        }
        //int MaxWordGuessAllow = 6;

        private int _MaxWorldGuessAllow = 6;
        public int MaxWordGuessAllow
        {
            get
            {
                return _MaxWorldGuessAllow;
            }
        }
        private int _MaxCharinWord = 5;
        private int MaxCharInWord
        {
            get
            {
                return _MaxCharinWord;
            }
        }
        private int _CurrentWordIndex = 0;
        public int CurrentWordIndex
        {
            get
            {
                return _CurrentWordIndex;
            }
        }
        public void MoveTONextGuessWord()
        {
            if (CurrentWordIndex >= MaxWordGuessAllow)
            {
                return;
            }

            _CurrentWordIndex++;
        }
        public void InitialGame()
        {
            
            lstAlphaUsed = new List<Char>();
            LoadListWord();
            SetWordAnswer();//ZUPPA
            String Word = this.WordAnswer;
            int i;
            for (i = 1; i <= MaxWordGuessAllow; i++)
            {

                _lstGuessWord.Add(new Word(""));
            }

            UI.CreateTiles();
            UI.CreateKeyBoard();
            UI.CreateBoard();
            _GameState = GameStateEnum.Playing;


        }
        public Dictionary<Char, AlphaResult> DicTriecChar = new Dictionary<Char, AlphaResult>();
        public enum AnswerResultEnum
        {
            Correct,
            NotIntheWordList,
            InTheWordListButNotCorrect
        }
        // private AnswerResultEnum AnswerResult = AnswerResultEnum.NotIntheWordList;
        public Boolean IsThereChanceLeft
        {
            get
            {
                if ((CurrentWordIndex + 1) < MaxWordGuessAllow)
                {

                    return false;

                }
                return true;


                //Can write like this  if you don't need to write log
                //return (CurrentWordIndex + 1) >= MaxWordGuessAllow;
            }
        }
        public AnswerResultEnum CheckAnswer()
        {
            return CheckAnswer(this.CurrentGuessWord);
        }
        int _IndexWin = -1;
        public int IndexWin
        {
            get { return _IndexWin; }
        }
        public void SetGuessCharToDic(Char Ch, AlphaResult Result)
        {
            if (!DicTriecChar.ContainsKey(Ch))
            {

                DicTriecChar.Add(Ch, Result);
                //
            }
            else
            {
                DicTriecChar[Ch] = Result;
            }
        }
        public AnswerResultEnum CheckAnswer(Word Guess)
        {
            if (Guess.IsCorrect(this.WWordAnswer))
            {

                Log("Correct");
                //  IsRunning = false;
                Guess.lstAlphabet.ForEach(x => x.Result = AlphaResult.CorrectSpot);
                Guess.lstAlphabet.ForEach(x => { SetGuessCharToDic(x.Character , AlphaResult.CorrectSpot); });

                _IndexWin = this.CurrentWordIndex;
                return AnswerResultEnum.Correct;

            }

            if (!lstWords.Contains(Guess.GetWordAsString()))
            {
                Guess.lstAlphabet.ForEach(x => x.Result = AlphaResult.NotinTheWord);
                return AnswerResultEnum.NotIntheWordList;

            }


            Log("Not Correct");
            StringBuilder strB = new StringBuilder();
            int i;
            for (i = 0; i < Guess.lstAlphabet.Count; i++)
            {
                
                strB.Append(Guess.lstAlphabet[i].Character)
                    .Append(" ")
                    .Append(Guess.lstAlphabet[i].Result)
                    .Append(Environment.NewLine);
                
                if (Guess.lstAlphabet[i].Result == AlphaResult.CorrectSpot ||
                    Guess.lstAlphabet[i].Result == AlphaResult.NotinTheWord)
                {
                    SetGuessCharToDic(Guess.lstAlphabet[i].Character, Guess.lstAlphabet[i].Result);
                    
                }
                else
                {
                    if (!DicTriecChar.ContainsKey(Guess.lstAlphabet[i].Character))
                    {
                        //DicTriecChar.Add(Guess.lstAlpha[i].Char, AlphaResult.WrongSpot);
                        SetGuessCharToDic(Guess.lstAlphabet[i].Character, AlphaResult.WrongSpot);
                    }

                }



                if (!lstAlphaUsed.Contains(Guess.lstAlphabet[i].Character))
                {
                    lstAlphaUsed.Add(Guess.lstAlphabet[i].Character);

                    // lstAlphaUsed[0].
                }

            }
            
            Log(strB.ToString());
            strB = new StringBuilder();
            for (i = 0; i < lstAlphaUsed.Count; i++)
            {
                strB.Append(lstAlphaUsed[i]).Append(" ");
            }
            Log("Char used::" + strB.ToString());

            return AnswerResultEnum.InTheWordListButNotCorrect;

        }



    }
}
