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
                string string3 = args[2]; //So it uses the args like all the big boy programs
                string string4 = args[3];
                byte[] File1 = File.ReadAllBytes(string3);
                List<byte> File1List = File1.ToList(); //Convert to list because removing elements from arrays is yucky
                int File1ListCapacity = File1List.Capacity;
                if ((string1.ToLower() == "reach") && (string2.ToLower() == "h3mcc")) //no byte stripping, yay!
                {
                    for (int i = 2; i < File1ListCapacity; i = i + 24) //Looks for opcodes of a value and changes them if they exist
                    {
                        {
                            if ((File1List[i] == 4) && (File1List[i + 1] == 0)) //if
                            {
                                File1List[i] = 2;
                            }
                            if ((File1List[i] == 6) && (File1List[i + 1] == 0) && (File1List[i + 2] == 5)) //set
                            {
                                File1List[i] = 4;
                            }
                            if ((File1List[i] == 16) && (File1List[i + 1] == 0) && (File1List[i + 2] == 5)) //equals
                            {
                                File1List[i] = 13;
                            }
                            if ((File1List[i] == 18) && (File1List[i + 1] == 0) && (File1List[i + 2] == 5))//greater than
                            {
                                File1List[i] = 15;
                            }
                            if ((File1List[i] == 21) && (File1List[i + 1] == 0) && (File1List[i + 2] == 5)) //less than equals
                            {
                                File1List[i] = 18;
                            }
                            if ((File1List[i] == 22) && (File1List[i + 1] == 0)) //sleep
                            {
                                File1List[i] = 19;
                            }
                            if ((File1List[i] == 24) && (File1List[i + 1] == 0)) //sleep_until
                            {
                                File1List[i] = 21;
                            }
                            if ((File1List[i] == 28) && (File1List[i + 1] == 0)) //zone_set
                            {
                                File1List[i] = 27;
                            }
                            if ((File1List[i] == 242) && (File1List[i + 1] == 3)) //fade_in
                            {
                                File1List[i] = 30;
                            }
                            if ((File1List[i] == 0) && (File1List[i + 1] == 4)) //cinematic_stop
                            {
                                File1List[i] = 33;
                                File1List[i + 1] = 3;
                            }
                            if ((File1List[i] == 3) && (File1List[i + 1] == 4)) //cinematic_show_letterbox
                            {
                                File1List[i] = 36;
                                File1List[i + 1] = 1;
                            }
                            if ((File1List[i] == 4) && (File1List[i + 1] == 4)) //cinematic_show_letterbox_immediate
                            {
                                File1List[i] = 37;
                                File1List[i + 1] = 3;
                            }
                            if ((File1List[i] == 5) && (File1List[i + 1] == 4)) //cinematic_set_title
                            {
                                File1List[i] = 38;
                                File1List[i + 1] = 3;
                            }
                            if ((File1List[i] == 56) && (File1List[i + 2] != 78)) //players
                            {
                                File1List[i] = 39;
                            }
                            if ((File1List[i] == 99) && (File1List[i + 1] == 0)) //object_create_anew
                            {
                                File1List[i] = 48;
                            }
                            if ((File1List[i] == 54) && (File1List[i + 1] != 1)) //team
                            {
                                File1List[i] = 51;
                            }
                            if ((File1List[i] == 78) && (File1List[i + 2] != 78)) //list_count
                            {
                                File1List[i] = 52;
                            }
                            if ((File1List[i] == 78) && (File1List[i + 2] == 78)) //object_name
                            {
                                File1List[i] = 72;
                            }
                            if ((File1List[i] == 169) && (File1List[i + 1] == 1)) //ai_place
                            {
                                File1List[i] = 74;
                            }
                            if ((File1List[i] == 207) && (File1List[i + 1] == 1)) //ai_allegiance
                            {
                                File1List[i] = 95;
                            }
                            if ((File1List[i] == 122) && (File1List[i + 1] == 4)) //game_save
                            {
                                File1List[i] = 95;
                                File1List[i + 1] = 3;
                            }
                            if ((File1List[i] == 234) && (File1List[i + 1] == 1)) //ai_living_count
                            {
                                File1List[i] = 122;
                            }
                            if ((File1List[i] == 189) && (File1List[i + 1] == 0)) //random_range
                            {
                                File1List[i] = 147;
                            }
                            if ((File1List[i] == 59) && (File1List[i + 1] == 3)) //camera_control
                            {
                                File1List[i] = 149;
                                File1List[i + 1] = 2;
                            }
                            if ((File1List[i] == 100) && (File1List[i + 1] == 3)) //player_enable_input
                            {
                                File1List[i] = 186;
                                File1List[i + 1] = 2;
                            }
                            if ((File1List[i] == 106) && (File1List[i + 1] == 3)) //player_camera_control
                            {
                                File1List[i] = 191;
                                File1List[i + 1] = 2;
                            }
                            if ((File1List[i] == 250) && (File1List[i + 1] == 4)) //chud_cinematic_fade
                            {
                                File1List[i] = 213;
                                File1List[i + 1] = 3;
                            }
                            if ((File1List[i] == 180) && (File1List[i + 1] == 3)) //switch_zone_set (arg zoneset)
                            {
                                File1List[i] = 228;
                                File1List[i + 1] = 3;
                            }
                        }
                    }
                    for (int i = 4; i < File1ListCapacity; i = i + 24) //Value types
                    {
                        {
                            if (File1List[i] == 54) //team
                            {
                                File1List[i] = 51;
                            }
                            if (File1List[i] == 32) //object_list
                            {
                                File1List[i] = 31;
                            }
                            if (File1List[i] == 78) //object_name
                            {
                                File1List[i] = 72;
                            }
                        }

                    }
                    byte[] File1Array = File1List.ToArray(); //Back to an array so we can write it to file
                    File.WriteAllBytes(string4, File1Array);
                    Console.WriteLine("Operation completed successfully.");
                }
                if ((string1.ToLower() == "reach") && (string2.ToLower() == "h2mcc"))
                {
                    for (int i = 2; i < File1ListCapacity; i = i + 24) //Looks for opcodes of a value and changes them if they exist
                    {
                        {
                            if ((File1List[i] == 78) && (File1List[i + 2] != 78))
                            {
                                File1List[i] = 38;
                            }
                            if ((File1List[i] == 78) && (File1List[i + 2] == 78))
                            {
                                File1List[i] = 56;
                            }
                            if (File1List[i] == 28)
                            {
                                File1List[i] = 31;
                            }
                            if (File1List[i] == 189)
                            {
                                File1List[i] = 124;
                            }
                            if ((File1List[i] == 169) && (File1List[i + 1] == 1))
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
                            if ((File1List[i] == 234) && (File1List[i + 1] == 1))
                            {
                                File1List[i] = 71;
                            }
                            if ((File1List[i] == 207) && (File1List[i + 1] == 1))
                            {
                                File1List[i] = 54;
                            }
                            if ((File1List[i] == 56) && (File1List[i + 2] != 78))
                            {
                                File1List[i] = 28;
                            }
                            if ((File1List[i] == 54) && (File1List[i + 1] != 1))
                            {
                                File1List[i] = 45;
                            }
                            if ((File1List[i] == 4) && (File1List[i + 1] != 4))
                            {
                                File1List[i] = 2;
                            }
                            if ((File1List[i] == 250) && (File1List[i + 1] == 4))
                            {
                                File1List[i] = 113;
                                File1List[i + 1] = 2;
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
                            if ((File1List[i] == 251) && (File1List[i + 1] == 1) && (File1List[i + 2] == 19)) //VS_Role, being used as a substitute for switch bsp
                            {
                                File1List[i + 2] = 4;
                            }
                            if (File1List[i] == 99)
                            {
                                File1List[i] = 48;
                            }
                            if ((File1List[i] == 6) && (File1List[i + 2] != 6))
                            {
                                File1List[i] = 4;
                            }
                            if ((File1List[i] == 16) && (File1List[i + 2] != 16))
                            {
                                File1List[i] = 13;
                            }
                            if ((File1List[i] == 180) && (File1List[i + 1] == 3)) //switch_zone_set (arg zoneset)
                            {
                                Console.WriteLine("switch_zone_set Function not supported in Halo 2");
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
                            if (File1List[i] == 78)
                            {
                                File1List[i] = 56;
                            }
                            if ((File1List[i] == 78) && (File1List[i - 2] == 251))
                            {
                                File1List[i] = 4;
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
                    File.WriteAllBytes(string4, File1Array);
                    Console.WriteLine("Operation completed successfully.");
                }
                else
                {
                    Console.WriteLine("Sorry, those aren't the right arguments. Try this: \nHaloScriptConverter OriginGame TargetGame NameofFile NameofNewFile");
                    Console.WriteLine("Example: HaloScriptConverter reach h2mcc ScriptHex NewScriptHex");
                    Console.WriteLine("Current supported conversions:");
                    Console.WriteLine("reach to h2mcc");
                }
            }
            catch
            {
                Console.WriteLine("Sorry, those aren't the right arguments. Try this: \nHaloScriptConverter OriginGame TargetGame NameofFile NameofNewFile");
                Console.WriteLine("Example: HaloScriptConverter reach h2mcc ScriptHex NewScriptHex");
                Console.WriteLine("Current supported conversions:");
                Console.WriteLine("reach to h2mcc");
                Console.WriteLine("reach to h3mcc");
            }
        }
    }
}
