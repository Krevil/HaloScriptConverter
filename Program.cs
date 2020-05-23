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
                Console.WriteLine(File1.Length);
                List<byte> File1List = File1.ToList(); //Convert to list because removing elements from arrays is yucky
                Console.WriteLine(File1List.Capacity);
                int File1ListCapacity = File1List.Capacity;
                for (int i = 0; i < File1ListCapacity; i = i + 23) //Loop through the file, del first byte 
                {
                    {
                        File1List.RemoveAt(i);
                        File1ListCapacity = File1ListCapacity-1; //The list is now one element less, so it doesn't try to go over capacity do this
                    }
                }
                for (int i = 0; i < File1ListCapacity; i = i + 22) //Repeat the loops four times because there's four bytes that need to go
                {
                    {
                        File1List.RemoveAt(i);
                        File1ListCapacity = File1ListCapacity - 1;
                    }
                }
                for (int i = 0; i < File1ListCapacity; i = i + 21)
                {
                    {
                        File1List.RemoveAt(i);
                        File1ListCapacity = File1ListCapacity - 1;
                    }
                }
                for (int i = 0; i < File1ListCapacity; i = i + 20)
                {
                    {
                        File1List.RemoveAt(i);
                        File1ListCapacity = File1ListCapacity - 1;
                    }
                }
                byte[] File1Array = File1List.ToArray(); //Back to an array so we can write it to file
                File.WriteAllBytes(string2, File1Array);

            }
            catch
            {
                Console.WriteLine("Sorry, those aren't the right arguments. Try this: \nHaloScriptConverter NameofFile NameofNewFile");
            }
        }
    }
}
