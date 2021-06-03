using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stair_char_practice
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 讀檔路徑
        /// </summary>
        string path; 


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
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                reader.ReadLine();
            }
        }
    }
}
