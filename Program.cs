using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace HaloScriptConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string string1 = args[0]; //So it uses the args like all the big boy programs
                string string2 = args[1];
                byte[] File1 = File.ReadAllBytes(string1);
                List<byte> File1List = File1.ToList(); //Convert to list because removing elements from arrays is yucky
                int File1ListCapacity = File1List.Capacity;
                for (int i = 2; i < File1ListCapacity; i = i + 24) //Looks for opcodes of a value and changes them if they exist
                {
                    {
                        if (File1List[i] == 78)
                        {
                            File1List[i] = 38;
                        }
                        if (File1List[i] == 28)
                        {
                            File1List[i] = 31;
                        }
                        if (File1List[i] == 189)
                        {
                            File1List[i] = 124;
                        }
                        if ((File1List[i] == 169) && (File1List[i+1] == 1))
                        {
                            File1List[i] = 34;
                        }
                        if (File1List[i] == 22)
                        {
                            File1List[i] = 19;
                        }
                        if (File1List[i] == 18)
                        {
                            File1List[i] = 15;
                        }
                        if ((File1List[i] == 234) && (File1List[i+1] == 1))
                        {
                            File1List[i] = 71;
                        }
                        if ((File1List[i] == 207) && (File1List[i+1] == 1))
                        {
                            File1List[i] = 54;
                        }
                        if (File1List[i] == 56)
                        {
                            File1List[i] = 28;
                        }
                        if (File1List[i] == 54)
                        {
                            File1List[i] = 45;
                        }
                        if (File1List[i] == 4)
                        {
                            File1List[i] = 2;
                        }
                        if ((File1List[i] == 250) && (File1List[i+1] == 4))
                        {
                            File1List[i] = 113;
                            File1List[i+1] = 2;
                        }
                        if ((File1List[i] == 3) && (File1List[i + 1] == 4))
                        {
                            File1List[i] = 45;
                            File1List[i + 1] = 2;
                        }
                        if (File1List[i] == 21)
                        {
                            File1List[i] = 18;
                        }
                        if (File1List[i] == 24)
                        {
                            File1List[i] = 21;
                        }
                        if ((File1List[i] == 5) && (File1List[i + 1] == 4))
                        {
                            File1List[i] = 47;
                            File1List[i + 1] = 2;
                        }
                        if ((File1List[i] == 122) && (File1List[i + 1] == 4))
                        {
                            File1List[i] = 75;
                            File1List[i + 1] = 2;
                        }
                        if ((File1List[i] == 0) && (File1List[i + 1] == 4))
                        {
                            File1List[i] = 42;
                            File1List[i + 1] = 2;
                        }
                        if ((File1List[i] == 4) && (File1List[i + 1] == 4))
                        {
                            File1List[i] = 46;
                            File1List[i + 1] = 2;
                        }
                        if ((File1List[i] == 59) && (File1List[i + 1] == 3))
                        {
                            File1List[i] = 194;
                            File1List[i + 1] = 1;
                        }
                        if ((File1List[i] == 242) && (File1List[i + 1] == 3))
                        {
                            File1List[i] = 39;
                            File1List[i + 1] = 2;
                        }
                        if ((File1List[i] == 100) && (File1List[i + 1] == 3))
                        {
                            File1List[i] = 217;
                            File1List[i + 1] = 1;
                        }
                        if ((File1List[i] == 106) && (File1List[i + 1] == 3))
                        {
                            File1List[i] = 221;
                            File1List[i + 1] = 1;
                        }
                        if ((File1List[i] == 121) && (File1List[i + 1] == 2)) //VS_Role, being used as a substitute for switch bsp
                        {
                            File1List[i] = 251;
                            File1List[i + 1] = 1;
                        }
                    }
                }
                for (int i = 4; i < File1ListCapacity; i = i + 24) //Value types, hopefully not too many of these.
                {
                    {
                        if (File1List[i] == 54)
                        {
                            File1List[i] = 45;
                        }
                        if (File1List[i] == 32)
                        {
                            File1List[i] = 31;
                        }
                    }
                }
                for (int i = 20; i < File1ListCapacity; i = i + 23) //Loop through the file, del first byte 
                {
                    {
                        File1List.RemoveAt(i);
                        File1ListCapacity = File1ListCapacity - 1; //The list is now one element less, so it doesn't try to go over capacity do this
                    }
                }
                for (int i = 20; i < File1ListCapacity; i = i + 22) //Repeat the loops four times because there's four bytes that need to go
                {
                    {
                        File1List.RemoveAt(i);
                        File1ListCapacity = File1ListCapacity - 1;
                    }
                }
                for (int i = 20; i < File1ListCapacity; i = i + 21)
                {
                    {
                        File1List.RemoveAt(i);
                        File1ListCapacity = File1ListCapacity - 1;
                    }
                }
                for (int i = 20; i < File1ListCapacity; i = i + 20)
                {
                    {
                        File1List.RemoveAt(i);
                        File1ListCapacity = File1ListCapacity - 1;
                    }
                }
                byte[] File1Array = File1List.ToArray(); //Back to an array so we can write it to file
                File.WriteAllBytes(string2, File1Array);
                Console.WriteLine("Operation completed successfully.");
            }
            catch
            {
                Console.WriteLine("Sorry, those aren't the right arguments. Try this: \nHaloScriptConverter NameofFile NameofNewFile");
            }
        }
    }
}
