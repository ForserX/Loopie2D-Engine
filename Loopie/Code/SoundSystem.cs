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
        private Loopie2D.LuaAPI lua = new Loopie2D.LuaAPI();
        /// File Manager
        // Empty Constructor
        public Sound()
        {  }
        public void SetSound(string file_name)
        {
            // Checking our file 
            string[] files = Directory.GetDirectories(Loopie2D.LuaAPI.snd);
            string[] files1, files2, files3, files4, files5, files6, files7, files8, files9, files10;
            FileInfo file1, file2, file3, file4, file5, file6, file7, file8, file9, file10;

            foreach (string a in files)
            {
                files = Directory.GetDirectories(a);
                files1 = Directory.GetFiles(a);
                foreach (string a1 in files1)
                {
                    file1 = new FileInfo(a1);
                    if (file1.Exists)
                        if (file1.Name == file_name)
                        {
                            file_ogg = new FileStream(file1.FullName, FileMode.Open, FileAccess.Read);
                            master_sound = new SoundPlayer(new OggDecodeStream(file_ogg));
                        }
                }

                foreach (string b in files)
                {
                    files = Directory.GetDirectories(b);
                    files2 = Directory.GetFiles(b);
                    foreach (string b1 in files2)
                    {
                        file2 = new FileInfo(b1);
                        if (file2.Exists)
                            if (file2.Name == file_name)
                            {
                                file_ogg = new FileStream(file2.FullName, FileMode.Open, FileAccess.Read);
                                master_sound = new SoundPlayer(new OggDecodeStream(file_ogg));
                            }
                    }


                    foreach (string c in files)
                    {
                        files = Directory.GetDirectories(c);
                        //    Console.WriteLine(c);
                        files3 = Directory.GetFiles(c);
                        foreach (string c1 in files3)
                        {
                            file3 = new FileInfo(c1);
                            if (file3.Exists)
                                if (file3.Name == file_name)
                                {
                                    file_ogg = new FileStream(file3.FullName, FileMode.Open, FileAccess.Read);
                                    master_sound = new SoundPlayer(new OggDecodeStream(file_ogg));
                                }

                        }

                        foreach (string d in files)
                        {
                            files = Directory.GetDirectories(d);
                            files4 = Directory.GetFiles(d);
                            foreach (string d1 in files4)
                            {
                                file4 = new FileInfo(d1);
                                if (file4.Exists)
                                    if (file4.Name == file_name)
                                    {
                                        file_ogg = new FileStream(file4.FullName, FileMode.Open, FileAccess.Read);
                                        master_sound = new SoundPlayer(new OggDecodeStream(file_ogg));
                                    }
                            }

                            foreach (string e in files)
                            {
                                files = Directory.GetDirectories(e);
                                files5 = Directory.GetFiles(e);
                                foreach (string e1 in files5)
                                {
                                    file5 = new FileInfo(e1);
                                    if (file5.Exists)
                                    {
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
                                    files6 = Directory.GetFiles(f);
                                    foreach (string f1 in files6)
                                    {
                                        file6 = new FileInfo(f1);
                                        if (file6.Exists)
                                            if (file6.Name == file_name)
                                            {
                                                file_ogg = new FileStream(file6.FullName, FileMode.Open, FileAccess.Read);
                                                master_sound = new SoundPlayer(new OggDecodeStream(file_ogg));
                                            }
                                    }

                                    foreach (string g in files)
                                    {
                                        files = Directory.GetDirectories(g);
                                        files7 = Directory.GetFiles(g);
                                        foreach (string g1 in files7)
                                        {
                                            file7 = new FileInfo(g1);
                                            if (file7.Exists)
                                                if (file7.Name == file_name)
                                                {
                                                    file_ogg = new FileStream(file7.FullName, FileMode.Open, FileAccess.Read);
                                                    master_sound = new SoundPlayer(new OggDecodeStream(file_ogg));
                                                }
                                        }

                                        foreach (string h in files)
                                        {
                                            files = Directory.GetDirectories(h);
                                            files8 = Directory.GetFiles(h);
                                            foreach (string h1 in files8)
                                            {
                                                file8 = new FileInfo(h1);
                                                if (file8.Exists)
                                                    if (file8.Name == file_name)
                                                    {
                                                        file_ogg = new FileStream(file8.FullName, FileMode.Open, FileAccess.Read);
                                                        master_sound = new SoundPlayer(new OggDecodeStream(file_ogg));
                                                    }
                                            }

                                            foreach (string i in files)
                                            {
                                                files = Directory.GetDirectories(i);
                                                files9 = Directory.GetFiles(i);
                                                foreach (string i1 in files9)
                                                {
                                                    file9 = new FileInfo(i1);
                                                    if (file9.Exists)
                                                        if (file9.Name == file_name)
                                                        {
                                                            file_ogg = new FileStream(file9.FullName, FileMode.Open, FileAccess.Read);
                                                            master_sound = new SoundPlayer(new OggDecodeStream(file_ogg));
                                                        }
                                                }

                                                foreach (string j in files)
                                                {
                                                    files = Directory.GetDirectories(j);
                                                    files10 = Directory.GetFiles(j);
                                                    foreach (string j1 in files10)
                                                    {
                                                        file10 = new FileInfo(j1);
                                                        if (file10.Exists)
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

        public void play()
        { master_sound.Play(); }
        public void stop()
        { master_sound.Stop(); }
        public void playSync()
        { master_sound.PlaySync(); }
    }
}
