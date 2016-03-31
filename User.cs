using System;

/* User型は ユーザーについての処理を行う */
class User
{
    public string name = "Guest";// ユーザー名
    public string input;// ユーザー入力文
    public int mode;// 選択モード

    public User()
    {
        //Console.WriteLine("Please tell me your name.");
        //name = inputX();
        Console.WriteLine("Hello {0}!\nFirst of all,please write a sentence in Japanese.", name);
    }

    public string getName() { return name; }

    public string getInput()
    {
        input = inputX();
        return input;
    }

    /* メニュー選択処理 */
    public int getMode(string menu)// メニュー項目
    {
        do Console.WriteLine("\nPlease choose from the below.\n{0}",menu);
        while (!(int.TryParse(inputX(), out mode)));
        Console.WriteLine();
        return mode;
    }

    /* 入力処理(テンプレ) */
    public string inputX()
    {
        Console.Write("\nYOU:");
        return Console.ReadLine();
    }

}