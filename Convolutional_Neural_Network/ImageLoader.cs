using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using System;

namespace Convolutional_Neural_Network
{
    public class ImageLoader
    {
        private string m_imagePath;
        private int m_targetCompressDimentionX;
        private int m_targetCompressDimentionY;

        private ImageLoader() { }

        public ImageLoader(string imagePath, int targetCompressDimentionX, int targetCompressDimentionY)
        {
            m_imagePath = imagePath;
            m_targetCompressDimentionX = targetCompressDimentionX;
            m_targetCompressDimentionY = targetCompressDimentionY;
        }

        public double[,] LoadImage(string imageName)
        {
            // Загрузка и стандартизация изображения:
            BitmapImage bitmapImage = new BitmapImage(new Uri(m_imagePath + "\\" + imageName, UriKind.RelativeOrAbsolute));

            // Обесцвечивание
            bitmapImage = Discolor(bitmapImage);

            // Save photo - FOR TEST
            FileStream stream = new FileStream("empty.png", FileMode.Create);
            TiffBitmapEncoder encoder = new TiffBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            encoder.Save(stream);

            // Отцифровка изображения
            byte[] imageByteArray = ConvertToByteArray(bitmapImage);

            // Color clr = Color.FromArgb(imageByteArray[79]);

            //// Загрузка и стандартизация изображения:
            //BitmapImage img = new BitmapImage(new System.Uri(m_imagePath + imageName));

            //img = Compress(img);

            //img = Discolor(img);

            //// Отцифровка изображения:
            //return ConvertToMatrix(img);

            return null;
        }

        private BitmapImage Discolor(BitmapImage img)
        {
            // Create a new image using FormatConvertedBitmap and set DestinationFormat to GrayScale
            //FormatConvertedBitmap grayBitmap = new FormatConvertedBitmap();

            //grayBitmap.BeginInit();
            //grayBitmap.Source = img;
            //grayBitmap.DestinationFormat = PixelFormats.Gray16;
            //grayBitmap.EndInit();

            img.BeginInit();
            img.DestinationFormat = PixelFormats.Gray16;
            img.EndInit();

            return (BitmapImage)grayBitmap.Source;
        }

        private byte[] ConvertToByteArray(BitmapImage bitmapImage)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }

            return data;
        }

        public BitmapImage ToImage(byte[] array)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = new MemoryStream(array);
            image.EndInit();
            return image;
        }

        //private BitmapImage Compress(BitmapImage img)
        //{
        //    img.BeginInit();
        //    img.DecodePixelHeight = m_targetCompressDimentionY;
        //    img.DecodePixelWidth = m_targetCompressDimentionX;
        //    img.EndInit();

        //    Bitmap n = new Bitmap();

        //    return img;
        //}

        //private double[,] ConvertToMatrix(Image img)
        //{
        //    double[,] matrix = new double[img.Height, img.Weight];

        //    for (int i = 0; i < matrix.GetLength(0); i++)
        //    {
        //        for (int k = 0; k < matrix.GetLength(1); k++)
        //        {
        //            matrix[i, k] = img.GetPixel(k, i).ToArgb();
        //        }
        //    }

        //    return matrix;
        //}

        private double DiscreteRationing(int absValue)
        {
            double maxValue = 16777216;

            double value = absValue * -1;

            return value / maxValue;
        }
    }
}

