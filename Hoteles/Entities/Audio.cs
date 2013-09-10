using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Hoteles.Entities;

namespace WindowsFormsApplication1
{
    static public class Audio
    {
        static System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
        static public bool IsPlaying = false;
        static Mutex mutex= new Mutex();
        
        static List<string> frases = new List<string>();

        static public void play(string audioLocation)
        {
            try
            {
                sp.SoundLocation = tools.dirAudio + audioLocation;
                sp.PlaySync();
            }
            catch (Exception ex)
            {
                LoggerProxy.ErrorSinBD(ex.Message + "-" + ex.StackTrace);
            }
        }

        static public void PlayList(List<string> locations)
        {
            //frases.AddRange(locations);              
            Thread t = new Thread(new ParameterizedThreadStart(thPlayList));
            t.Start (locations);
            
        }

        static void thPlayList(object locations)
        {
            try
            {
                mutex.WaitOne();
                foreach (string file in ((List<string>)locations))
                {
                    play(file);
                }
                Thread.Sleep(1000);
                mutex.ReleaseMutex();
            }
            catch(Exception ex)
            {
                mutex.ReleaseMutex();
            }
        }

        static public void stop()
        {
            sp.Stop();
        }
    }
}
