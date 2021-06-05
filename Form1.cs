using System;
using System.Collections.Generic;
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
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                //讀檔設定
                openFile.InitialDirectory = @"C:\"; //預設檔案地址
                openFile.Filter = "純文字檔|*.txt|所有檔案|*.*"; //預設檔案分類
                openFile.FilterIndex = 0; //預設檔案的過濾項目
                openFile.RestoreDirectory = true; //取得或設定值，指出對話方塊是否在關閉前將目錄還原至先前選取的目錄。
                openFile.FileName = string.Empty; //取得或設定含有檔案對話方塊中所選取檔名的字串。
                openFile.Multiselect = false; //不允許多選
                openFile.ShowReadOnly = true; //設定唯讀
                openFile.Title = "請輸入txt檔";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    path = openFile.FileName;
                    //MessageBox.Show(path);
                    readfile(path);
                    //以上兩行可以整併
                }
            }
        }

        private void readfile(string path)
        {
            List<List<char>> content = new  List<List<char>>();
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                List<char[]> content_buffer = new List<char[]>();
                List<char[]> content_buffer2 = new List<char[]>();
                string word = reader.ReadLine();

                int a = word.Length;
                while (!string.IsNullOrWhiteSpace(word))
                {
                    List<char> line1 = new List<char>();
                    char[] line = word.ToCharArray();
                    List<char> word1 = line.ToList();
                    line1.AddRange(word1);
                    Array.Reverse(line);
                    List<char> word2 = line.ToList();
                    word2.RemoveAt(0);
                    line1.AddRange(word2);
                    word1.RemoveAt(0);
                    line1.AddRange(word1);
                    content.Add(line1);
                    word = reader.ReadLine();
                }
            }
            content.AddRange(content);



            StringBuilder sentence;
            string write_path = "D:\\Personal-Work-Space\\C# Project\\stair_char_practice\\ans\\ans.txt";
            using (StreamWriter streamWriter = new StreamWriter(write_path,false, Encoding.UTF8))
            {

                //List<char> rule = new List<char>() {'%','^','@','#','*','='};
                for (int y = 0; y < 54; y++)
                {
                    for (int x = 0; x < 144; x++)
                    {
                        List<char> ans = new List<char>();
                        for (int i = 0; i < 54; i++)
                        {
                            ans.Add(content[y+i][x+i]);
                        }
                        //if(true)
                        if (ans[0].Equals('!') && ans[9].Equals('!')) //判定第1個條件
                        {
                            if(true)

                            if (!(ans.Contains('%') || ans.Contains('^') || ans.Contains('+') || ans.Contains('@') || ans.Contains('#') || ans.Contains('*') || ans.Contains('=')))
                            {
                                sentence = new StringBuilder();
                                foreach (char item in ans)
                                {
                                    sentence.Append(item);
                                }
                                streamWriter.Write(sentence + "\n");
                            }

                        }


                    }
                }
            }
        }
    }
}