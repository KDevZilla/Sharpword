using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpWord;
using SharpWord.Game;
using SharpWord.UI;
using static SharpWord.Game.SharpWordGame;

namespace SharpWordUnitTest
{
    [TestClass]
    public class UnitTestSharpWordGame
    {
        public static string CurrentPath
        {
            get
            {
                String ExePath = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                return Path.GetDirectoryName(ExePath);
                //   logFilePath = logFilePath.Replace(".exe", "");
            }
        }
        private static string _WordFileName = @"word.txt";
        public static string WordFileName { get { return _WordFileName; } set { _WordFileName = value; } }
        public static string WordFilePath
        {
            get
            {
                //Need to have the same word.txt as ShardWord project has
                //I don't know how to get the path of SharpWord project
                //So I copy the file from SharpWord project to SharpWordUnitTest project
                return CurrentPath + @"\" + WordFileName;
            }
        }
        private void Answer(SharpWordGame pgame,String pAnswer)
        {
            int i;
            for(i=0;i<pAnswer.Length;i++)
            {
                pgame.EnterChar(pAnswer[i].ToString ());
            }
            pgame.EnterChar("Enter");

        }
        private void ClearInput(SharpWordGame pgame)
        {
            int i;
            for(i=0;i<5;i++)
            {
                pgame.EnterChar("del");
            }
        }


        [TestMethod]
        public void TestIncorrectAnswer()
        {
            String filePath = WordFilePath;
            ISharpWordUI UI = new SharpWord.UI.MockUI();


            SharpWord.Game.SharpWordGame game = new SharpWord.Game.SharpWordGame(UI, filePath);
            game.SetWordAnswerForTestingPurpose(@"BONUS");

            int iCurrentIndex = game.CurrentWordIndex;
            Trace.Assert(iCurrentIndex == 0);

            System.Collections.Generic.List<Alphabet> lstAlpha = null;
            AnswerResultEnum Result = AnswerResultEnum.InTheWordListButNotCorrect;
            SharpWordGame.GameStateEnum GameState = GameStateEnum.Playing;

            Answer(game, "TOTAL");
 
            iCurrentIndex = game.CurrentWordIndex;
            Result = game.LatestResult;
            GameState = game.GameState;
             
            Trace.Assert(iCurrentIndex == 1);
            Trace.Assert(Result == AnswerResultEnum.InTheWordListButNotCorrect);
            Trace.Assert(GameState == GameStateEnum.Playing);

            Answer(game, "DANCE");
            iCurrentIndex = game.CurrentWordIndex;
            Result = game.LatestResult;
            GameState = game.GameState;
            Trace.Assert(iCurrentIndex == 2);
            Trace.Assert(Result == AnswerResultEnum.InTheWordListButNotCorrect);
            Trace.Assert(GameState == GameStateEnum.Playing);

            
            Answer(game, "ABCDE");
            iCurrentIndex = game.CurrentWordIndex;
            Result = game.LatestResult;
            GameState = game.GameState;
            Trace.Assert(iCurrentIndex == 2);
            Trace.Assert(Result == AnswerResultEnum.NotIntheWordList);
            Trace.Assert(GameState == GameStateEnum.Playing);

            ClearInput(game);
            Trace.Assert(game.CurrentGuessWord.GetWordAsString().Trim() == "");

            
            Answer(game, "AAAAA");
            iCurrentIndex = game.CurrentWordIndex;
            Result = game.LatestResult;
            GameState = game.GameState;
            Trace.Assert(iCurrentIndex == 2);
            Trace.Assert(Result == AnswerResultEnum.NotIntheWordList);
            Trace.Assert(GameState == GameStateEnum.Playing);
            ClearInput(game);
            Trace.Assert(game.CurrentGuessWord.GetWordAsString().Trim() == "");

            Answer(game, "INVALIDLENGTH");
            iCurrentIndex = game.CurrentWordIndex;
            Result = game.LatestResult;
            GameState = game.GameState;
            lstAlpha = game.CurrentGuessWord.lstAlphabet;
           
            Trace.Assert(iCurrentIndex == 2);
            Trace.Assert(Result == AnswerResultEnum.NotIntheWordList);
            Trace.Assert(GameState == GameStateEnum.Playing);
            Trace.Assert(lstAlpha.Count == 5);

            ClearInput(game);
            lstAlpha = game.CurrentGuessWord.lstAlphabet;
            Trace.Assert(lstAlpha.Count == 0);
            Trace.Assert(game.CurrentGuessWord.GetWordAsString().Trim() == "");

            ClearInput(game);
            ClearInput(game);
            ClearInput(game);
            lstAlpha = game.CurrentGuessWord.lstAlphabet;
            Trace.Assert(lstAlpha.Count == 0);

         
            Answer(game, "BEGAN");
            iCurrentIndex = game.CurrentWordIndex;
            Result = game.LatestResult;
            GameState = game.GameState;
            Trace.Assert(iCurrentIndex == 3);
            Trace.Assert(Result == AnswerResultEnum.InTheWordListButNotCorrect );
            Trace.Assert(GameState == GameStateEnum.Playing);

            Answer(game, "PHASE");
            iCurrentIndex = game.CurrentWordIndex;
            Result = game.LatestResult;
            GameState = game.GameState;
            Trace.Assert(iCurrentIndex == 4);
            Trace.Assert(Result == AnswerResultEnum.InTheWordListButNotCorrect);
            Trace.Assert(GameState == GameStateEnum.Playing);

            Answer(game, "SUPER");
            iCurrentIndex = game.CurrentWordIndex;
            Result = game.LatestResult;
            GameState = game.GameState;
            Trace.Assert(iCurrentIndex == 5);
            Trace.Assert(Result == AnswerResultEnum.InTheWordListButNotCorrect);
            Trace.Assert(GameState == GameStateEnum.Playing);


            Answer(game, "HOBBY");
            iCurrentIndex = game.CurrentWordIndex;
            Result = game.LatestResult;
            GameState = game.GameState;
            Trace.Assert(iCurrentIndex == 5);
            Trace.Assert(Result == AnswerResultEnum.InTheWordListButNotCorrect);
            Trace.Assert(GameState == GameStateEnum.Finished);
        }


