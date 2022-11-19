using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static SharpWord.Game;
using SharpWord.Game;

namespace SharpWord.UI
{
    public class DoubleBufferedPanel:Panel
    {
        public Image DrawImage;
        public Point[] NewDes;
        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;

            // or

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }
    
    }
    public class WinFormUI : ISharpWordUI
    {
        Dictionary<String, Label> DicButton = new Dictionary<string, Label>();

        RoundLabel lblAnswer = new RoundLabel();


        public Panel pnlMain;

        private Panel pnlKeys;
        private DoubleBufferedPanel pnlTiles;

        private SharpWordGame _Game;
        private Label lblTemplateTile;
        private Label lblTemplateKey;
        public SharpWordGame Game
        {
            set { _Game = value; }
            get { return _Game; }
        }
        public void SetGame(SharpWordGame pGame)
        {
            _Game = pGame;
        }

        private Theme _CurrentTheme;
        public void SetTheme(Theme pTheme)
        {
            _CurrentTheme = pTheme;
            if(pnlMain==null)
            {
                return;
            }

            RenderTheme();
            RenderKeyBoard(_Game.DicTriecChar);

        }


        private System.Windows.Forms.Form Form;

        public static void SetDoubleBuffered(Control control)
        {
            // set instance non-public property with name "DoubleBuffered" to true
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }
        public WinFormUI (System.Windows.Forms.Form  pForm, Label plblTemplateTile, Label plblTemplateKey)
        {
            //_Game = pGame;
            lblTemplateTile = plblTemplateTile;
            lblTemplateKey = plblTemplateKey;
            Form = pForm;
            SetDoubleBuffered(Form);
            Form.KeyDown += Form_KeyDown;
        }

        public void ClearUI()
        {
            int i;
            this.pnlTiles.Paint -= Panel1_Paint;
            Form.KeyDown -= Form_KeyDown;
            foreach(String key in DicKeyBoard.Keys)
            {
                DicKeyBoard[key].Click -= LblKey_Click;
            }

            for (i = 0; i < listBoardControl.Count; i++) {
                Form.Controls.Remove(listBoardControl[i]);
            }
            listBoardControl.Clear();
            
            

        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            
            if(this._IsInputBlocked  )
            {
                return;
            }

            if (!IsAcceptInput)
            {
                return;
            }

            /*
            if (this.Game.IsGameEnd)
            {
                return;
            }
            */

            if ((e.KeyData < Keys.A) || (e.KeyData > Keys.Z))
            {
                if (e.KeyData != Keys.Back && e.KeyData != Keys.Return)
                {
                    return;
                }
            }
            if (this.Game == null)
            {
                return;
            }
            try
            {
                this.Game.EnterChar(e.KeyData.ToString());
            }
            catch (Exception ex)
            {

                throw new Exception("Form_KeyDown exception::" + ex.ToString());
            }

        }
        public void CreateTiles()
        {

            int i;
            int j;

            for (i = 0; i < _Game.MaxWordGuessAllow; i++)
            {
                for (j = 0; j < this.MaxWordLength; j++)
                {

                    Label labelTile = new Label();
                    labelTile.Height = lblTemplateTile.Height;
                    labelTile.Width = lblTemplateTile.Width;


                    labelTile.Font = lblTemplateTile.Font;
                    labelTile.FlatStyle = FlatStyle.Flat;
                    labelTile.BorderStyle = BorderStyle.FixedSingle;
                    labelTile.TextAlign = ContentAlignment.MiddleCenter;
                    labelTile.Visible = true;
                    labelTile.Text = "";
                    labelTile.Name = GetLableID(i,j);

                    DicButton.Add(labelTile.Name, labelTile);
                }
            }

            this.pnlTiles = new DoubleBufferedPanel();

            SetDoubleBuffered(this.pnlTiles);

            this.pnlTiles.Controls.Clear();
            int HeightOffset = 8;
            int WidthOffset = 8;

            List<Label> lstLbl = DicButton.Values.ToList();

            for (i = 0; i < lstLbl.Count; i++)
            {
                String Name = lstLbl[i].Name;
                int iTop = int.Parse(Name.Substring(0, 2));
                int iLeft = int.Parse(Name.Substring(2, 2));

                lstLbl[i].Top = iTop * (lstLbl[i].Height + HeightOffset) + HeightOffset * 2;
                lstLbl[i].Left = iLeft * (lstLbl[i].Width + WidthOffset) + WidthOffset;

                this.pnlTiles.Controls.Add(lstLbl[i]);
            }

            Label lastLbl = lstLbl[lstLbl.Count - 1];
            this.pnlTiles.Width = lastLbl.Left + lastLbl.Width + WidthOffset;
            this.pnlTiles.Height = lastLbl.Top + lastLbl.Height + HeightOffset;


            lblAnswer = new RoundLabel();

            lblAnswer.AutoSize = false;
            lblAnswer.Text = _Game.WWordAnswer.GetWordAsString();
            lblAnswer.Top = 100;
            lblAnswer.Width = 160;
            lblAnswer.AutoSize = false;
            lblAnswer.Height = 80;
            lblAnswer.TextAlign = ContentAlignment.MiddleCenter;
            lblAnswer.Left = (this.pnlTiles.Width - lblAnswer.Width) / 2;
            lblAnswer.Visible = false;



            lblAnswer.BringToFront();
            this.pnlTiles.Controls.Add(lblAnswer);

        }
        private List<Control> listBoardControl = null;
        public void CreateBoard()
        {
            listBoardControl = new List<Control>();

            int MenuHeight = 24;
            this.pnlMain = new Panel();

            int SpaceBetweenInputAndKeyBoard = 0;
            this.pnlMain.Controls.Add(this.pnlTiles);
            this.pnlMain.Controls.Add(this.pnlKeys);
            this.pnlTiles.Top = MenuHeight + 1;
            this.pnlKeys.Top = this.pnlTiles.Top + this.pnlTiles.Height + SpaceBetweenInputAndKeyBoard;
            this.pnlKeys.Left = 0;
            this.pnlMain.Height = this.pnlKeys.Top + this.pnlKeys.Height;
            this.pnlMain.Width = this.pnlKeys.Left + this.pnlKeys.Width;
            this.pnlTiles.Left = (this.pnlMain.Width - this.pnlTiles.Width) / 2;
          
            Form.Controls.Add(this.pnlMain);
            Form.Height = this.pnlMain.Height;
            Form.Width = this.pnlMain.Width + this.pnlMain.Left + 20 ;

            Rectangle screenRectangle = Form.RectangleToScreen(Form.ClientRectangle);

            int titleHeight = screenRectangle.Top - Form.Top;

            Form.Height =titleHeight + MenuHeight  + this.pnlMain.Height + this.pnlMain.Top  + 10;
            this.RenderTheme();

            listBoardControl.Add(pnlMain);



        }
        public void RenderTheme()
        {
            if(pnlMain ==null)
            {
                return;
            }

            this.pnlMain.BackColor = _CurrentTheme.BoardBackColor;
            this.pnlTiles.BackColor = _CurrentTheme.BoardBackColor;
            this.pnlKeys.BackColor = _CurrentTheme.BoardBackColor;
            Form.BackColor = pnlMain.BackColor;


            lblAnswer._BackColor = _CurrentTheme.LabelAnswerBackColor;
            lblAnswer.Font = lblTemplateTile.Font;
            lblAnswer.ForeColor = _CurrentTheme.LabelAnswerForeColor;


            Color BackColorButton = Color.White;
            Color ForeColor = Color.Black;
            Color BorderColor = Color.Black;
            int i;
            int j;

            for (i = 0; i < _Game.MaxWordGuessAllow; i++)
            {
                for (j = 0; j < this.MaxWordLength; j++)
                {

                    Label labelTile = DicButton[GetLableID(i,j)];
                    labelTile.ForeColor = _CurrentTheme.TileNormalForeColor;
                    labelTile.BackColor = _CurrentTheme.TileNormalBackColor;
                }
            }



            for (i = 0; i < this._Game.lstGuessWord.Count; i++)
            {
                BorderStyle borderStyle = BorderStyle.FixedSingle;
                for (j = 0; j < this._Game.lstGuessWord[i].lstAlphabet.Count; j++)
                {
                    if (this._Game.lstGuessWord[i].GetWordAsString().Length < this.MaxWordLength)
                    {
                        BackColorButton = _CurrentTheme.TileNormalBackColor;
                        ForeColor = _CurrentTheme.TileNormalForeColor;
                    }
                    else
                    {
                        BackColorButton = Color.White;
                        ForeColor = Color.White;
                        borderStyle = BorderStyle.None;
                        switch (this._Game.lstGuessWord[i].lstAlphabet[j].Result)
                        {
                            case AlphaResult.CorrectSpot:
                                BackColorButton = _CurrentTheme.TileCorrectBackColor;
                                ForeColor = _CurrentTheme.TileCorrectForeColor;
                                break;
                            case AlphaResult.WrongSpot:
                                BackColorButton = _CurrentTheme.TileNotCorrectPositionBackColor;
                                ForeColor = _CurrentTheme.TileNotCorrectPositionForeColor;
                                break;
                            case AlphaResult.NotinTheWord:
                                BackColorButton = _CurrentTheme.TileNotExistBackColor;
                                ForeColor = _CurrentTheme.TileNotExistForeColor;
                                break;
                            default:
                                throw new Exception("Wrong value");
                        }
                    }

                    Label labelTile = DicButton[GetLableID(i,j)];
                        labelTile.BackColor = BackColorButton;
                        labelTile.BorderStyle = borderStyle;
                        labelTile.ForeColor = ForeColor;
                }
                


            }
            for (i = 0; i < arrKey.Length; i++)
            {
                for (j = 0; j < arrKey[i].Length; j++)
                {
                    String cKey = arrKey[i][j].ToString();
                    if (cKey == ">")
                    {
                        cKey = "Enter";  
                    }
                    if (cKey == "<")
                    {
                        cKey = "⌫";
                    }

                    RoundLabel labelKey = new RoundLabel();
                    labelKey = DicKeyBoard[cKey];
                    labelKey.ForeColor = _CurrentTheme.KeyForeColor;
                    labelKey._BackColor = _CurrentTheme.KeyBackColor;
                }

            }
            Utility.Utility.MakeFormCaptionToBeDarkMode(this.Form, _CurrentTheme.IsFormCaptionDarkMode);
        }

        Dictionary<String, RoundLabel> DicKeyBoard = new Dictionary<String, RoundLabel>();
        String[] arrKey = { "QWERTYUIOP", "ASDFGHJKL", ">ZXCVBNM<" };
        public void CreateKeyBoard()
        {
            pnlKeys = new Panel();
            DicKeyBoard = new Dictionary<String, RoundLabel>();
           
            int i;
            int j;
            int SpaceBetweenX = 5;
            int SpaceBetweenY = 5;
            Label PreviousKey = null;
            int MaxWidth = 0;
            for (i = 0; i < arrKey.Length; i++)
            {
                PreviousKey = null;

                for (j = 0; j < arrKey[i].Length; j++)
                {
                    String cKey = arrKey[i][j].ToString();

                    RoundLabel LblKey = new RoundLabel();
                    LblKey.Font = lblTemplateKey.Font;
                    LblKey.TextAlign = lblTemplateKey.TextAlign;
                    LblKey.AutoSize = lblTemplateKey.AutoSize;

                    int KeyWidth = lblTemplateTile.Width;
                    int KeyLeft = 0;

                    if (i == 1 && j == 0)
                    {
                        KeyLeft = lblTemplateTile.Width / 2;
                    }
                    else
                    {
                        if (PreviousKey == null)
                        {
                            KeyLeft = (j * (LblKey.Width + SpaceBetweenX) + SpaceBetweenX);
                        }
                        else
                        {
                            KeyLeft = PreviousKey.Left + PreviousKey.Width + SpaceBetweenX;
                        }
                    }
                    if (cKey == ">")
                    {
                        cKey = "Enter";
                        KeyWidth = 100;
                    }
                    if (cKey == "<")
                    {
                        cKey = "⌫";
                        KeyWidth = MaxWidth - KeyLeft;
                    }
                
                    LblKey.Text = cKey.ToString();
                    LblKey.Width = KeyWidth;
                    LblKey.Height = lblTemplateKey.Height;
                    LblKey.Top = (i * (LblKey.Height + SpaceBetweenY) + SpaceBetweenY);
                    LblKey.Left = KeyLeft;
                    LblKey.Visible = true;
                    LblKey.Click += LblKey_Click;
                    PreviousKey = LblKey;
                    DicKeyBoard.Add(LblKey.Text, LblKey);
                    pnlKeys.Controls.Add(LblKey);
                    if(j== arrKey [i].Length -1)
                    {
                        if(LblKey.Left + LblKey.Width > MaxWidth)
                        {
                            MaxWidth = LblKey.Left + LblKey.Width;
                        }
                    }
                }
            
            }


            pnlKeys.Height = PreviousKey.Top + PreviousKey.Height + SpaceBetweenY;
            pnlKeys.Width = MaxWidth;

        }
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
        private void LblKey_Click(object sender, EventArgs e)
        {
            if(IsInputBlocked())
            {
                return;
            }

            RoundLabel roundlabel = (RoundLabel)sender;
            this.Game.EnterChar(roundlabel.Text);

        }
        List<Label> lstB = new List<Label>();
      
        private int iTickCount = 0;
        int iValueChange = 5;
        int[] iTickBegin = { 0, 6, 12, 18, 24 };
        Boolean IsUp = true;
        int indexObjectJumping = 0;
        private void T_Tick(object sender, EventArgs e)
        {


            if (iTickCount < 10)
            {
                IsUp = false;
            }
            else
            {
                IsUp = true;
                if (iTickCount > 20)
                {
                    IsUp = false;
                    iTickCount = 0;
                    indexObjectJumping++;
                    if (indexObjectJumping >= lstB.Count)
                    {
                        Timer t = (Timer)sender;
                        t.Enabled = false;
                        return;
                    }
                }
            }
            iTickCount++;
            iValueChange = -5;
            if (IsUp)
            {
                iValueChange = 5;
            }
            lstB[indexObjectJumping].Top += iValueChange;

        }

        

        public void RenderKeyBoard(Dictionary<Char, AlphaResult> pDicTriecChar)
        {
            //,Dictionary<String, RoundLabel> pDicKeyBoard
            Color BackColorButton = Color.White;
            Color ForeColor = Color.White;
            Color BorderColor = Color.Black;


            foreach (Char Ch in pDicTriecChar.Keys)
            {
                switch (pDicTriecChar[Ch])
                {
                    case AlphaResult.CorrectSpot:
                        BackColorButton = _CurrentTheme.TileCorrectBackColor;
                        ForeColor = _CurrentTheme.TileCorrectForeColor;
                        break;
                    case AlphaResult.WrongSpot:
                        BackColorButton = _CurrentTheme.TileNotCorrectPositionBackColor;
                        ForeColor = _CurrentTheme.TileNotCorrectPositionForeColor;
                        break;
                    case AlphaResult.NotinTheWord:
                        BackColorButton = _CurrentTheme.TileNotExistBackColor;
                        ForeColor = _CurrentTheme.TileNotExistForeColor;
                        break;
                }
                DicKeyBoard[Ch.ToString ()].ForeColor = ForeColor;
                DicKeyBoard[Ch.ToString ()]._BackColor = BackColorButton;

            }

        }
        private string GetLableID(int Row, int Column)
        {
            return Row.ToString("00") + Column.ToString("00");
        }
        public void RenderCurrentWord(String str)
        {
             
            int CurrentCharIndex = _Game.CurrentGuessWord.lstAlphabet.Count - 1;
            Label L = null;

            String LblID = GetLableID( _Game.CurrentWordIndex,CurrentCharIndex);

            if (str.Trim() == "")
            {
                LblID = GetLableID(_Game.CurrentWordIndex, (CurrentCharIndex + 1));
            }
            L = DicButton[LblID];


            TransitionHelper.PopLabel(L, str, L.ForeColor);
           // WaitForUI(1);

        }
        public void RemoveChar(int Row, int Col)
        {
            String ID = GetLableID(Row, Col);
            Label L = DicButton[ID];
            L.Text = "";
        }
        public void RenderWin()
        {
            _IsAcceptInput = false;
            SwapLabel S = new SwapLabel();
            List<Label> lstB = new List<Label>();
            int i;

            for (i = 0; i <= 4; i++)
            {
                lstB.Add(DicButton[GetLableID(this._Game.IndexWin, i)]);
            }
            
            S.DanceLabel(lstB, 150, 4);
            S.Complete += S_CompleteDanceLabel;

        }

        private void S_CompleteDanceLabel(object sender, EventArgs e)
        {
            _IsAcceptInput = true;

        }
        Boolean IsLost = false;
        public void RenderLost()
        {
            IsLost = true;
            lblAnswer.Visible = false;
            this.pnlTiles.Paint += Panel1_Paint;
            this.pnlTiles.Invalidate();
        }
        private void DrawLabel(Graphics pGra, Label L)
        {
            Bitmap b = new Bitmap(L.Width, L.Height);
            L.DrawToBitmap(b, new Rectangle(0, 0, b.Width, b.Height));

            Image image = b;
            Point[] destinationPoints = {
new Point(L.Left , L.Top ),   // destination for upper-left point of
                      // original
new Point(L.Left + L.Width , L.Top ),  // destination for upper-right point of
                      // original
new Point(L.Left , L.Top + L.Height)};  // destination for lower-left point of
                                        // original
            pGra.DrawImage(image, destinationPoints);
        }
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

            if (IsLost)
            {


                int i;
                int j;
                for (i = 0; i <= 2; i++)
                {
                    for (j = 0; j <= 4; j++)
                    {
                        Label LTemp = DicButton[GetLableID(i, j)];
                        LTemp.Visible = false;
                        DrawLabel(e.Graphics, LTemp);
                    }
                }
                

                Rectangle rPosition = lblAnswer.ClientRectangle;
                rPosition.X += lblAnswer.Left;
                rPosition.Y += lblAnswer.Top;

                using (var graphicsPath = lblAnswer._getRoundRectangle(rPosition))
                {


                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (var brush = new SolidBrush(lblAnswer._BackColor))
                        e.Graphics.FillPath(brush, graphicsPath);
                    using (var pen = new Pen(lblAnswer._BackColor, 1.0f))
                        e.Graphics.DrawPath(pen, graphicsPath);
                    TextRenderer.DrawText(e.Graphics, lblAnswer.Text, lblAnswer.Font, rPosition, lblAnswer.ForeColor);
                }
                return;
            }



        }
        public void RenderIncorrectRow(int pRowIndexIncorrect)
        {

            RenderShake( pRowIndexIncorrect);
        }
        public void RenderShake(int pRowIndexIncorrect)
        {
            List<Label> lstB = new List<Label>();

            int i;
            int j;
            int iValueChange = 1;
            int iLoop = 0;
            int[] arrLeft = new int[5];
            for (i = 0; i <= 4; i++)
            {
                lstB.Add(DicButton[GetLableID(pRowIndexIncorrect,i)]);
                arrLeft[i] = DicButton[GetLableID(pRowIndexIncorrect, i)].Left;
            }

            for (iLoop = 0; iLoop < 4; iLoop++)
            {
                for (i = 1; i <= 10; i++)
                {
                    for (j = 0; j < lstB.Count; j++)
                    {
                        lstB[j].Left += iValueChange;

                    }
                    if (i % 2 == 0)
                    {
                        System.Threading.Thread.Sleep(2);
                        Application.DoEvents();
                    }
                }
                iValueChange *= -1;
            }
            for (i = 0; i <= 4; i++)
            {
                
                lstB[i].Left = arrLeft[i];
            }

        }
        Label[] arrLabelSwap = new Label[5];
        Label[] arrLabelSwapNewAttribute = new Label[5];

        public delegate void ActionMethod();
        private Boolean _IsFinishProcessing = false;
        public Boolean IsFinishProcessing()
        {
            return _IsFinishProcessing;
        }
        private void PrepareToWaitForProcess()
        {
            _IsFinishProcessing = false;
        }
        private void FinishProcess()
        {
            _IsFinishProcessing = true;
        }

        public void RenderAttemptWord()
        {
            PrepareToWaitForProcess();
            int i = 0;
            int j = 0;

            Color BackColorButton = Color.White;
            Color ForeColor = Color.Black;


            for (i = 0; i < this._Game.lstGuessWord.Count; i++)
            {
                Boolean IsLastRecord = (i == this._Game.lstGuessWord.Count - 1);

                if (!IsLastRecord)
                {
                    if (this._Game.lstGuessWord[i + 1].GetWordAsString().Length == 0)
                    {
                        IsLastRecord = true;
                    }
                }

                BorderStyle borderStyle = BorderStyle.FixedSingle;
                for (j = 0; j < this._Game.lstGuessWord[i].lstAlphabet.Count; j++)
                {

                    if (this._Game.lstGuessWord[i].GetWordAsString().Length < this.MaxWordLength)
                    {
                        BackColorButton = _CurrentTheme.TileNormalBackColor;
                        ForeColor = _CurrentTheme.TileNormalForeColor;
                    }
                    else
                    {
                        BackColorButton = Color.White;
                        ForeColor = Color.White;
                        borderStyle = BorderStyle.None;
                        switch (this._Game.lstGuessWord[i].lstAlphabet[j].Result)
                        {
                            case AlphaResult.CorrectSpot:
                                BackColorButton = _CurrentTheme.TileCorrectBackColor;
                                ForeColor = _CurrentTheme.TileCorrectForeColor;
                                break;
                            case AlphaResult.WrongSpot:
                                BackColorButton = _CurrentTheme.TileNotCorrectPositionBackColor;
                                ForeColor = _CurrentTheme.TileNotCorrectPositionForeColor;
                                break;
                            case AlphaResult.NotinTheWord:
                                BackColorButton = _CurrentTheme.TileNotExistBackColor;
                                ForeColor = _CurrentTheme.TileNotExistForeColor;
                                break;
                            default:
                                throw new Exception("Wrong value");
                        }
                    }


                    Label B = DicButton[GetLableID(i,j)];


                


                    if (!IsLastRecord)
                    {
                        B.Text = this._Game.lstGuessWord[i].lstAlphabet[j].Character.ToString ();
                        B.BackColor = BackColorButton;
                        B.BorderStyle = borderStyle;
                        B.ForeColor = ForeColor;
                        B.Visible = true;
                    }
                    else
                    {

                        SwapLabel.LabelAttribute NewAttribute = new SwapLabel.LabelAttribute();
                        NewAttribute.BackColor = BackColorButton;
                        NewAttribute.ForeColor = ForeColor;
                        NewAttribute.Text = this._Game.lstGuessWord[i].lstAlphabet[j].Character.ToString ();
                        B.Tag = NewAttribute;
                        arrLabelSwap[j] = B;

                    }

                }
                if (IsLastRecord)
                {
                    this.PrepareToWaitForProcess();
                    SwapLabel S = new SwapLabel();
                    S.Complete += S_Complete;

                      S.SwapNotUsingTimer(this.pnlTiles, arrLabelSwap.ToList(), 2);
                    //S.SwapNotUsingTimer(this.pnlTiles, arrLabelSwap.ToList(), 0);
                    //WaitForUI(10);                    
                    break;
                }



            }
        }

        public void ShowStatistics(Statistics statis)
        {

        }
        private void WaitForUI(int TimeOut)
        {
            int i = 0;
            while (!IsFinishProcessing())
            {
                i++;
                if (i >= 10)
                {
                    Application.DoEvents();
                    i = 0;
                }
            }
            return;
        }
        private void S_Complete(object sender, EventArgs e)
        {

            this.FinishProcess();
        }


        int MaxWordLength = 5;

        private Boolean _IsAcceptInput = true;
        public Boolean IsAcceptInput
        {
            get
            {
                return _IsAcceptInput;
            }
        }
    }
}
