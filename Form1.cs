using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace stair_char_practice
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 讀檔路徑
        /// </summary>
        private string path;

        public Form1()
        {
            InitializeComponent();
        }       

        private void btn_readfile_Click(object sender, EventArgs e)
        {
            readfile(@"D:\Personal-Work-Space\C# Project\stair_char_practice\ques.txt");
            //using (OpenFileDialog openFile = new OpenFileDialog())
            //{
            //    //讀檔設定
            //    openFile.InitialDirectory = @"C:\"; //預設檔案地址
            //    openFile.Filter = "純文字檔|*.txt|所有檔案|*.*"; //預設檔案分類
            //    openFile.FilterIndex = 0; //預設檔案的過濾項目
            //    openFile.RestoreDirectory = true; //取得或設定值，指出對話方塊是否在關閉前將目錄還原至先前選取的目錄。
            //    openFile.FileName = string.Empty; //取得或設定含有檔案對話方塊中所選取檔名的字串。
            //    openFile.Multiselect = false; //不允許多選
            //    openFile.ShowReadOnly = true; //設定唯讀
            //    openFile.Title = "請輸入txt檔";

            //    if (openFile.ShowDialog() == DialogResult.OK)
            //    {
            //        readfile(openFile.FileName);
            //    }
            //}
        }
        
        /// <summary>
        /// 開始讀檔
        /// </summary>
        /// <param name="path">輸入檔案路徑</param>
        private void readfile(string path)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Restart();
            List<List<char>> content = new List<List<char>>();
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                string word = reader.ReadLine();
                while (!string.IsNullOrWhiteSpace(word))
                {   
                    //建立字串List
                    List<char> line1 = new List<char>();
                    //將讀到的字串轉成array
                    char[] line = word.ToCharArray();
                    //正向順序的字串轉成List
                    List<char> word1 = line.ToList();
                    Array.Reverse(line);
                    List<char> word2 = line.ToList();
                    line1.AddRange(word1);
                    word2.RemoveAt(0);
                    line1.AddRange(word2);
                    word1.RemoveAt(0);
                    line1.AddRange(word1);
                    content.Add(line1);
                    word = reader.ReadLine();
                }
            }
            content.AddRange(content);
            
            string write_path = @"D:\Personal-Work-Space\C# Project\stair_char_practice\ans\ans.txt";
            using (StreamWriter streamWriter = new StreamWriter(write_path, false, Encoding.UTF8))
            {
                //List<char> rule = new List<char>() { '%', '^', '@', '#', '*', '=' };
                //Y方向的平移
                for (int y = 0; y < (content.Count)/2; y++) 
                {
                    //X方向的平移
                    for (int x = 0; x < ((content[0].Count)*2 /3); x++)
                    {
                        //取54個字元
                        List<char> ans = new List<char>();
                        for (int i = 0; i < 54; i++)
                        {
                            ans.Add(content[y + i][x + i]);
                        }

                        //判定第1個條件，第1個字以及第10字為 !
                        if (ans[0].Equals('!') && ans[9].Equals('!')) 
                        {
                            //判定第2個條件，符號不會出現在答案裡面(%,^,+,@,#,*,=)
                            //if(ans.All(item => item.Equals(rule.Select(item=> item))))
                            if (!(ans.Contains('%') || ans.Contains('^') || ans.Contains('+') || ans.Contains('@') || ans.Contains('#') || ans.Contains('*') || ans.Contains('=')))
                            {
                                StringBuilder sentence = new StringBuilder();

                                foreach (char item in ans)
                                {
                                    sentence.Append(item);
                                }
                                streamWriter.Write(sentence.Append(Environment.NewLine));
                            }
                        }
                    }
                }
            }
            stopwatch.Stop();
            MessageBox.Show($"{stopwatch.ElapsedMilliseconds}");
        }
    }
}