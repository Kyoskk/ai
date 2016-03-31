using System;
using NMeCab;

/* Analyzer型は 形態素解析する だけってのも寂しいから何か加えようぜ */
class Analyzer
{
    /* 形態素解析 */
	public Sentence MorphologicalAnalysis(string inputSentence)
	{
        Word word = new Word();
        Operator ope = new Operator();
        Sentence sen = new Sentence();
        var mecab = MeCabTagger.Create();
        var node = mecab.ParseToNode(inputSentence);// 解析する文字列の入力
        Console.WriteLine("\n<MorphologicalAnalysi>");// Debug
        while (node != null)
        {
            if (node.CharType > 0)
            {
                sen.makeSen(word.set(node.Surface,ope.changeFormat(node.Feature)));// 文を作成
                Console.WriteLine(node.Surface + "\t" + node.Feature);// Debug 解析結果を表示
            }
            //Console.WriteLine(node.Surface + "\t" + node.Feature);// Debug 最初と最後を含んだ解析結果を表示
            node = node.Next;
        }
        ope.removeP(sen.getSen());
        return sen;
    }

}