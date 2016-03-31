using System;
using System.Collections.Generic;

/* Sentence型は Word型のリスト で構成される */
class Sentence
{
    private List<Word> sentence = new List<Word>();

    /* 文を返す */
    public List<Word> getSen() { return sentence; }

    /* 文の配列サイズを返す */
    public int getSenCount() { return sentence.Count; }
   
    /* 文を作成 */
    public void makeSen(Word word) { sentence.Add(word); }

    /* Debug 文を表示 */
    public void printSen()
    {
        Console.WriteLine();
        for (int i = 0; i < sentence.Count; i++)
        {
            Console.Write("{0}/",sentence[i].getWord());
        }
    }

    /* Debug 要素数を表示 */
    public void printSenCon()
    {
        Console.WriteLine("SenCon = {0}",sentence.Count);
    }
    
}
