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
                string string1 = args[0];
                string string2 = args[1];
                //string string1 = Console.ReadLine();
                //string string2 = Console.ReadLine();
                byte[] File1 = File.ReadAllBytes(string1);
                Console.WriteLine(File1.Length);
                List<byte> File1List = File1.ToList();
                Console.WriteLine(File1List.Capacity);
                int File1ListCapacity = File1List.Capacity;
                for (int i = 0; i < File1ListCapacity; i = i + 23) //You need to take into account the size of the file as it's having objects removed
                {
                    {
                        File1List.RemoveAt(i);
                        File1ListCapacity = File1ListCapacity-1;
                    }
                }
                for (int i = 0; i < File1ListCapacity; i = i + 22) //You need to take into account the size of the file as it's having objects removed
                {
                    {
                        File1List.RemoveAt(i);
                        File1ListCapacity = File1ListCapacity - 1;
                    }
                }
                for (int i = 0; i < File1ListCapacity; i = i + 21) //You need to take into account the size of the file as it's having objects removed
                {
                    {
                        File1List.RemoveAt(i);
                        File1ListCapacity = File1ListCapacity - 1;
                    }
                }
                for (int i = 0; i < File1ListCapacity; i = i + 20) //You need to take into account the size of the file as it's having objects removed
                {
                    {
                        File1List.RemoveAt(i);
                        File1ListCapacity = File1ListCapacity - 1;
                    }
                }
                byte[] File1Array = File1List.ToArray();
                //Console.WriteLine(File1Array[20]);
                File.WriteAllBytes(string2, File1Array);

            }
            catch
            {
                Console.WriteLine("Sorry, those aren't the right arguments. Try this: \nHaloScriptConverter NameofFile NameofNewFile");
            }
        }
    }
}
