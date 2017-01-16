/*
 * Author: Lord Wolf 
 * Contact: vk.com/lordwolf
 * Date of creation: 15.01.2017
 * Modified by: 
 * Last modified by (date): 
 * Description: This file have implementation of our SoundSytem
 * Additional Description: 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.IO;
using OggDecoder;

namespace SoundSystem
{
    public class Sound
    {
        private FileStream file_ogg;
        private SoundPlayer master_sound;
        /// File Manager
        private INIManager file_manager;
        private string path;
        /// File Manager
        // Empty Constructor
        private Sound()
        {  }

        public Sound(string file_name)
        {
            file_manager = new INIManager("..\\settings.ini");
            path = file_manager.GetPrivateString("global", "sound"); // Не работает я хз
            // Checking our file 
            string[] files = Directory.GetDirectories(@"C:\Users\Павел\Desktop\loopie-2d\data\sounds"); // TODO: подставить path и посмотреть, что не так
            string[] files1;
            string[] files2;
            string[] files3;
            string[] files4;
            string[] files5;
            string[] files6;
            string[] files7;
            string[] files8;
            string[] files9;
            string[] files10;

            FileInfo file1;
            FileInfo file2;
            FileInfo file3;
            FileInfo file4;
            FileInfo file5;
            FileInfo file6;
            FileInfo file7;
            FileInfo file8;
            FileInfo file9;
            FileInfo file10;

            // Task for Danil - delete my commits with this code -> Console.WriteLine();

            foreach (string a in files)
            {
                files = Directory.GetDirectories(a);
                // Console.WriteLine(a);
                files1 = Directory.GetFiles(a);
                foreach (string a1 in files1)
                {
                    //   Console.WriteLine(a1);
                    file1 = new FileInfo(a1);
                    if (file1.Exists)
                    {
                        //    Console.WriteLine(file1.Name);
                        if (file1.Name == file_name)
                        {
                            file_ogg = new FileStream(file1.FullName, FileMode.Open, FileAccess.Read);
                            master_sound = new SoundPlayer(new OggDecodeStream(file_ogg));
                        }
                    }
                }

                foreach (string b in files)
                {
                    files = Directory.GetDirectories(b);
                    //   Console.WriteLine(b);
                    files2 = Directory.GetFiles(b);
                    foreach (string b1 in files2)
                    {
                        //   Console.WriteLine(b1);
                        file2 = new FileInfo(b1);
                        if (file2.Exists)
                        {
                            //   Console.WriteLine(file2.Name);
                            if (file2.Name == file_name)
                            {
                                file_ogg = new FileStream(file2.FullName, FileMode.Open, FileAccess.Read);
                                master_sound = new SoundPlayer(new OggDecodeStream(file_ogg));
                            }
                        }

                    }


                    foreach (string c in files)
                    {
                        files = Directory.GetDirectories(c);
                        //    Console.WriteLine(c);
                        files3 = Directory.GetFiles(c);
                        foreach (string c1 in files3)
                        {
                            //   Console.WriteLine(c1);
                            file3 = new FileInfo(c1);
                            if (file3.Exists)
                            {
                                //   Console.WriteLine(file3.Name);
                                if (file3.Name == file_name)
                                {
                                    file_ogg = new FileStream(file3.FullName, FileMode.Open, FileAccess.Read);
                                    master_sound = new SoundPlayer(new OggDecodeStream(file_ogg));
                                }
                            }

                        }



                        foreach (string d in files)
                        {
                            files = Directory.GetDirectories(d);
                            //   Console.WriteLine(c);
                            files4 = Directory.GetFiles(d);
                            foreach (string d1 in files4)
                            {
                                //   Console.WriteLine(d1);
                                file4 = new FileInfo(d1);
                                if (file4.Exists)
                                {
                                    //   Console.WriteLine(file4.Name);
                                    if (file4.Name == file_name)
                                    {
                                        file_ogg = new FileStream(file4.FullName, FileMode.Open, FileAccess.Read);
                                        master_sound = new SoundPlayer(new OggDecodeStream(file_ogg));
                                    }
                                }

                            }




                            foreach (string e in files)
                            {
                                files = Directory.GetDirectories(e);
                                //  Console.WriteLine(e);
                                files5 = Directory.GetFiles(e);
                                foreach (string e1 in files5)
                                {
                                    //    Console.WriteLine(e1);
                                    file5 = new FileInfo(e1);
                                    if (file5.Exists)
                                    {
                                        //  Console.WriteLine(file5.Name);
                                        if (file5.Name == file_name)
                                        {
                                            file_ogg = new FileStream(file5.FullName, FileMode.Open, FileAccess.Read);
                                            master_sound = new SoundPlayer(new OggDecodeStream(file_ogg));
                                        }
                                    }
                                }

                                foreach (string f in files)
                                {
                                    files = Directory.GetDirectories(f);
                                    // Console.WriteLine(f);
                                    files6 = Directory.GetFiles(f);
                                    foreach (string f1 in files6)
                                    {
                                        //    Console.WriteLine(f1);
                                        file6 = new FileInfo(f1);
                                        if (file6.Exists)
                                        {
                                            //  Console.WriteLine(file6.Name);
                                            if (file6.Name == file_name)
                                            {
                                                file_ogg = new FileStream(file6.FullName, FileMode.Open, FileAccess.Read);
                                                master_sound = new SoundPlayer(new OggDecodeStream(file_ogg));
                                            }
                                        }
                                    }

                                    foreach (string g in files)
                                    {
                                        files = Directory.GetDirectories(g);
                                        //   Console.WriteLine(g);
                                        files7 = Directory.GetFiles(g);
                                        foreach (string g1 in files7)
                                        {
                                            //      Console.WriteLine(g1);
                                            file7 = new FileInfo(g1);
                                            if (file7.Exists)
                                            {
                                                //    Console.WriteLine(file7.Name);
                                                if (file7.Name == file_name)
                                                {
                                                    file_ogg = new FileStream(file7.FullName, FileMode.Open, FileAccess.Read);
                                                    master_sound = new SoundPlayer(new OggDecodeStream(file_ogg));
                                                }
                                            }
                                        }

                                        foreach (string h in files)
                                        {
                                            files = Directory.GetDirectories(h);
                                            //    Console.WriteLine(h);
                                            files8 = Directory.GetFiles(h);
                                            foreach (string h1 in files8)
                                            {
                                                //     Console.WriteLine(h1);
                                                file8 = new FileInfo(h1);
                                                if (file8.Exists)
                                                {
                                                    //   Console.WriteLine(file8.Name);
                                                    if (file8.Name == file_name)
                                                    {
                                                        file_ogg = new FileStream(file8.FullName, FileMode.Open, FileAccess.Read);
                                                        master_sound = new SoundPlayer(new OggDecodeStream(file_ogg));
                                                    }
                                                }
                                            }

                                            foreach (string i in files)
                                            {
                                                files = Directory.GetDirectories(i);
                                                //    Console.WriteLine(i);
                                                files9 = Directory.GetFiles(i);
                                                foreach (string i1 in files9)
                                                {
                                                    //    Console.WriteLine(i1);
                                                    file9 = new FileInfo(i1);
                                                    if (file9.Exists)
                                                    {
                                                        //  Console.WriteLine(file9.Name);
                                                        if (file9.Name == file_name)
                                                        {
                                                            file_ogg = new FileStream(file9.FullName, FileMode.Open, FileAccess.Read);
                                                            master_sound = new SoundPlayer(new OggDecodeStream(file_ogg));
                                                        }
                                                    }
                                                }

                                                foreach (string j in files)
                                                {
                                                    files = Directory.GetDirectories(j);
                                                    //   Console.WriteLine(j);
                                                    files10 = Directory.GetFiles(j);
                                                    foreach (string j1 in files10)
                                                    {
                                                        //     Console.WriteLine(j1);
                                                        file10 = new FileInfo(j1);
                                                        if (file10.Exists)
                                                        {
                                                            //  Console.WriteLine(file10.Name);
                                                            if (file10.Name == file_name)
                                                            {
                                                                file_ogg = new FileStream(file10.FullName, FileMode.Open, FileAccess.Read);
                                                                master_sound = new SoundPlayer(new OggDecodeStream(file_ogg));
                                                            }
                                                        }
                                                    }
                                                }


                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }


        }

        public void play()
        { master_sound.Play(); }

        public void stop()
        { master_sound.Stop(); }

        public void playSync()
        { master_sound.PlaySync(); }
    }
}
