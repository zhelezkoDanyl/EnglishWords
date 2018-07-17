using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engl;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Data.Entity;
using Engl.DataBase;

namespace test_console
{
 
    class Program
    {
        static void Main(string[] args)
        {

            // Initialize a new instance of the SpeechSynthesizer.
            SpeechSynthesizer synth = new SpeechSynthesizer();
            for (int i = -10; i < 10; i++)
            {


                // Set a value for the speaking rate.
                synth.Rate = -2;

                // Configure the audio output. 
                synth.SetOutputToDefaultAudioDevice();

                // Speak a text string synchronously.
                synth.Speak("This example speaks a string with the speaking rate set to "+i+".");

                Console.WriteLine();
                Console.WriteLine("Press any key to exit...");
               
            }
            Console.ReadKey();


        }
    }
}
