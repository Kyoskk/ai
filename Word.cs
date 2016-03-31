using System;

/* Word型は 単語自体の文字列 と 形態素の文字列 で構成される型 */
class Word
{
    public string worself;// 単語自体
    public string morpheme;// 形態素
    public int id;// 管理ID

    /* 単語を返す */
    public string getWord() { return worself; }

    /* 形態素を返す */
    public string getMorpheme() { return morpheme; }
  
    /* 単語と形態素を代入 */
    public Word set(string Word, string Morpheme)
    {
        Word returnWords = new Word();
        returnWords.worself = Word;
        returnWords.morpheme = Morpheme;
        return returnWords;
    }
}