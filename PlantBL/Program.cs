using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using static PlantBL.Images;
using System.IO;

namespace PlantBL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //PlantBL.Images.ResizeImage(@"C:\Projects\Plants\PlantsWeb\src\assets\בדיקה.jpeg", 800, 800);
            PlantBL.Images.GetImagesNamesAndResize();
        }
    }
    public class Images
    {
        public static void GetImagesNamesAndResize()
        {
            foreach (var file in System.IO.Directory.GetFiles(@"C:\Projects\Plants\PlantsRest\PlantBL\Images\"))
            {
                ResizeImage(file, 500, 500);
            }

        }


        public static void ResizeImage(string fileName, int width, int height)
        {
            if (fileName == "")
            {
                Console.WriteLine("no good");
            }

            Image image = Image.FromFile(fileName);
            var p = new Bitmap(image, width, height);
            
            var fileNameToFind = fileName.LastIndexOf(@"\");
            string fileNameToSave = fileName.Substring(fileNameToFind, fileName.Length - fileNameToFind);
            string targetWebDir = @"C:\Projects\Plants\PlantsWeb\src\assets\";
            var targetPathWeb = Path.Combine(targetWebDir, fileNameToSave);
            string fullFilePath = targetWebDir + targetPathWeb;
            if (File.Exists(fullFilePath))
            {
                Console.WriteLine("the file already exist");
            }
            else
            {
                Console.WriteLine(fileNameToSave);
                p.Save(@"C:\Projects\Plants\PlantsWeb\src\assets\"+ fileNameToSave);
                Console.WriteLine("good");
            }

        }
        
    }
}
