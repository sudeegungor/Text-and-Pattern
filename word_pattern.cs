using System;

namespace strings_homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome!This program will find the words in your text that corresponds to your pattern.");
            Console.WriteLine("Please enter your text here (and please do not forget to leave space after any punctiation) : ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            string sentence = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("Please enter your pattern (caution: your pattern can not contain both '*' and '-') :");
            Console.ForegroundColor = ConsoleColor.White;
            string pattern = Console.ReadLine().ToLower();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            string[] control_words = null;
            control_words = sentence.Split(' '); //this is original text words.
            int index;
            int index_counter = 0;
            int temp = 0;
            bool flag = true;
            int word_counter = 0;
            int symbol_counter = 0;
            string[] words = new string[control_words.Length];
            // end of declaration table.

            if(sentence=="")
            {
                Console.WriteLine("You haven't entered a text.");
                Console.WriteLine("That's why: ");
            }

            if(pattern=="")
            {
                Console.WriteLine("You haven't entered a pattern");
                Console.WriteLine("That's why: ");
            }


            //this condition checks if pattern contains both '*' and '-' and if so prints an error message.
            if (pattern.Contains('-') && pattern.Contains('*'))
            {
                Console.WriteLine("Pattern can not contain both '*' and '-'.");
                word_counter++; //then the program increase the word counter by 1 because it means we already printed an error message so program will not print another.
            }



            //in this loop program detects if there's a punctiation by checking ASCII codes and if so it replaces the word by its only word form.
            for (int i = 0; i < words.Length; i++)
            {
                if (control_words[i] != "")
                {
                    char a = (control_words[i])[control_words[i].Length - 1];
                    if (a > 32 && a < 65)
                    {
                        control_words[i] = control_words[i].Substring(0, control_words[i].Length - 1);
                    }
                }
            }
            // in this loop program fills up the word array with the words in control_word array but in lower case so that it can control everything easily.
            for (int i = 0; i < control_words.Length; i++)
            {
                words[i] = control_words[i].ToLower();
            }

            //in this loop program counts how many symbols does pattern contain.
            for (int s = 0; s < pattern.Length; s++)
            {
                if (pattern[s] == '*')
                    symbol_counter++;

            }

            //now we begin our main loop, it checks every word in array.
            for (int i = 0; i < words.Length; i++)
            {
                if (pattern != "")
                {
                    if (pattern[0] == '*') //if first index of pattern is symbol, program will start checking from second index so we set the temp and index to 1.
                    {
                        temp = 1;
                        index = 1;
                    }
                }

                // this loop iterates for symbol_counter+1 times because if there is n symbols that means we have n+1 parts to control if its matching.
                for (int j = 0; j < symbol_counter + 1; j++)
                {
                    if (pattern.Contains('*'))
                    {
                        //first we find which index is *
                        index = pattern.IndexOf('*', index_counter);

                        // in order not to deal with index out of bound errors we only check the words which lenght is longer than or equal to pattern,the shorter
                        //ones is clearly not going to correspond already.
                        if (words[i].Length >= pattern.Length)
                        {
                            //program basically divides word and pattern into parts by symbol and checks if the word corresponds to that pattern part by part.
                            if (index > 0)
                            {
                                if (!words[i].Substring(temp, words[i].Length - temp).Contains(pattern.Substring(temp, index - temp)))
                                {
                                    flag = false;
                                }
                            }
                            //if index is -1 that means there is no other symbols after last one so program checks the last part of the word.
                            if (index < 0)
                            {
                                if (!words[i].Substring(temp, words[i].Length - temp).Contains(pattern.Substring(temp, pattern.Length - temp)))
                                {
                                    flag = false;
                                }

                            }
                            //then we set temp and index counter to index+1 to compare next part
                            //part is: between to symbols or from start to first symbol or from last symbol to end of word
                            temp = index + 1;
                            index_counter = index + 1;

                        }
                        else
                            flag = false;


                    }
                    else if (!pattern.Contains('*'))
                        flag = false;
                    if (!flag)
                        break;



                }
                //before we start checking next word we set temp and counter to 0 to start over.
                temp = 0;
                index_counter = 0;

                //this loop controls if a word is repeated in the text.If there's more than one word that corresponds output only prints it one time.
                for (int j = i - 1; j >= 0; j--)
                {
                    if (words[i] == words[j])
                    {
                        flag = false;
                    }
                }


                if (flag)
                {
                    Console.WriteLine(control_words[i]);
                    word_counter++;
                }

                flag = true;
            }
            // if there is no corresponding words( if program didn't print any words or any error messages) program prints that situation.
            //if (word_counter == 0 && pattern.Contains('*'))
            //{
            //    Console.WriteLine("There is no corresponding words.");
            //}
            for (int s = 0; s < pattern.Length; s++)
            {
                if (pattern[s] == '-')
                    symbol_counter++;

            }

            for (int i = 0; i < words.Length; i++)
            {
                if (pattern != "")
                {
                    if (pattern[0] == '-')
                    {
                        temp = 1;
                        index = 1;
                    }
                }

                for (int j = 0; j < symbol_counter + 1; j++)
                {
                    if (pattern.Contains('-'))
                    {

                        index = pattern.IndexOf('-', index_counter);


                        if (words[i].Length >= pattern.Length)
                        {
                            if (index > 0)
                            {
                                if (!words[i].Substring(temp, words[i].Length - temp).Contains(pattern.Substring(temp, index - temp)))
                                {
                                    flag = false;
                                }
                            }
                            if (index < 0)
                            {
                                if (!words[i].Substring(temp, words[i].Length - temp).Contains(pattern.Substring(temp, pattern.Length - temp)))
                                {
                                    flag = false;
                                }

                            }
                            temp = index + 1;
                            index_counter = index + 1;

                        }
                        else
                            flag = false;


                    }
                    else if (!pattern.Contains('-'))
                        flag = false;
                    if (!flag)
                        break;



                }
                temp = 0;
                index_counter = 0;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (words[i] == words[j])
                    {
                        flag = false;
                    }
                }

                //in addition to other symbol this one also checks if the word and the patterns lenght are same.That makes the - symbol in pattern corresponds one letter in word
                if (flag && words[i].Length == pattern.Length)
                {
                    Console.WriteLine(control_words[i]);
                    word_counter++;
                }
                flag = true;
            }
            // if there is no corresponding words( if program didn't print any words or any error messages) program prints that situation.
            if (word_counter == 0)
            {
                Console.WriteLine("There is no corresponding words.");
            }
            Console.ReadLine();
        }
    }
}
