using SharpWord.Game;
using SharpWord.UI;
using SharpWord.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SharpWord.UI
{
    public class MainUI
    {
        public interface IFormUI
        {
            void Show();
            void ShowDialog();
            void SetMainUI(MainUI mainUI);
            MainUI GetMainUI();
        }


        public frmGame  mainForm { get; private set; }


        public void AddMainForm(frmGame  form)
        {
            mainForm = form;
        }
        private SharpWordSettings _CurrentSettings;
        public SharpWordSettings CurrentSettings
        {
            get
            {
                if (_CurrentSettings == null)
                {
                    if(!System.IO.File.Exists(Utility.PathUtility.SettingsPath))
                    {
                        Utility.SerializeUtility.CreateNewSettings(Utility.PathUtility.SettingsPath);
                    }
                    _CurrentSettings = Utility.SerializeUtility.DeserializeSettings (Utility.PathUtility.SettingsPath );
                }
                return _CurrentSettings;
            }
        }
        public void SaveSettings()
        {
            Utility.SerializeUtility.SerializeSettings(_CurrentSettings, PathUtility.SettingsPath );
            _CurrentSettings = null;
        }

        private Statistics _CurrentStatistics;
        public Statistics CurrentStatistics
        {
            get
            {
                if(_CurrentStatistics ==null)
                {
                    if (!System.IO.File.Exists(Utility.PathUtility.StatisticPath))
                    {
                        Utility.SerializeUtility.CreateNewStatistics (Utility.PathUtility.StatisticPath);
                    }

                    _CurrentStatistics = Utility.SerializeUtility.DeserializeStatistics(Utility.PathUtility.StatisticPath);
                }
                return _CurrentStatistics;
            }
        }
        public void SaveStatistics()
        {
            Utility.SerializeUtility.SerializeStatistics(_CurrentStatistics, PathUtility.StatisticPath);
            _CurrentStatistics = null;
        }
        private Theme _CurrentTheme = null;
        private Theme BrightTheme = null;
        private Theme DarkTheme = null;
        public Theme CurrentTheme
        {
            get {
                if(CurrentSettings.IsUsingDarkTheme )
                {
                    if(DarkTheme ==null)
                    {
                        DarkTheme = GetTheme(true);
                    }
                    return DarkTheme;
                } else
                {
                    if(BrightTheme ==null)
                    {
                        BrightTheme = GetTheme(false);
                    }
                    return BrightTheme;
                }
                //return _CurrentTheme;
            }
        }
        public Boolean IsGameFinish
        {
            get
            {
                return (_game.GameState == SharpWordGame.GameStateEnum.Finished ) ||
                    _game.IsThereChanceLeft ;
            }
        }


        public void AdjustChildFromTosmallSizeIfNessecially(ChildForm form)
        {
            if(!_CurrentSettings.IsUsingSmallScreen  )
            {
                return;
            }

            form.Scale(FromNormalToSmall);
        }

        public SizeF FromNormalToSmall = new SizeF(0.75f, 0.75f);
        public SizeF FromSmallToNormal = new SizeF(1.33f, 1.33f);
        private SizeF Normal = new SizeF(1, 1);
        private SizeF _ScaleValue = new SizeF(1, 1);
        public SizeF ScaleValue
        {
            get
            {
                if(_CurrentSettings.IsUsingSmallScreen)
                {
                    return new SizeF(0.75f, 0.75f);
                }
                return new SizeF(1.33f, 1.33f);
            }
        }
        public void SetMainFormScaleFromSmallToNormal()
        {
            mainForm.Scale (new  SizeF(1.33f, 1.33f));

        }
        public void SetMainScaleFromNormalToSmall()
        {
            //_ScaleValue = new SizeF(0.75f, 0.75f);
            mainForm.Scale(new SizeF(0.75f, 0.75f));
        }
        public void SetMainFormScale(System.Windows.Forms.Form form)
        {
            if(_ScaleValue.Width == 1)
            {
                return;
            }
           // form.sc
           // form.Scale(_ScaleValue);
        }
        private  Theme GetTheme(Boolean IsDarkTheme)
        {
            Theme theme = new Theme();
            
            if (IsDarkTheme)
            {
                theme.TileNormalBackColor = Color.White;
                theme.TileNormalForeColor = Color.FromArgb(18, 18, 18);
                theme.LabelAnswerBackColor = Color.FromArgb(18, 18, 18);
                theme.LabelAnswerForeColor = Color.White;
                theme.TileCorrectBackColor = Color.FromArgb(106, 170, 100);
                theme.TileCorrectForeColor = Color.White;
                theme.TileNotExistBackColor = Color.FromArgb(58, 58, 60);
                theme.TileNotExistForeColor = Color.White;
                theme.TileNotCorrectPositionBackColor = Color.FromArgb(201, 180, 88);
                theme.TileNotCorrectPositionForeColor = Color.White;

                theme.KeyForeColor = Color.Black;
                theme.KeyBackColor = Color.FromArgb(211, 214, 218);
                theme.BoardBackColor = Color.FromArgb(18, 18, 19);
                theme.BoardForeColor = Color.White;
                theme.ButtonBackColor = Color.White;
                theme.ButtonForeColor = Color.Black;


                theme.PopupFormBackColor = Color.FromArgb(20,18,20);
                theme.IsFormCaptionDarkMode = true;
            }
            else
            {


                theme.TileNormalBackColor = Color.White;
                theme.TileNormalForeColor = Color.Black;
                theme.LabelAnswerBackColor = Color.FromArgb(18, 18, 18);
                theme.LabelAnswerForeColor = Color.White;

                theme.TileCorrectBackColor = Color.FromArgb(83, 141, 78);
                theme.TileCorrectForeColor = Color.White;
                theme.TileNotExistBackColor = Color.FromArgb(120, 124, 126);
                theme.TileNotExistForeColor = Color.White;
                theme.TileNotCorrectPositionBackColor = Color.FromArgb(201, 180, 88);
                theme.TileNotCorrectPositionForeColor = Color.White;
                theme.KeyForeColor = Color.Black;
                theme.KeyBackColor = Color.FromArgb(211, 214, 218);
                theme.BoardBackColor = Color.White;
                theme.BoardForeColor = Color.Black;

                theme.ButtonBackColor = Color.Black;
                theme.ButtonForeColor = Color.White;

                theme.PopupFormBackColor = Color.FromArgb (240,240,240);
                theme.IsFormCaptionDarkMode = false;

            }
            return theme;
        }
        public void NewGame(System.Windows.Forms.Form  formHost)
        {

            int TileWidth = 60;
            int TileHeight = 60;
            int KeyWidth = 78;
            int KeyHeight = 84;


            Label lblTemplateTile = new Label();
            lblTemplateTile.BackColor = System.Drawing.Color.Red;
            lblTemplateTile.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTemplateTile.ForeColor = System.Drawing.Color.White;
            lblTemplateTile.Location = new System.Drawing.Point(0, 0);
            lblTemplateTile.Name = "lblTemplateTile";
            lblTemplateTile.Size = new System.Drawing.Size(TileWidth , TileHeight );
            lblTemplateTile.TabIndex = 19;
            lblTemplateTile.Text = "";
            lblTemplateTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTemplateKey
            // 
            Label lblTemplateKey = new Label();
            lblTemplateKey.BackColor = System.Drawing.Color.Red;
            lblTemplateKey.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTemplateKey.ForeColor = System.Drawing.Color.White;
            lblTemplateKey.Location = new System.Drawing.Point(0, 0);
            lblTemplateKey.Name = "lblTemplateKey";
            lblTemplateKey.Size = new System.Drawing.Size(KeyWidth , KeyHeight );
            lblTemplateKey.TabIndex = 20;
            lblTemplateKey.Text = "A";
            lblTemplateKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            TextLog textLog = new TextLog(PathUtility.LogFilePath );
            frmGame f = null;
            if(formHost !=null)
            {
                f =(frmGame ) formHost;
            } else
            {
                if (mainForm != null)
                {
                    f = mainForm;
                }
                else
                {
                    f = new frmGame();
                }
            }

            ISharpWordUI  UI = new WinFormUI(f, lblTemplateTile, lblTemplateKey);
            UI.SetTheme(this.CurrentTheme);

           
            _game = new SharpWordGame(UI,PathUtility.WordFilePath );            
            _game.logObj = textLog;
            _game.HasFinishedUpdateStatistic += game_HasFinishedUpdateStatistic;
            _game.statistic = this.CurrentStatistics;

            mainForm = f;

            if (System.Diagnostics.Debugger.IsAttached)
            {
                //(You will not see the answer when executing .exe directly)
                String tempForDebugOnly= "DEBUG MODE :" + _game.WWordAnswer.GetWordAsString();
                // f.Text = tempForDebugOnly;

            }

            if (CurrentSettings.IsUsingSmallScreen )
            {
               SetMainScaleFromNormalToSmall();
            }
            f.Show();

            
        }

        Boolean IsBlockShowingStatisticformFromOutside = false ;
        Timer timerShowStatistic = new Timer();
        private void game_HasFinishedUpdateStatistic(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
            SaveStatistics();
            mainForm.EnableStatisticsMenu(false);
            IsBlockShowingStatisticformFromOutside = true;
            
            timerShowStatistic.Interval = 3000;
            timerShowStatistic.Tick -= TimerShowStatistic_Tick;
            timerShowStatistic.Tick += TimerShowStatistic_Tick;           
            timerShowStatistic.Enabled = true;


        }

        private void TimerShowStatistic_Tick(object sender, EventArgs e)
        {

            timerShowStatistic.Stop();
            IsBlockShowingStatisticformFromOutside = false;
            ShowChildForm(new frmStatistics());
            mainForm.EnableStatisticsMenu(true);
        }

        public void ClearCurrentGame()
        {
            //mainForm.Controls.Clear();
            if(_game ==null)
            {
                return;
            }
            timerShowStatistic.Tick -= TimerShowStatistic_Tick;
            timerShowStatistic = new Timer();
            _game.statistic = CurrentStatistics;
            _game.HasFinishedUpdateStatistic -= game_HasFinishedUpdateStatistic;
            _game.ClearUI();
            _game = null;
            mainForm = null;

        }
        private SharpWordGame _game = null;
        public void UpdateGameTheme()
        {

            _game.SetTheme(this.CurrentTheme);
            //_game.
        }
        public void UpdateScale()
        {
            this.mainForm.Scale(this.ScaleValue);
        }
        public void Exit()
        {
            Environment.Exit(0);

        }
        public void SetFormCenterParent(Form Parent, Form Child)
        {
            int X = Parent.Left + (Parent.Width - Parent.Width) / 2;
            int Y = Parent.Top + (Parent.Height - Parent.Height) / 2;
            Point NewLocation = new Point(X, Y);

            Child.Location = NewLocation;
        }

        public void ViewHelp()
        {
            ShowChildForm(new frmViewHelp());

        }
        public DialogResult ShowMessageBox(String message)
        {
            return ShowMessageBox(message, true);
        }
        public DialogResult  ShowMessageBox(String message,Boolean IsShowOKButtonOnly)
        {
            frmMessageBox f = new frmMessageBox();
            f.Message = message;
            f.IsShowOKButtonOnly = IsShowOKButtonOnly;
            ShowChildForm(f);
            return f.DialogResult;

        }
        public void Settings()
        {
            ShowChildForm(new frmSettings ());
        }
        private void ShowChildForm(ChildForm childform)
        {
            childform.mainUI = this;
            SetFormCenterParent(this.mainForm, childform);
            childform.ShowDialog();
        }
        public void About()
        {
            ShowChildForm(new frmAbout());
        }

        public void Statistics()
        {
            if(IsBlockShowingStatisticformFromOutside)
            {
                return;
            }
            ShowChildForm(new frmStatistics());
        }
    }
}
