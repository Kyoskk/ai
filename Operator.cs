using System;
using System.Collections.Generic;

/* Operator型は あるデータを操作する */
class Operator
{
    /* 形態素情報を整理 */
    public string changeFormat(string morpheme)
    {
        Data data = new Data();
        data.setData("Morphemes.txt");
        /* NMeCabの形態素情報の「読み」情報を消去 */
        string[] arrayM = morpheme.Split(',');
        morpheme = string.Join(",", arrayM, 0, 4);
        /* 形態素情報を文字列数値に変換 */
        if (data.checkTheSame(morpheme)) morpheme = data.sameLine;
        else Console.WriteLine("Error:Not find a morpheme. Please check the Morphemes.txt");
        return morpheme;
    }

    /* 句読点の削除 */
    public List<Word> removeP(List<Word> inputS)
    {
        bool fP = false;
        for (int i = 0; i < inputS.Count; i++) 
        {
            if (inputS[i].getWord() == "。") fP = true;
            else if (inputS[i].getWord() == "、") fP = true;
            //else if (inputS[i].getWord() == ".") fP = true;
            //else if (inputS[i].getWord() == ",") fP = true;
            if (fP)
            {
                inputS.RemoveAt(i);
                // Console.WriteLine("Find a punctuation in index {0}", i);// Debug
                fP = false;
                i--;
            }
        }
        return inputS;
    }

    /* 文再構成 */
    public void sortArray(int kind, List<Word> inputWordList)// 種類，並び変える単語の集合
    {
        Console.WriteLine("<Remade sentences>");
        int maxN = 1;// 最大組み合わせ数
        int valueQ = 0;// 商
        int valueR = 0;// 余
        List<int> valueRs = new List<int>();// 余りの集合
        List<Word> tempWords = new List<Word>();// 一時文字列計算用
        Word word = new Word();// 一時文字格納用
        List<Word> oneCom = new List<Word>();// 作成した1組み合わせ保存用
        Data data = new Data();
        data.setData("CorrectMorphemes.txt");

        for (int i = 1; i <= kind; i++) maxN *= i; // 最大組み合わせ数を計算
        
        /* 並び変え処理 （辞書的順序のn番目の組み合わせを算出）*/
        for (int n = 0; n < maxN; n++)
        {
            //Console.WriteLine("{0}組目", n);// Debug 組み合わせ数を表示
            /* nをiで割った余りを保存*/
            for (int i = 1; i <= kind; i++)
            {
                if (i == 1) valueQ = n;
                valueR = valueQ % i;
                valueQ = valueQ / i;
                valueRs.Add(valueR);
                //Console.Write(valueR);// Debug 抜き出す順番を表示.ただし,後ろから見る必要あり.要:次のDebugと併用
            }
            //Console.WriteLine();// Debug 要:前のDebugと併用

            /* 並び変える文字列を初期化 */
            for (int j = 0; j < kind; j++) tempWords.Add(word.set(inputWordList[j].getWord(), inputWordList[j].getMorpheme()));

            /* 1パターン作成 (余りの逆順に要素を抜き出す) */
            for (int k = kind - 1; k >= 0; k--)
            {
                word = tempWords[valueRs[k]];
                tempWords.RemoveAt(valueRs[k]);
                oneCom.Add(word);
            }

            /* 正しい文になっていたら表示 */
            if (data.checkTheSame(data.joinMorph(oneCom)))
            {
                for (int f = 0; f < oneCom.Count; f++) Console.Write(oneCom[f].getWord());// Debug 変形後を表示
                Console.WriteLine();
            }
            /* 初期化 */
            oneCom.Clear();
            valueRs.Clear();
        }
        Console.WriteLine();
    }

}