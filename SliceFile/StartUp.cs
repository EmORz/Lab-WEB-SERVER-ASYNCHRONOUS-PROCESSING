using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SliceFile
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Insert path to video: ");
            var videoPath = "C:\\Users\\User\\source\\repos\\Lab_WEB_SERVER _ASYNCHRONOUS_PROCESSING\\Lab-WEB-SERVER-ASYNCHRONOUS-PROCESSING\\SliceFile\\bin\\Debug\\netcoreapp2.1\\СофтУни екип - Мотивирай се.mp3";
            Console.WriteLine("Insert destination - where you want to save, tokens of file?");
            var destination = "C:\\Users\\User\\source\\repos\\Lab_WEB_SERVER _ASYNCHRONOUS_PROCESSING\\Lab-WEB-SERVER-ASYNCHRONOUS-PROCESSING\\SliceFile\\bin\\Debug\\netcoreapp2.1\\NewFile";
            int pieces = 4;


            //todo - its work but there is problem with read video file . for audio is ok :)
            SliceAsync(videoPath, destination, pieces);
            
            Console.WriteLine("Anything else?");

            while (true)
            {
                Console.ReadLine();
            }

        }
        public static void SliceAsync(string videoPath, string destinationPath, int pieces)
        {
            Slicing slicing = new Slicing();
            Task.Run(() =>
            {
                slicing.Slice(videoPath, destinationPath, pieces);
            });
        }
    }
}
