using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using SliceFile.Contract;

namespace SliceFile
{
    public class Slicing : ISlice
    {
        public void Slice(string videoPath, string destinationPath, int pieces)
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (var source = new FileStream(videoPath, FileMode.Open))
            {
                FileInfo fileInfo = new FileInfo(videoPath);

                long partLength = (source.Length/ pieces) + 1;
                long currentByte = 0;

                for (int currentPart = 1; currentPart <= pieces; currentPart++)
                {
                    string filePath = string.Format("{0}/Part-{1}{2}", destinationPath, currentPart, fileInfo.Extension);

                    using (var destination = new FileStream(filePath, FileMode.Create))
                    {
                        byte[] buffer = new byte[10240];
                        while (currentByte<= partLength * currentPart)
                        {
                            int readBytesCount = source.Read(buffer, 0, buffer.Length);
                            if (readBytesCount==0)
                            {
                                break;
                            }
                            destination.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }
                    }
                }
            }
            Console.WriteLine("Slice complete.");
        }
    }
}