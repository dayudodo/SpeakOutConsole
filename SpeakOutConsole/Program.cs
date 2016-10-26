﻿using System;
using System.Speech.Synthesis;
using System.Configuration;
using System.IO;
using System.Linq;

namespace SampleSynthesis
{
    public class Speaker{
        private static SpeechSynthesizer msSpeech ;
        public Speaker()
        {
            if (null==msSpeech)
            {
                msSpeech = new SpeechSynthesizer();
            }
        }
        /// <summary>
        /// 朗读指定的句子，并且保存到指定的文件中
        /// </summary>
        /// <param name="phrase"></param>
        /// <param name="outputWaveFileName"></param>
        public void speakToWaveFile(string phrase, string outputWaveFileName = "")
        {
            string voiceEngineName = ConfigurationManager.AppSettings["voiceEngineName"];
            if (string.IsNullOrEmpty(outputWaveFileName))
            {
                outputWaveFileName = ConfigurationManager.AppSettings["outputWaveFileName"];
            }

            msSpeech.SelectVoice(voiceEngineName);
            msSpeech.SetOutputToWaveFile(outputWaveFileName);
            msSpeech.Speak(phrase);

        }
    }

    class Program
    {
       

        static void Main(string[] args)
        {

            // Initialize a new instance of the SpeechSynthesizer.
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.SelectVoice("Microsoft Lili");


            //Console.WriteLine("{0},{1}", enginaName, readText);

            //synth.SelectVoice(voiceEngineName);
            //// Configure the audio output. 
            ////synth.SetOutputToDefaultAudioDevice();
            //synth.SetOutputToWaveFile(outputWaveFileName);

            //// Speak a string.
            //synth.SpeakAsync(sampleText);
            //synth.Dispose();//不能直接释放掉，如此，啥也不会发生。
            //speakToWaveFile(sampleText, outputWaveFileName);
            //Node node = Node.FromFile("biposition_2.yml");
            //node = Node.Parse("- item1\n- item2\n");
            //Console.WriteLine(node);
                        
            //string sampleText = ConfigurationManager.AppSettings["sampleText"];
            //string outputWaveFileName = ConfigurationManager.AppSettings["outputWaveFileName"];

            string inputFileName = ConfigurationManager.AppSettings["inputFileName"];
            //sp.speakToWaveFile(sampleText, outputWaveFileName);

            System.String[] readTexts = File.ReadAllLines(inputFileName);
            //去掉重复的字符串
            readTexts = (from item in readTexts
                         select item).Distinct().ToArray();
            //如果没有命令行，就读取yml文件来生成，如果有参数，那么就生成需要朗读的句子们
            if (args.Length == 0)
            {
                foreach (String read_text in readTexts)
                {
                    //在yml文件中，课程文件只有一级，需要发音的都是以-开头，示例文件：biAnimal.yml
                    if (read_text.StartsWith("-"))
                    {
                        string phrase = read_text.Substring(2);
                        string fileName = (read_text.Substring(2) + ".wav").ToLower();
                        
                        wavToFile(phrase, fileName);
                    }
                }
            }
            else
            {
                foreach (var item in args)
                {
                    string fileName = (item + ".wav").ToLower();
                    wavToFile(item, fileName);
                }
            }


            //Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        static void wavToFile(string phrase, string filename)
        {
            Speaker sp = new Speaker();
            //写文件的时候使用小写，以在linux上更好的使用，并不需要头字母大字
            if (File.Exists(filename))
            {
                Console.WriteLine("!!! file already exit:{0} !!!", filename);
            }
            else
            {
                sp.speakToWaveFile(phrase, filename);
                //Console.WriteLine(fileName);
                Console.WriteLine("{0} TTS spoke. ", filename);
            }
        }
    }
}