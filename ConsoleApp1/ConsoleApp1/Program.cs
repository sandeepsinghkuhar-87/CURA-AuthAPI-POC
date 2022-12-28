using System;
using System.Linq;
 
public class Program
{
  public static void Main()
  {
    var str = "Write a C# method to return the longest word in a string";

        var arrWords = str.Split(' ').AsEnumerable();

        var word = string.Empty;
        foreach(var s in arrWords)
        {
            if(s.Length > word.Length)
                word = s;
        }

        Console.WriteLine(word);
        Console.ReadLine();


 
    // Console.WriteLine(answer);
  }
}