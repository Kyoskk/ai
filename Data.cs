using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

/* Data型は データを読み込んだり,データを追加したりする */
class Data
{
    public string sameLine;// 同じだった行数目(ID)
    public string fileName;// 参照するファイル名
    public List<string> refeData = new List<string>();// 参照するデータ格納用
    public Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

    public Data()
	{

	}

    /* 参照するデータをリストに格納 */
    public void setData(string inputFN)
    {
        fileName = inputFN;
        StreamReader reader = new StreamReader(fileName, sjisEnc);
        string line;
        while ((line = reader.ReadLine()) != null) { refeData.Add(line); }
        reader.Close();
    }

    /* 文字列とファイルの文字列が同じかどうか */
    public bool checkTheSame(string input)
    {
        bool theSame = false;// true = 同じ　false = 同じじゃない
        int nol = 0;// 行数
        for (int i = 0; i < refeData.Count; i++) 
        {
            nol++;
            if (input == refeData[i])
            {
                sameLine = nol.ToString();// 同じだった行数を保存
                theSame = true;
                break;
            }
        }
        return theSame;
    }

    /* 定型文を登録 */
    public void makeCorrectM(List<Word> fixedPh)
    {
        string morphemeline = joinMorph(fixedPh);// 形態素リストを1つのstringに変換
        /* 書き込み処理 */
        setData("CorrectMorphemes.txt");
        if (!checkTheSame(morphemeline))
        {
            StreamWriter writer = new StreamWriter(fileName, true, sjisEnc);// 上書きオフ
            writer.WriteLine(morphemeline);// 書き込み
            writer.Close();
            Console.WriteLine("Added fixed phrase\n");// Debug
        }
        else Console.WriteLine("Failure add fixed phrase\n");// Debug
    }

    /* 形態素リストを1つのstringに変換 */
    public string joinMorph(List<Word> inputList)
    {
        List<string> Sarray = new List<string>();// 結合用リスト
        for (int j = 0; j < inputList.Count; j++) Sarray.Add(inputList[j].getMorpheme());
        string output = string.Join("/", Sarray);// 結合
        return output;
    }

}