        [TestMethod]
        public void TestAnswer01()
        {
            String filePath = WordFilePath;
            ISharpWordUI UI = new SharpWord.UI.MockUI();

            
            SharpWord.Game.SharpWordGame game = new SharpWord.Game.SharpWordGame(UI, filePath);
            game.SetWordAnswerForTestingPurpose(@"BONUS");

            int iCurrentIndex = game.CurrentWordIndex;
            Trace.Assert(iCurrentIndex == 0);


            AnswerResultEnum Result = AnswerResultEnum.InTheWordListButNotCorrect;
            SharpWordGame.GameStateEnum GameState = GameStateEnum.Playing;

            Answer(game, "BONUS");
          
            iCurrentIndex = game.CurrentWordIndex;
            Result = game.LatestResult;
            GameState = game.GameState;
            Trace.Assert(iCurrentIndex == 0);
            Trace.Assert(Result == AnswerResultEnum.Correct);
            Trace.Assert(GameState == GameStateEnum.Finished);

            
        }

        [TestMethod]
        public void TestAnswer02()
        {
            String filePath = WordFilePath;
            ISharpWordUI UI = new SharpWord.UI.MockUI();


            SharpWord.Game.SharpWordGame game = new SharpWord.Game.SharpWordGame(UI, filePath);
            game.SetWordAnswerForTestingPurpose(@"BONUS");

            int iCurrentIndex = game.CurrentWordIndex;
            Trace.Assert(iCurrentIndex == 0);


            AnswerResultEnum Result = AnswerResultEnum.InTheWordListButNotCorrect;
            SharpWordGame.GameStateEnum GameState = GameStateEnum.Playing;

            Answer(game, "FOCUS");

            iCurrentIndex = game.CurrentWordIndex;
            Result = game.LatestResult;
            GameState = game.GameState;
            System.Collections.Generic.List<Alphabet> lstAlpha = game.PreviousGuessWord.lstAlphabet;
            Dictionary<char, AlphaResult> DicTrieChar = game.DicTriecChar;
            

            Trace.Assert(lstAlpha[0].Result == AlphaResult.NotinTheWord);
            Trace.Assert(lstAlpha[1].Result == AlphaResult.CorrectSpot);
            Trace.Assert(lstAlpha[2].Result == AlphaResult.NotinTheWord );
            Trace.Assert(lstAlpha[3].Result == AlphaResult.CorrectSpot);
            Trace.Assert(lstAlpha[4].Result == AlphaResult.CorrectSpot);

            Trace.Assert(DicTrieChar.Count == 5);
            Trace.Assert(DicTrieChar['F'] == AlphaResult.NotinTheWord);
            Trace.Assert(DicTrieChar['O'] == AlphaResult.CorrectSpot);
            Trace.Assert(DicTrieChar['C'] == AlphaResult.NotinTheWord);
            Trace.Assert(DicTrieChar['U'] == AlphaResult.CorrectSpot);
            Trace.Assert(DicTrieChar['S'] == AlphaResult.CorrectSpot);

            Trace.Assert(iCurrentIndex == 1);
            Trace.Assert(Result == AnswerResultEnum.InTheWordListButNotCorrect);
            Trace.Assert(GameState == GameStateEnum.Playing);




            Answer(game, "BUNNY");
            iCurrentIndex = game.CurrentWordIndex;
            Result = game.LatestResult;
            GameState = game.GameState;
            lstAlpha = game.PreviousGuessWord.lstAlphabet;

            Trace.Assert(lstAlpha[0].Result == AlphaResult.CorrectSpot );
            Trace.Assert(lstAlpha[1].Result == AlphaResult.WrongSpot );
            Trace.Assert(lstAlpha[2].Result == AlphaResult.CorrectSpot);
            Trace.Assert(lstAlpha[3].Result == AlphaResult.NotinTheWord  );
            Trace.Assert(lstAlpha[4].Result == AlphaResult.NotinTheWord );

            /*
            DicTrieChar = game.DicTriecChar;
            Trace.Assert(DicTrieChar.Count == 8);
            Trace.Assert(DicTrieChar['B'] == AlphaResult.CorrectSpot);
            Trace.Assert(DicTrieChar['N'] == AlphaResult.CorrectSpot);
            Trace.Assert(DicTrieChar['O'] == AlphaResult.CorrectSpot);
            Trace.Assert(DicTrieChar['U'] == AlphaResult.CorrectSpot);
            Trace.Assert(DicTrieChar['S'] == AlphaResult.CorrectSpot);
            Trace.Assert(DicTrieChar['Y'] == AlphaResult.NotinTheWord );
            */

            Trace.Assert(iCurrentIndex == 2);
            Trace.Assert(Result == AnswerResultEnum.InTheWordListButNotCorrect);
            Trace.Assert(GameState == GameStateEnum.Playing);

            Answer(game, "BONUS");
            iCurrentIndex = game.CurrentWordIndex;
            Result = game.LatestResult;
            GameState = game.GameState;
            lstAlpha = game.CurrentGuessWord.lstAlphabet;
            DicTrieChar = game.DicTriecChar;
            Trace.Assert(lstAlpha[0].Result == AlphaResult.CorrectSpot);
            Trace.Assert(lstAlpha[1].Result == AlphaResult.CorrectSpot);
            Trace.Assert(lstAlpha[2].Result == AlphaResult.CorrectSpot);
            Trace.Assert(lstAlpha[3].Result == AlphaResult.CorrectSpot);
            Trace.Assert(lstAlpha[4].Result == AlphaResult.CorrectSpot);
            Trace.Assert(iCurrentIndex == 2);
            Trace.Assert(Result == AnswerResultEnum.Correct);
            Trace.Assert(GameState == GameStateEnum.Finished);

        }



