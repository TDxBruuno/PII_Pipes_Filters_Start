using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using Ucu.Poo.Twitter;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            /* //EJERCICIO 1:

            //cargo imagen en IPicture
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            //filtros
            IFilter filterGreyscale = new FilterGreyscale();
            IFilter filterNegative = new FilterNegative();
            
            PipeNull pipeNull = new PipeNull();
            PipeSerial pipeSerial2 = new PipeSerial (filterNegative, pipeNull);
            PipeSerial pipeSerial = new PipeSerial (filterGreyscale, pipeSerial2);

            IPicture finalPicture = pipeSerial.Send(picture);
            provider.SavePicture(finalPicture, @"lukeFilter.jpg"); 
            
            */

            //EJERCICIO 2:

            PictureProvider provider1 = new PictureProvider();
            IPicture picture1 = provider1.GetPicture(@"luke.jpg");
            
            IFilter filterNegative = new FilterGreyscale();
            IFilter filterGreyscale = new FilterNegative();

            string intermediatePath = @"lukeintermediate.jpg";
            IFilter saveIntermediateFilter = new TransformationStep(intermediatePath, provider1);

            IPicture negativeImage = filterNegative.Filter(picture1);
            IPicture saveNegativeImage = saveIntermediateFilter.Filter(negativeImage);
            IPicture greyscaleImage = filterGreyscale.Filter(saveNegativeImage);

            string finalPath = @"lukefinal.jpg";
            provider1.SavePicture(greyscaleImage, finalPath);

        }
    }
}
