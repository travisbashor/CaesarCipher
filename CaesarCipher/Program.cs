using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
  class StringExtensions
  {
    private static Dictionary<char, double> frequencies;
    static void Main(string[] args)
    {
      frequencies = new Dictionary<char, double>()
      {
        {'a', 8.2},
        {'b', 1.5},
        {'c', 2.8},
        {'d', 4.3},
        {'e', 12.7},
        {'f', 2.2},
        {'g', 2.0},
        {'h', 6.1},
        {'i', 7.0},
        {'j', 0.2},
        {'k', 0.8},
        {'l', 4.0},
        {'m', 2.4},
        {'n', 6.7},
        {'o', 7.5},
        {'p', 1.9},
        {'q', 0.1},
        {'r', 6.0},
        {'s', 6.3},
        {'t', 9.1},
        {'u', 2.8},
        {'v', 1.0},
        {'w', 2.4},
        {'x', 0.2},
        {'y', 2.0},
        {'z', 0.1}
      };

      //string cracked = StringExtensions.Cracked("myxqbkdevkdsyxc yx mywzvodsxq dro ohkw!");
      string plaintext = "haskell is fun";
      int amount = 3;
      Console.WriteLine("'{0}' shifted {1} is:\n'{2}'", plaintext, amount, Rotate(amount, plaintext));
      Console.ReadKey();
    }

    private static string Cracked(string cipherText)
    {
      string plaintext  = "";

      // convert from ciphertext to plaintext

      return plaintext;
    }

    private static int Let2nat(char c)
    {
      // ascii starts 'a' at 97
      int asciiOffset = 97;

      // find the numerical code associated with the given character
      int numericalCode = (int)c - asciiOffset;

      return numericalCode;
    }

    private static char Nat2let(int i)
    {
      // ascii starts 'a' at 97
      int asciiOffset = 97;

      // convert the int to its character
      char c = (char)(i + asciiOffset);

      return c;
    }

    private static char Shift(char c, int amount)
    {
      // number of characters in the alphabet
      int alphabetLength = 26;

      // convert to int, add, then convert back, mod 26
      int currentValue = Let2nat(c);

      if(currentValue < 0 || currentValue > 25)
      {
        return c;
      }
      else
      {
        // add the shift factor
        int newValue = currentValue + amount;

        return Nat2let(newValue % alphabetLength);
      }
    }

    private static string Encode(int rot, string s)
    {
      // placeholder for the ciphertext we are building
      StringBuilder ciphertext = new StringBuilder();

      // go through the string, shifting every character
      for(int i = 0; i < s.Length; i++)
      {
        ciphertext.Append(Shift(s[i], rot));
      }

      return ciphertext.ToString();
    }

    private static string Decode(int rot, string s)
    {
      // placeholder for the plaintext we are building
      StringBuilder plaintext = new StringBuilder();

      // go through the string, unshifting every character
      for (int i = 0; i < s.Length; i++)
      {
        plaintext.Append(Shift(s[i], 0 - rot));
      }

      return plaintext.ToString();
    }

    private static int Count(char c, string s)
    {
      int count = 0;

      foreach(char letter in s)
      {
        if (letter.Equals(c)) { count++; }
      }

      return count;
    }

    private static int Lowers(string s)
    {
      int count = 0;
      int numericalValue;

      foreach(char c in s)
      {
        numericalValue = Let2nat(c);
        if(numericalValue >= 0 && numericalValue <= 25)
        {
          count++;
        }
      }

      return count;
    }

    private static List<double> Freqs(string s)
    {
      List<double> freqs = new List<double>();
      int total = Lowers(s);

      for(char c = 'a'; c <= 'z'; c++)
      {
        freqs.Add(100 * (double)Count(c, s) / total);
      }

      return freqs;
    }

    private static string Rotate(int amount, string s)
    {
      return s.Substring(amount) + s.Substring(0, amount);
    }
  }
}