        [TestMethod]
        public void TestAnswer03()
        {
            String filePath = WordFilePath;
            ISharpWordUI UI = new SharpWord.UI.MockUI();


            SharpWord.Game.SharpWordGame game = new SharpWord.Game.SharpWordGame(UI, filePath);
            game.SetWordAnswerForTestingPurpose(@"AMPLY");

            int iCurrentIndex = game.CurrentWordIndex;
            Trace.Assert(iCurrentIndex == 0);


            AnswerResultEnum Result = AnswerResultEnum.InTheWordListButNotCorrect;
            SharpWordGame.GameStateEnum GameState = GameStateEnum.Playing;

            Answer(game, "APPLE");

            iCurrentIndex = game.CurrentWordIndex;
            Result = game.LatestResult;
            GameState = game.GameState;
            System.Collections.Generic.List<Alphabet> lstAlpha = game.PreviousGuessWord.lstAlphabet;
            Dictionary<char, AlphaResult> DicTrieChar = game.DicTriecChar;


            Assert.IsTrue(lstAlpha[0].Result == AlphaResult.CorrectSpot);
            Assert.IsTrue(lstAlpha[1].Result == AlphaResult.NotinTheWord);
            // Trace.Assert(lstAlpha[1].Result == AlphaResult.WrongSpot );
            Assert.IsTrue(lstAlpha[2].Result == AlphaResult.CorrectSpot);
            Assert.IsTrue(lstAlpha[3].Result == AlphaResult.CorrectSpot );
            Assert.IsTrue(lstAlpha[4].Result == AlphaResult.NotinTheWord );
           
          

//            Trace.Assert(GameState == GameStateEnum.Finished);

        }
    }
}
