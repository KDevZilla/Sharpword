using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpWord.Game;

namespace SharpWord.UI
{
    public class MockUI : ISharpWordUI
    {
        private Boolean _IsInputBlocked = false;
        public Boolean IsInputBlocked()
        {
            return _IsInputBlocked;
        }
        public void BlockInput()
        {
            _IsInputBlocked = true;
        }
        public void UnBlockInput()
        {
            _IsInputBlocked = false;
        }
      

        public void ClearUI()
        {
            //throw new NotImplementedException();
        }

        public void CreateBoard()
        {
            //throw new NotImplementedException();
        }

        public void CreateKeyBoard()
        {
           // throw new NotImplementedException();
        }

        public void CreateTiles()
        {
            //throw new NotImplementedException();
        }

        public bool IsFinishProcessing()
        {
            //throw new NotImplementedException();
            return true;
        }

       

        public void RemoveChar(int Row, int Col)
        {
            //throw new NotImplementedException();
        }

        public void RenderAttemptWord()
        {
           // throw new NotImplementedException();
        }

        public void RenderCurrentWord(string str)
        {
           // throw new NotImplementedException();
        }

        public void RenderIncorrectRow(int pRowIndexIncorrect)
        {
           // throw new NotImplementedException();
        }

        public void RenderKeyBoard(Dictionary<char, AlphaResult> pDicTriecChar)
        {
            //throw new NotImplementedException();
        }

        public void RenderLost()
        {
           // throw new NotImplementedException();
        }

        public void RenderWin()
        {
           // throw new NotImplementedException();
        }

        public void SetGame(SharpWordGame pGame)
        {
           // throw new NotImplementedException();
        }

        public void SetTheme(Theme pTheme)
        {
           // throw new NotImplementedException();
        }

        public void ShowStatistics(Statistics statis)
        {
           // throw new NotImplementedException();
        }

      
    }
}
