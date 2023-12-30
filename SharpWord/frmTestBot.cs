using SharpWord.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpWord
{
    public partial class frmTestBot : Form
    {
        public frmTestBot()
        {
            InitializeComponent();
        }
        List<string> lstWords = new List<string>();
        private string WordAnswer = "";
        private void SetWordAnswer()
        {
            int FirstIndex = 0;
            int LastIndex = lstWords.Count - 1;
            int WordAnswerIndex = GetRandomNumber(FirstIndex, LastIndex);
            WordAnswer = lstWords[WordAnswerIndex];
            WWordAnswer = new Word(WordAnswer);


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
            System.IO.StreamReader SR = new System.IO.StreamReader(@"C:\Users\user\Desktop\wordsLast2200Final.txt");
            String SRWord = SR.ReadToEnd();
            SR.Close();

            string[] arrWork = SRWord.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int i;
            StringBuilder strB = new StringBuilder();

            for (i = 0; i < arrWork.Length; i++)
            {
                string strword = arrWork[i];
                /*
                if (strword.Trim().Length == 0)
                {
                    continue;
                }
                if (strword.IndexOf(".") > 0)
                {
                    continue;
                }
                if (strword.Length != 5)
                {
                    continue;
                }
                strword = strword.ToUpper();
                int j;
                if (!Regex.IsMatch(strword, @"^[A-Z]+$"))
                {
                    continue;
                }
                strB.Append(strword).Append(Environment.NewLine);
                */
                lstWords.Add(strword);
            }

        }
        public Word WWordAnswer = null;
        public void Log(String str)
        {
            this.textBox1.Text += str + Environment.NewLine;
        }
        public List<String> lstAlphaUsed = new List<string>();
        List<Word> lstGuestWord = new List<Word>();
        //Word GuestWord = null;
        private Word GuestWord
        {
            get
            {
                return lstGuestWord[iCurrentWordIndex];
            }
        }

        int MaxWordGuestAllow = 6;

        int iCurrentWordIndex = 0;
        private Dictionary<String, int> DicCharScore = new Dictionary<string, int>();
        private Dictionary<String, int> DicWordScore = new Dictionary<string, int>();

        private void button1_Click(object sender, EventArgs e)
        {
            lstWords = new List<string>();
            LoadListWord();
            Dictionary<String, int> DicCharAppear = new Dictionary<string, int>();
            int i;
            for(i=0;i<lstWords.Count;i++)
            {
                int j;
                for(j=0;j<lstWords [i].Length;j++)
                {
                    String Ch = lstWords[i][j].ToString ();
                    if(DicCharAppear.ContainsKey (Ch))
                    {
                        DicCharAppear[Ch] += 1;
                    }
                    else
                    {
                        DicCharAppear.Add(Ch, 1);
                    }

                }
            }
            var ordered = DicCharAppear.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);


            StringBuilder strB = new StringBuilder();
            ///  int Score = ordered.Count;
            int Score = 0;
            foreach (string Ch in ordered.Keys)
            {
                Score++;
                DicCharScore.Add(Ch, Score);
             //   DicScore.Add (Ch,)
                strB.Append(Ch).Append(":").Append(ordered[Ch]).Append(Environment.NewLine);
            }
            this.textBox1.Text = strB.ToString();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            lstWords = new List<string>();
            LoadListWord();

            List<String> Vowels = new List<string>();
            Vowels.Add("A");
            Vowels.Add("E");
            Vowels.Add("I");
            Vowels.Add("O");
            Vowels.Add("U");

            List<String> lstResult = new List<string>();
            int i;
            int j;
            for(i=0;i<lstWords.Count;i++)
            {
                Boolean IsValid = true;
                for(j=0;j<Vowels.Count;j++)
                {
                    if(lstWords[i].Contains (Vowels[j]))
                    {
                        IsValid = false;
                        break;
                    }
                }
                if(!IsValid )
                {
                    continue;
                }

                lstResult.Add(lstWords[i]);
            }
            StringBuilder strB = new StringBuilder();
            for(i=0;i<lstResult.Count;i++)
            {
                strB.Append(lstResult[i]).Append(Environment.NewLine);
            }
            this.textBox1.Text = strB.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(DicCharScore.Count ==0)
            {
                MessageBox.Show("Please click button1 first");
                return;
            }

            int i;
            int j;
            for (i = 0; i < lstWords.Count; i++)
            {
                int WordScore = 0;
                String WordTemp = "";
                for (j = 0; j < lstWords[i].Length; j++)
                {
                    int CharScore = 0;
                    if (DicCharScore.ContainsKey(lstWords[i][j].ToString()))
                    {
                        if (WordTemp.IndexOf(lstWords[i][j].ToString()) > -1)
                        {
                            CharScore = 1;
                        }
                        else
                        {
                            CharScore = DicCharScore[lstWords[i][j].ToString()];
                        }
                    }
                    WordTemp += lstWords[i][j].ToString();
                    WordScore += CharScore;

                }
                DicWordScore.Add(lstWords[i], WordScore);
            }

            var ordered = DicWordScore.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            StringBuilder strB = new StringBuilder();
            foreach (String word in ordered.Keys)
            {
                strB.Append(word).Append(":").Append(ordered[word])
                    .Append(Environment.NewLine);
            }
            this.textBox1.Text = strB.ToString();

        }

        private void frmTestBot_Load(object sender, EventArgs e)
        {
            this.Icon = Resource1.letter_w;

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
