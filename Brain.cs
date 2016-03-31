using System;

/* Brain型は 今のとこ学習しかできない */
class Brain
{
    public Brain()
    {
        Data data = new Data();
        Operator ope = new Operator();
        Sentence sen = new Sentence();
        Analyzer analy = new Analyzer();
        User user = new User();
        sen = analy.MorphologicalAnalysis(user.getInput());// 形態素解析
        /* メニュー */
        switch (user.getMode("[Add fixed phrase]:1\n[Remake a sentence]:2\n[cancel]:other number"))
        {
            case 1:// 定型文を登録
                data.makeCorrectM(sen.getSen());
                break;
            case 2:// 文を再構成
                ope.sortArray(sen.getSenCount(), sen.getSen());
                break;
        }
	}
}