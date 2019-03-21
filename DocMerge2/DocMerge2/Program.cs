using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace DocumentMerger2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Document Merger Version 2.0");
            Console.WriteLine("\n");
            Console.WriteLine("This program requires the user to enter at least two files to be merged. In addition to those two files, the user must also supply the output text file." + "\n");
            do
            {
                if (args.Length >= 3)
                {
                    foreach (string file in args)
                    {
                        string lastFile = args.Last();
                        string outputFile = lastFile + ".txt";
                        string allText = System.IO.File.ReadAllText(file + ".txt");
                        if (File.Exists(file + ".txt"))
                        {
                            Console.WriteLine("The file exists.");

                        }
                        else
                        {
                            Console.WriteLine("The file does not exist. Please try again.");
                        }
                        try
                        {
                            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
                            {
                                System.IO.File.AppendAllText(outputFile, allText);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Exception: " + e.Message);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Not possible to merge.");
                    Console.WriteLine("Supply a list of text files to merge followed by the name of the resulting merged text file as command line arguments.");
                }






                /*Console.WriteLine("How many files would you like to merge?");
                string numofFiles = Console.ReadLine();
                int num = System.Convert.ToInt32(numofFiles);
                //Test to see if num > 2
                if (num >= 2)
                {
                    Console.WriteLine("This is an acceptable amount of files!");

                }
                else
                {
                    Console.WriteLine("You must provide at least two documents to merge.");
                }

                //for (int num = System.Convert.ToInt32(numofFiles); num > 2;)
                //{
                //Console.WriteLine("You have chosen " + numofFiles + " files!");
                //break;
                //} */
            }
            while (Console.ReadLine().ToLower().Equals("y"));
        }
    }
}
