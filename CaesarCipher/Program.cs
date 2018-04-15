using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
  class StringExtensions
  {
    static void Main(string[] args)
    {
      //string cracked = StringExtensions.Cracked("myxqbkdevkdsyxc yx mywzvodsxq dro ohkw!");
      string plaintext = "abc";
      int rotation = 3;
      string ciphertext = encode(rotation, plaintext);
      Console.WriteLine("Encoding {0} with {1} as: {2}", plaintext, rotation, ciphertext);
      Console.WriteLine("Decoding {0} with {1} as: {2}", ciphertext, rotation, decode(rotation, ciphertext));
      Console.ReadKey();
    }

    private static string Cracked(string cipherText)
    {
      string plaintext  = "";

      // convert from ciphertext to plaintext

      return plaintext;
    }

    private static int let2nat(char c)
    {
      // ascii starts 'a' at 97
      int asciiOffset = 97;

      // find the numerical code associated with the given character
      int numericalCode = (int)c - asciiOffset;

      return numericalCode;
    }

    private static char nat2let(int i)
    {
      // ascii starts 'a' at 97
      int asciiOffset = 97;

      // convert the int to its character
      char c = (char)(i + asciiOffset);

      return c;
    }

    private static char shift(char c, int amount)
    {
      // number of characters in the alphabet
      int alphabetLength = 26;

      // convert to int, add, then convert back, mod 26
      int currentValue = let2nat(c);

      if(currentValue < 0 || currentValue > 25)
      {
        return c;
      }
      else
      {
        // add the shift factor
        int newValue = currentValue + amount;

        return nat2let(newValue % alphabetLength);
      }
    }

    private static string encode(int rot, string s)
    {
      StringBuilder ciphertext = new StringBuilder();

      for(int i = 0; i < s.Length; i++)
      {
        ciphertext.Append(shift(s[i], rot));
      }

      return ciphertext.ToString();
    }

    private static string decode(int rot, string s)
    {
      StringBuilder plaintext = new StringBuilder();

      for (int i = 0; i < s.Length; i++)
      {
        plaintext.Append(shift(s[i], 0 - rot));
      }

      return plaintext.ToString();
    }

  }
}
