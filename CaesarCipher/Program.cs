using System;

using System.Collections.Generic;

using System.Runtime.InteropServices;

using System.Security.Cryptography.X509Certificates;

using static System.Net.Mime.MediaTypeNames;

// Kommtentare mit /// sind XML-Docs -> /docs compliiert das Doc, mit Zusatzsoftware lässt sich daraus Dokumentation erstellen.

/// <summary>

// Cipher Algorithmn: Caesar

// method: Caesar: an easy algorithmn for cryptographie.

// It's changes the abc by [-n]-steps.

// Not safe, but it was for centuries without any computers an effective way to win time. So this algo is good for training usage to understand the principle of crpytographie.

/// </summary>

public class Caesar
{
    private string[] abc = { "A", "a", "B", "b", "C", "c", "D", "d", "E", "e", "F", "f", "G", "g", "H", "h", "I", "i", "J", "j", "K", "k", "I", "l", "M", "m", "N", "n", "O", "o", "P", "p", "Q", "q", "R", "r", "S", "s", "T", "t", "U", "u", "V", "v", "W", "w", "X", "x", "Y", "y", "Z", "z" };

    //private int[] num = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    //private string[] chr = { "!", "'", "*", "#", "+", "-", ";", ":", "_", "@" };

    // the excepted changed string[] for char index change use

    private string[] abcte;

    /// <summary>

    /// Process ABC changes the abc with the from user inputs number.

    /// Example the user puts 3 in, so the prog will slice abc from begin of the list and add the sliced part again at the end of the list.

    /// Then the excepted abc string[] will return to the main prog, to work with it in the next method.

    /// </summary>

    /// <param name="steps">Steps are the numb of row change.</param>

    /// <returns>abcte[]</returns>
    public string[] ProcessAbc(int steps = 3)

    {
        // prepare the needed collections

        // string[] abc to List<string> for slicing work

        List<string> abce = new List<string>(abc);

        // List<T> for last Array and temp

        List<string> abct = new List<string>();

        List<string> temp = new List<string>();

        // sliced the steps from abc begin

        // steps * 2 ~ double abc

        temp = abce.GetRange(0, steps * 2);

        // now build the changed excepted abc collection

        for (int i = 0; i < abc.Length - steps * 2; i++)

        {

            abct.Add(abce[i + steps * 2]);

        }

        // add the List<string> temp to List<string> abct

        abct.AddRange(temp);

        // now convert List<string> to string[]

        abcte = abct.ToArray();

        return abcte;

    }

    /// <summary>

    /// ProcessCrypt is the part where the user inputs string will encrypt or decrypt.

    /// Mode has two options: 0 is for encrypt and 1 is for decrypt.

    /// </summary>

    /// <param name="text"></param>

    /// <param name="mode"></param>

    /// <returns>strEnd</returns>

    public string ProcessCrypt(string text, int mode = 0)
    {

        // string text to string[]

        string[] textSplitter = text.Split(' ');

        // List<string> for later .Join-Operation

        List<string> listOut = new List<string>();

        // string helper

        string textHold = "";

        int charnum = 0;

        // algo

        for (int i = 0; i < textSplitter.Length; i++)
        {

            for (int p = 0; p < textSplitter[i].Length; p++)
            {

                if (mode == 0)

                {

                    charnum = Array.IndexOf(abc, textSplitter[i][p].ToString());

                }

                else if (mode == 1)

                {

                    charnum = Array.IndexOf(abcte, textSplitter[i][p].ToString());

                }

                else

                {

                    Console.WriteLine("Fehler");

                }



                if (charnum == -1)

                {



                    textHold += ".";

                }

                else

                {

                    if (mode == 0)

                    {

                        textHold += abcte[charnum];

                    }

                    else if (mode == 1)

                    {

                        textHold += abc[charnum];

                    }

                    else

                    {

                        Console.WriteLine("Fehler");

                    }



                }

            }



            // slice the parts, add to a list

            listOut.Add(textHold);

            textHold = "";

        }



        // join the list to an string

        string strEnd = String.Join(" ", listOut);



        return strEnd;

    }



}



public class Program

{

    public static void Main()

    {

        Console.WriteLine("Attention: The following crypth func isn't safe. It's a training encryption method. Was used by Caesars troups to win time, should the enemy got the message.");

        Console.WriteLine("----------------------------------------------------------------");

        Console.WriteLine("");

        Console.WriteLine("");

        Caesar aCall = new Caesar();



        Console.WriteLine("Zahl eingeben: Zahl dient für die Reihen, um die das ABC verschoben wird. Traditionell: 3 \n");

        int a = Convert.ToInt16(Console.ReadLine());

        aCall.ProcessAbc(a);

        Console.WriteLine("Geben Sie einen Text ein. [Sonderzeichen, Zahlen werden als '.' ausgegeben.]");

        string b = Console.ReadLine();

        Console.WriteLine("Geben Sie '0' für Encryp-Methode oder '1' für Decrypt-Methode ein. \n");

        Console.WriteLine("Beispiel: 0 = 'Hallo Welt' zu Ausgabe -> 'Kdoor Zhow'; 1 = 'Kdoor Zhow' zu Ausgabe: 'Hallo Welt'.\n");

        int c = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine(aCall.ProcessCrypt(b, c), "\n");

        Console.WriteLine("\n");

        Main();

    }

}