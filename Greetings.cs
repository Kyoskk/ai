using System;
using System.IO;
using System.Collections.Generic;

/* 初期の頃に思いついた型 今はノータッチだが あいさつだけじゃなく 普通にパターンマッチ(決まり文句)したい */
class Greetings{
    public string reference;//参照する挨拶
    public bool isreference;//参照できたかどうか

    public void responce(string greeting){
        //bool isused;//１度使った挨拶かどうか
        StreamReader reader = new StreamReader("greetings.txt",System.Text.Encoding.GetEncoding("shift_jis"));

        string file;//必要
        while((file = reader.ReadLine())!= null){
            reference = file;
            //Console.WriteLine(reference);
            if(reference == greeting){
                isreference = true;
                break;
            }else{
                reference = "";
            }
        }
        reader.Close();
    }

    public int　searchGreeting(string userInput){
        StreamReader reader = new StreamReader("greetings.txt",System.Text.Encoding.GetEncoding("shift_jis"));
        string file;//必要
        int issearch = 0;

        while((file = reader.ReadLine())!= null){
            reference = file;
            //Console.WriteLine(reference);
            issearch = userInput.IndexOf(reference);
            if(0 <= issearch)break;
        }
        return issearch;
    }
}