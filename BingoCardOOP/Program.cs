using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BingoCardOOP
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    int[] cardNum = new int[] { };
        //    int[] bCard = new int[] { };

        //    for (int i = 0; i < cardNum; i++) //tells the program how many cards to generate
        //    {
        //        //initialize card contents to 0
        //        for (int x = 0; x < bCard.GetLength(0); x++) //card row
        //        {
        //            for (int y = 0; y < bCard.GetLength(1); y++) //card col
        //            {
        //                bCard[x, y] = 0;
        //            }
        //        }

        //        //bingo card generation
        //        for (int x = 0; x < bCard.GetLength(0); x++) //card row
        //        {
        //            listNum.Clear();
        //            for (int c = 1; c < 16; c++) //for generating possible numbers from 1-15
        //            {
        //                listNum.Add(c);
        //            }

        //            for (int y = 0; y < bCard.GetLength(1); y++) //card col
        //            {
        //                //generate numbers
        //                num = rnd.Next(0, listNum.Count);
        //                bCard[y, x] = listNum[num];
        //                listNum.RemoveAt(num);
        //            }
        //        }
        //    }
        //}
        static void Main(string[] args)
        {
            int[][,] cards = { };
            int disp = 0;
            bool cont = true;
            Random rnd = new Random();
            cards = new int[getNumFromUser("Please input the number of cards you wish to be generated : ")][,];
            
            for (int x = 0; x < cards.Length; x++)
                cards[x] = generateCard(rnd);
            
            while (cont)
            {
                Console.Clear();
                displayCard(cards[disp]);
                switch (getNumFromUser("Please input [0] Left [1] Right [2] Quit : "))
                {
                    case 0:
                        disp--;
                        break;
                    case 1:
                        disp++;
                        break;
                    case 2:
                        cont = false;
                        break;
                }
                if (disp == cards.Length)
                    disp = 0;
                else if (disp < 0)
                    disp = cards.Length - 1;
            }
            Console.ReadKey();
        }
        static int getNumFromUser(string question)
        {
            int num = 0;
            string uInput = "";
            bool isNum = false;
            //Console.Clear();
            Console.Write(question);
            uInput = Console.ReadLine();
            isNum = int.TryParse(uInput, out num);
            if (!isNum)
            {
                Console.WriteLine("{0} is not a number... Press any key to continue...", uInput);
                Console.ReadKey();
                num = getNumFromUser(question);
            }
            return num;
        }
        static int[,] generateCard(Random rnd)
        {
            int[,] cards = new int[5, 5];
            int num = 0;

            for (int x = 0; x < cards.GetLength(0); x++)
            {
                for (int y = 0; y < cards.GetLength(1); y++)
                {
                    num = rnd.Next(0, 15) + 1;
                    if (num > 15)
                    {
                        Console.ReadKey();
                    }
                    cards[x, y] = num;
                }
            }
            return cards;
        }
        static void displayCard(int[,] card)
        {
            Console.WriteLine("B\tI\tN\tG\tO");
            for (int x = 0; x < card.GetLength(0); x++)
            {
                for (int y = 0; y < card.GetLength(1);  y++)
                {
                    //card[x, y] = card[x, y] + (y * 15);
                    Console.Write((card[x, y] + (y * 15)) + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
