# stair_char_practice
txt analysis
##題目內容
1. 每一個字都只能往斜的走(左上 右上 左下 右下
2. 如果碰到最左邊或最右邊的牆壁的話 會反彈
3. 如果碰到最上面或最下面的時候 會從另一邊出來， 最下面會連接到最上面,最上面連接到最下面
4. 最後要取得的字串是54個字
5. 第1個字以及第10字為 !
6. 以下這些符號不會出現在答案裡面(%,^,+,@,#,*,=)
-----
# 程式碼解析
## 開啟讀檔對話框

```cs
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
```
## 建立文字陣列(List檔案格式)
形式:

|p|q|p|

|p|q|p|
```cs
List<List<char>> content = new List<List<char>>();
using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
{
    string word = reader.ReadLine();
    while (!string.IsNullOrWhiteSpace(word))
    {
        List<char> line1 = new List<char>();
        char[] line = word.ToCharArray();
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
```
## 讀檔方式:
```cs
StringBuilder sentence;
string write_path = "D:\\Personal-Work-Space\\C# Project\\stair_char_practice\\ans\\ans.txt";
using (StreamWriter streamWriter = new StreamWriter(write_path, false, Encoding.UTF8))
{
    List<char> rule = new List<char>() { '%', '^', '@', '#', '*', '=' };
    for (int y = 0; y < 54; y++)
    {
        for (int x = 0; x < 144; x++)
        {
            List<char> ans = new List<char>();
            for (int i = 0; i < 54; i++)
            {
                ans.Add(content[y + i][x + i]);
            }
            if (ans[0].Equals('!') && ans[9].Equals('!')) //判定第1個條件
            {
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
```
        
