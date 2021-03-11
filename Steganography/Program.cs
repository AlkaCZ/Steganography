using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Steganography
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Contains("--hide"))
            {

                string msg = args[2];
                Bitmap bitmapImg = new Bitmap(args[3]);
                for (int w = 0; w < bitmapImg.Width; w++)
                {
                    for (int h = 0; h < bitmapImg.Height; h++)
                    {
                        Color pixel = bitmapImg.GetPixel(w, h);

                        if (w < 1 && h < msg.Length)
                        {
                            char letter = Convert.ToChar(msg.Substring(h, 1));
                            int value = Convert.ToInt32(letter);
                            bitmapImg.SetPixel(w, h, Color.FromArgb(pixel.R, pixel.G, value));
                        }
                        else if (w == bitmapImg.Width - 1 && h == bitmapImg.Height - 1)
                        {
                            bitmapImg.SetPixel(w, h, Color.FromArgb(pixel.R, pixel.G, msg.Length));
                        }
                    }
                }

                bitmapImg.Save("ConvertedPic.bmp");
                Console.WriteLine("DONE Converting");
                Console.ReadLine();
            }

            else if (args.Contains("--show"))
            {
                

                {
                    Bitmap bitmapImgNew = new Bitmap(args[2]);
                    string GivenMsg = "";
                    Color endPix = bitmapImgNew.GetPixel(bitmapImgNew.Width - 1, bitmapImgNew.Height - 1);
                    int GivenMsgLenght = endPix.B;

                    for (int w = 0; w < bitmapImgNew.Width; w++)
                    {
                        for (int h = 0; h < bitmapImgNew.Height; h++)
                        {
                            Color pixelEncr = bitmapImgNew.GetPixel(w, h);

                            if (w < 1 && h < GivenMsgLenght)
                            {
                                int value = pixelEncr.B;
                                char c = Convert.ToChar(value);
                                string letter = System.Text.Encoding.ASCII.GetString(new byte[] { Convert.ToByte(c) });
                                GivenMsg += letter;
                            }
                        }
                    }
                    Console.WriteLine(GivenMsg);
                }
                Console.WriteLine("DONE Reading");
                Console.ReadLine();
            }
        }
    }
}
