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
                string InputGame = "null";
                string OutputGame = "null";
                string InputFile = "null";
                string OutputFile = "null";
                if (args.Length == 4)
                {
                    InputGame = args[0];
                    OutputGame = args[1];
                    InputFile = args[2];
                    OutputFile = args[3];
                }
                if (args.Length != 4)
                {
                    Console.WriteLine("Please specify an input game");
                    InputGame = Console.ReadLine();
                    Console.WriteLine("Please specify an output game");
                    OutputGame = Console.ReadLine();
                    Console.WriteLine("Please specify an input file");
                    InputFile = Console.ReadLine();
                    Console.WriteLine("Please specify an output file");
                    OutputFile = Console.ReadLine();
                }
                if ((InputGame == "null") || (OutputGame == "null"))
                {
                    throw new IndexOutOfRangeException("Hey, stop that! You're breaking my fragile code!");
                }
                byte[] File1 = File.ReadAllBytes(InputFile);
                List<byte> File1List = File1.ToList(); //Convert to list because removing elements from arrays is yucky
                int File1ListCapacity = File1List.Capacity;
                #region h3campaignforge
                /*if ((InputGame.ToLower() == "h3") && (OutputGame.ToLower() == "h3forge")) //for removing undesirables
                {
                    for (int i = 2; i < File1ListCapacity; i = i + 24) //Looks for opcodes of a value and changes them if they exist
                    {
                        {
                            if ((File1List[i] == 3) && (File1List[i + 1] == 149)) //game_save
                            {
                                File1List[i] = 3;
                                File1List[i+1] = 218; //error_geometry_show_all
                            }
                            if ((File1List[i] == 3) && (File1List[i + 1] == 152)) //game_save_immediate
                            {
                                File1List[i] = 3;
                                File1List[i + 1] = 218; //error_geometry_show_all
                            }
                            if ((File1List[i] == 4) && (File1List[i + 1] == 227)) //game_save_cinematic_skip
                            {
                                File1List[i] = 31;
                                File1List[i + 1] = 218; //error_geometry_show_all
                            }
                            if ((File1List[i] == 3) && (File1List[i + 1] == 150)) //game_save_cancel
                            {
                                File1List[i] = 3;
                                File1List[i + 1] = 218; //error_geometry_show_all
                            }
                            if ((File1List[i] == 1) && (File1List[i + 1] == 51)) //cheats_load because i'm a dense fuck
                            {
                                File1List[i] = 3;
                                File1List[i + 1] = 218; //error_geometry_show_all
                            }
                        }
                    }
                    byte[] File1Array = File1List.ToArray(); //Back to an array so we can write it to file
                    File.WriteAllBytes(OutputFile, File1Array);
                    Console.WriteLine("Operation completed successfully.");
                }*/
                #endregion
                if ((InputGame.ToLower() == "reach") && (OutputGame.ToLower() == "h3mcc")) //no byte stripping, yay!
                {
                    for (int i = 2; i < File1ListCapacity; i = i + 24) //Looks for opcodes of a value and changes them if they exist
                    {
                        {
                            if ((File1List[i] == 4) && (File1List[i + 1] == 0)) //if
                            {
                                File1List[i] = 2;
                            }
                            if ((File1List[i] == 6) && (File1List[i + 1] == 0) && (File1List[i + 2] != 6)) //set
                            {
                                File1List[i] = 4;
                            }
                            if ((File1List[i] == 7) && (File1List[i + 1] == 0) && (File1List[i + 2] != 7)) //and
                            {
                                File1List[i] = 5;
                                File1List[i + 1] = 0;
                            }
                            if ((File1List[i] == 8) && (File1List[i + 1] == 0)) //or
                            {
                                File1List[i] = 6;
                            }
                            if ((File1List[i] == 9) && (File1List[i + 1] == 0) && ((((File1List[i+2] == 2)) && (File1List[i + 4] == 9)) || ((File1List[i + 2] == 7)) && (File1List[i + 4] == 8))) //plus
                            {
                                File1List[i] = 7;
                                File1List[i + 1] = 0;
                            }
                            if ((File1List[i] == 91) && (File1List[i + 1] == 1)) //unit_get_health
                            {
                                File1List[i] = 10;
                                File1List[i + 1] = 1;
                            }
                            if ((File1List[i] == 16) && (File1List[i + 1] == 0) && (File1List[i + 2] != 16))   //equals
                            {
                                File1List[i] = 13;
                            }
                            if ((File1List[i] == 17) && (File1List[i + 1] == 0) && (File1List[i + 2] != 17))   //not equal
                            {
                                File1List[i] = 14;
                            }
                            if ((File1List[i] == 18) && (File1List[i + 1] == 0)) //greater than
                            {
                                File1List[i] = 15;
                            }
                            if ((File1List[i] == 19) && (File1List[i + 1] == 0)) //less than
                            {
                                File1List[i] = 16;
                            }
                            if ((File1List[i] == 20) && (File1List[i + 1] == 0)) //greater than or equals
                            {
                                File1List[i] = 17;
                            }
                            if ((File1List[i] == 21) && (File1List[i + 1] == 0)) //less than or equals equals
                            {
                                File1List[i] = 18;
                            }
                            if ((File1List[i] == 22) && (File1List[i + 1] == 0)) //sleep
                            {
                                File1List[i] = 19;
                            }
                            if ((File1List[i] == 23) && (File1List[i + 1] == 0)) //sleep_forever sounds nice
                            {
                                File1List[i] = 21;
                                File1List[i + 1] = 0;
                            }
                            if ((File1List[i] == 24) && (File1List[i + 1] == 0)) //sleep_until
                            {
                                File1List[i] = 22;
                            }
                            if ((File1List[i] == 30) && (File1List[i + 1] == 0)) //unit
                            {
                                File1List[i] = 25;
                            }
                            if ((File1List[i] == 25) && (File1List[i + 1] == 0) && (File1List[i + 2] == 25)) //starting profile
                            {
                                File1List[i] = 25;
                                File1List[i + 1] = 0;
                            }
                            if ((File1List[i] == 108) && (File1List[i + 1] == 1)) //unit_add_equipment
                            {
                                File1List[i] = 25;
                                File1List[i + 1] = 1;
                            }
                            if ((File1List[i] == 37) && (File1List[i + 1] == 0) && (File1List[i + 2] != 37)) //not
                            {
                                File1List[i] = 26;
                                File1List[i + 1] = 0;
                            }
                            if ((File1List[i] == 28) && (File1List[i + 1] == 0)) //zone_set
                            {
                                File1List[i] = 27;
                            }
                            if ((File1List[i] == 242) && (File1List[i + 1] == 3)) //fade_in
                            {
                                File1List[i] = 31;
                            }
                            if ((File1List[i] == 117) && (File1List[i + 1] == 1)) //device_get_position
                            {
                                File1List[i] = 32;
                                File1List[i + 1] = 1;
                            }
                            if ((File1List[i] == 118) && (File1List[i + 1] == 1)) //device_set_position_immediate
                            {
                                File1List[i] = 33;
                                File1List[i + 1] = 1;
                            }
                            if ((File1List[i] == 0) && (File1List[i + 1] == 4)) //cinematic_stop
                            {
                                File1List[i] = 34;
                                File1List[i + 1] = 3;
                            }
                            if ((File1List[i] == 37) && (File1List[i + 1] == 0)) //looping_sound
                            {
                                File1List[i] = 36;
                                File1List[i + 1] = 0;
                            }
                            if ((File1List[i] == 3) && (File1List[i + 1] == 4)) //cinematic_show_letterbox
                            {
                                File1List[i] = 37;
                                File1List[i + 1] = 3;
                            }
                            if ((File1List[i] == 4) && (File1List[i + 1] == 4)) //cinematic_show_letterbox_immediate
                            {
                                File1List[i] = 38;
                                File1List[i + 1] = 3;
                            }
                            if ((File1List[i] == 5) && (File1List[i + 1] == 4)) //cinematic_set_title
                            {
                                File1List[i] = 39;
                                File1List[i + 1] = 3;
                            }
                            if ((File1List[i] == 56) && (File1List[i + 2] != 78)) //players
                            {
                                File1List[i] = 40;
                            }
                            if ((File1List[i] == 99) && (File1List[i + 1] == 0)) //object_create_anew
                            {
                                File1List[i] = 69; //nice
                            }
                            if ((File1List[i] == 54) && (File1List[i + 1] != 1)) //team
                            {
                                File1List[i] = 51;
                            }
                            if ((File1List[i] == 77) && (File1List[i + 1] == 0)) //list_get
                            {
                                File1List[i] = 52;
                            }
                            if ((File1List[i] == 78) && ((File1List[i + 2] == 7) || (File1List[i + 2] == 2))) //list_count
                            {
                                File1List[i] = 53;
                            }
                            if ((File1List[i] == 79) && (File1List[i + 1] == 0)) //list_count_not_dead
                            {
                                File1List[i] = 54;
                                File1List[i + 1] = 0;
                            }
                            if ((File1List[i] == 109) && (File1List[i + 1] == 6)) //game_coop_player_count
                            {
                                File1List[i] = 54;
                                File1List[i + 1] = 5;
                            }
                            if ((File1List[i] == 96) && (File1List[i + 1] == 0)) //object_create
                            {
                                File1List[i] = 67;
                            }
                            if ((File1List[i] == 78) && (File1List[i + 2] == 71)) //object (named)
                            {
                                File1List[i] = 72;
                            }
                            if ((File1List[i] == 78) && ((File1List[i + 2] == 78) || (File1List[i + 2] == 75))) //object_name
                            {
                                File1List[i] = 72;
                            }
                            if ((File1List[i] == 169) && (File1List[i + 1] == 1)) //ai_place (without short arg)
                            {
                                File1List[i] = 74;
                            }
                            if ((File1List[i] == 103) && (File1List[i + 1] == 0)) //object_destroy
                            {
                                File1List[i] = 75;
                            }
                            if ((File1List[i] == 185) && (File1List[i + 1] == 1)) //ai_kill
                            {
                                File1List[i] = 80;
                                File1List[i + 1] = 1;
                            }
                            if ((File1List[i] == 69) && (File1List[i + 1] == 4)) //game_won
                            {
                                File1List[i] = 90;
                                File1List[i + 1] = 3;
                            }
                            if ((File1List[i] == 71) && (File1List[i + 1] == 4)) //game_revert
                            {
                                File1List[i] = 92;
                                File1List[i + 1] = 3;
                            }
                            if ((File1List[i] == 73) && (File1List[i + 1] == 4)) //game_is_cooperative
                            {
                                File1List[i] = 93;
                                File1List[i + 1] = 3;
                            }
                            if ((File1List[i] == 124) && (File1List[i + 1] == 0)) //object_get_health
                            {
                                File1List[i] = 94;
                            }
                            if ((File1List[i] == 207) && (File1List[i + 1] == 1)) //ai_allegiance
                            {
                                File1List[i] = 96;
                            }
                            if ((File1List[i] == 212) && (File1List[i + 1] == 1)) //ai_disregard
                            {
                                File1List[i] = 101;
                                File1List[i + 1] = 1;
                            }
                            if ((File1List[i] == 144) && (File1List[i + 1] == 0)) //object_damage_damage_section
                            {
                                File1List[i] = 111;
                                File1List[i + 1] = 0;
                            }
                            if ((File1List[i] == 152) && (File1List[i + 1] == 0)) //object_cannot_take_damage
                            {
                                File1List[i] = 117; //Green, sir
                                File1List[i + 1] = 0;
                            }
                            if ((File1List[i] == 155) && (File1List[i + 1] == 0)) //object_can_take_damage
                            {
                                File1List[i] = 118;
                                File1List[i + 1] = 0;
                            }
                            if ((File1List[i] == 234) && (File1List[i + 1] == 1)) //ai_living_count
                            {
                                File1List[i] = 123;
                            }
                            if ((File1List[i] == 166) && (File1List[i + 1] == 0)) //object_teleport
                            {
                                File1List[i] = 128;
                            }
                            if ((File1List[i] == 189) && (File1List[i + 1] == 0)) //random_range
                            {
                                File1List[i] = 148;
                            }
                            if ((File1List[i] == 59) && (File1List[i + 1] == 3)) //camera_control
                            {
                                File1List[i] = 150;
                                File1List[i + 1] = 2;
                            }
                            if ((File1List[i] == 122) && (File1List[i + 1] == 4)) //game_save
                            {
                                File1List[i] = 150;
                                File1List[i + 1] = 3;
                            }
                            if ((File1List[i] == 197) && (File1List[i + 1] == 4)) //sound_looping_start (no stringid arg)
                            {
                                File1List[i] = 171;
                                File1List[i + 1] = 3;
                            }
                            if ((File1List[i] == 199) && (File1List[i + 1] == 4)) //sound_looping_stop
                            {
                                File1List[i] = 172;
                                File1List[i + 1] = 3;
                            }
                            if ((File1List[i] == 100) && (File1List[i + 1] == 3)) //player_enable_input
                            {
                                File1List[i] = 187;
                                File1List[i + 1] = 2;
                            }
                            if ((File1List[i] == 106) && (File1List[i + 1] == 3)) //player_camera_control
                            {
                                File1List[i] = 192;
                                File1List[i + 1] = 2;
                            }
                            if ((File1List[i] == 107) && (File1List[i + 1] == 3)) //player_action_test_reset
                            {
                                File1List[i] = 193;
                                File1List[i + 1] = 2;
                            }
                            if ((File1List[i] == 113) && (File1List[i + 1] == 3)) //player_action_test_jump
                            {
                                File1List[i] = 194;
                                File1List[i + 1] = 2;
                            }
                            if ((File1List[i] == 110) && (File1List[i + 1] == 3)) //player_action_test_vision_trigger
                            {
                                File1List[i] = 197;
                                File1List[i + 1] = 2;
                            }
                            if ((File1List[i] == 111) && (File1List[i + 1] == 3)) //player_action_test_rotate_weapons
                            {
                                File1List[i] = 199;
                                File1List[i + 1] = 2;
                            }
                            if ((File1List[i] == 112) && (File1List[i + 1] == 3)) //player_action_test_rotate_grenades
                            {
                                File1List[i] = 200;
                                File1List[i + 1] = 2;
                            }
                            if ((File1List[i] == 250) && (File1List[i + 1] == 4)) //chud_cinematic_fade
                            {
                                File1List[i] = 214;
                                File1List[i + 1] = 3;
                            }
                            if ((File1List[i] == 180) && (File1List[i + 1] == 3)) //switch_zone_set (arg zoneset)
                            {
                                File1List[i] = 229;
                                File1List[i + 1] = 3;
                            }
                            if ((File1List[i] == 45) && (File1List[i + 1] == 1)) //unit_in_vehicle
                            {
                                File1List[i] = 249;
                                File1List[i + 1] = 0;
                            }
                            if ((File1List[i] == 143) && (File1List[i + 1] == 1)) //ai_enable
                            {
                                File1List[i] = 55;
                                File1List[i + 1] = 1;
                            }
                        }
                    }
                    for (int i = 4; i < File1ListCapacity; i = i + 24) //Value types
                    {
                        {
                            if (File1List[i] == 72) //unit
                            {
                                File1List[i] = 66;
                            }
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
                            if (File1List[i] == 75) //device
                            {
                                File1List[i] = 69;
                            }
                            if (File1List[i] == 71) //object
                            {
                                File1List[i] = 65;
                            }
                            if (File1List[i] == 37) //looping sound
                            {
                                File1List[i] = 36;
                            }
                        }

                    }
                    byte[] File1Array = File1List.ToArray(); //Back to an array so we can write it to file
                    File.WriteAllBytes(OutputFile, File1Array);
                    Console.WriteLine("Operation completed successfully.");
                }
                if ((InputGame.ToLower() == "reach") && (OutputGame.ToLower() == "h2mcc"))
                {
                    for (int i = 2; i < File1ListCapacity; i = i + 24) //Looks for opcodes of a value and changes them if they exist
                    {
                        {
                            if ((File1List[i] == 78) && (File1List[i + 2] != 78))
                            {
                                File1List[i] = 38;
                            }
                            if ((File1List[i] == 37) && (File1List[i + 1] == 0)) //not
                            {
                                File1List[i] = 25;
                                File1List[i + 1] = 0;
                            }
                            if ((File1List[i] == 78) && (File1List[i + 2] == 78))
                            {
                                File1List[i] = 56;
                            }
                            if (File1List[i] == 28)
                            {
                                File1List[i] = 31;
                            }
                            if ((File1List[i] == 169) && (File1List[i + 1] == 1))
                            {
                                File1List[i] = 34;
                            }
                            if (File1List[i] == 22)
                            {
                                File1List[i] = 19;
                            }
                            if (File1List[i] == 18) //greater than
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
                            if (File1List[i] == 24) //sleep_until
                            {
                                File1List[i] = 21;
                            }
                            if ((File1List[i] == 5) && (File1List[i + 1] == 4))
                            {
                                File1List[i] = 47;
                                File1List[i + 1] = 2;
                            }
                            if ((File1List[i] == 122) && (File1List[i + 1] == 4)) //game_save
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
                            if ((File1List[i] == 16) && (File1List[i + 2] != 16)) //equals
                            {
                                File1List[i] = 13;
                            }
                            if ((File1List[i] == 45) && (File1List[i + 1] == 1)) //unit_in_vehicle
                            {
                                File1List[i] = 222;
                                File1List[i+1] = 0;
                            }
                            if ((File1List[i] == 113) && (File1List[i + 1] == 3)) //player_action_test_jump
                            {
                                File1List[i] = 223;
                                File1List[i + 1] = 1;
                            }
                            if ((File1List[i] == 107) && (File1List[i + 1] == 3)) //player_action_test_reset
                            {
                                File1List[i] = 222;
                                File1List[i + 1] = 1;
                            }
                            if ((File1List[i] == 30) && (File1List[i + 1] == 0)) //unit
                            {
                                File1List[i] = 24;
                            }
                            if ((File1List[i] == 77) && (File1List[i + 1] == 0)) //list_get
                            {
                                File1List[i] = 37;
                            }
                            if ((File1List[i] == 180) && (File1List[i + 1] == 3)) //switch_zone_set (arg zoneset)
                            {
                                Console.WriteLine("Warning: switch_zone_set Function not supported in Halo 2");
                            }
                            if ((File1List[i] == 110) && (File1List[i + 1] == 3)) //player_action_test_vision_trigger
                            {
                                File1List[i] = 226;
                                File1List[i + 1] = 1;
                            }
                            if ((File1List[i] == 112) && (File1List[i + 1] == 3)) //player_action_test_rotate_grenades
                            {
                                File1List[i] = 229;
                                File1List[i + 1] = 1;
                            }
                            if ((File1List[i] == 111) && (File1List[i + 1] == 3)) //player_action_test_rotate_weapons
                            {
                                File1List[i] = 228;
                                File1List[i + 1] = 1;
                            }
                            if ((File1List[i] == 23) && (File1List[i + 1] == 0)) //sleep_forever sounds nice
                            {
                                File1List[i] = 20;
                                File1List[i + 1] = 0;
                            }
                            if ((File1List[i] == 7) && (File1List[i + 1] == 0) && (File1List[i + 2] != 7)) //and
                            {
                                File1List[i] = 5;
                                File1List[i + 1] = 0;
                            }
                            if ((File1List[i] == 212) && (File1List[i + 1] == 1)) //ai_disregard
                            {
                                File1List[i] = 58;
                                File1List[i + 1] = 1;
                            }
                            if ((File1List[i] == 185) && (File1List[i + 1] == 1)) //ai_kill
                            {
                                File1List[i] = 40;
                                File1List[i + 1] = 1;
                            }
                            if ((File1List[i] == 139) && (File1List[i + 1] == 1)) //drop being used as placeholder for hud_set_training_text
                            {
                                File1List[i] = 120;
                                File1List[i + 1] = 2;
                            }
                            if ((File1List[i] == 135) && (File1List[i + 1] == 1)) //cheat_active_camouflage being used as placeholder for hud_show_training_text
                            {
                                File1List[i] = 120;
                                File1List[i + 1] = 2;
                            }
                            if ((File1List[i] == 152) && (File1List[i + 1] == 0)) //object_cannot_take_damage
                            {
                                File1List[i] = 90;
                                File1List[i + 1] = 0;
                            }
                            if ((File1List[i] == 155) && (File1List[i + 1] == 0)) //object_can_take_damage
                            {
                                File1List[i] = 91;
                                File1List[i + 1] = 0;
                            }
                            if ((File1List[i] == 8) && (File1List[i + 1] == 0)) //or
                            {
                                File1List[i] = 6;
                            }
                            if ((File1List[i] == 124) && (File1List[i + 1] == 0)) //object_get_health
                            {
                                File1List[i] = 69; //nice
                            }
                            if ((File1List[i] == 189) && (File1List[i + 1] == 0)) //random_range
                            {
                                File1List[i] = 124;
                            }
                            if ((File1List[i] == 166) && (File1List[i + 1] == 0)) //object_teleport
                            {
                                File1List[i] = 105;
                            }
                            if ((File1List[i] == 108) && (File1List[i + 1] == 1)) //unit_add_equipment
                            {
                                File1List[i] = 250;
                                File1List[i + 1] = 0;
                            }
                            if ((File1List[i] == 25) && (File1List[i + 1] == 0) && (File1List[i + 2] == 25)) //starting profile
                            {
                                File1List[i] = 24;
                                File1List[i + 1] = 0;
                            }
                            if ((File1List[i] == 197) && (File1List[i + 1] == 4)) //sound_looping_start (no stringid arg)
                            {
                                File1List[i] = 93;
                                File1List[i + 1] = 2;
                            }
                            if ((File1List[i] == 37) && (File1List[i + 1] == 0)) //looping_sound
                            {
                                File1List[i] = 35;
                                File1List[i + 1] = 0;
                            }
                            if ((File1List[i] == 199) && (File1List[i + 1] == 4)) //sound_looping_stop
                            {
                                File1List[i] = 94;
                                File1List[i + 1] = 2;
                            }
                            if ((File1List[i] == 73) && (File1List[i + 1] == 4)) //game_is_cooperative
                            {
                                File1List[i] = 56;
                                File1List[i + 1] = 2;
                            }
                            if ((File1List[i] == 91) && (File1List[i + 1] == 1)) //unit_get_health
                            {
                                File1List[i] = 239;
                                File1List[i + 1] = 0;
                            }
                            if ((File1List[i] == 69) && (File1List[i + 1] == 4)) //game_won
                            {
                                File1List[i] = 53;
                                File1List[i + 1] = 2;
                            }
                            if ((File1List[i] == 79) && (File1List[i + 1] == 0)) //list_count_not_dead
                            {
                                File1List[i] = 39;
                                File1List[i + 1] = 0;
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
                    File.WriteAllBytes(OutputFile, File1Array);
                    Console.WriteLine("Operation completed successfully.");
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
