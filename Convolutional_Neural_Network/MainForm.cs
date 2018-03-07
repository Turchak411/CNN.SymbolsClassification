using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Convolutional_Neural_Network
{
    public partial class Form1 : Form
    {
        private FileManager m_fileManager;
        private ImageLoader m_imageLoader;

        public Form1()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            m_fileManager = new FileManager("memory.txt");

            // Get/create data:
            m_imageLoader = new ImageLoader("images\\", 64, 64);

            List<double[,]> m_imagesInMatrixForm = new List<double[,]>();

            for (int i = 0; i < 26; i++)
            {
                m_imagesInMatrixForm.Add(m_imageLoader.LoadImageData(i.ToString() + ".png"));
            }
            //  a  b  c  d  e  f  g  h  i  j  k  l  m  n  o  p  q  r  s  t  u  v  w  x  y  z
            double[][] dataSetAnwsers = new double[5][] { new double[26] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                          new double[26] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                          new double[26] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                          new double[26] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                          new double[26] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                                                          // 26 штук
                                                          // ...
                                                        };

            // EXTRACTION:
            string extractorLayersScheme = "cpcp"; // conv-pool-conv-pool (pool = MAXpool)
            List<List<FilterName>> convFilters = CreateConvFiltersScheme();

            Extractor extractor = new Extractor(extractorLayersScheme, convFilters);


            // CLASSIFICATION:
            // Creating fullconnected-net:
            int[] neuronsScheme = new int[4] { 540, 16, 16, 26 };
            Neuronet net = new Neuronet(neuronsScheme, 5, m_fileManager);

            // Train net:
            Console.WriteLine("Training net...");

            double learningSpeed = 0;

            double[] dataSet;

            try
            {
                for (int i = 0; i < 64000; i++)
                {
                    // Пересчет величины скорости обучения:
                    learningSpeed = 0.01 * Math.Pow(0.1, i / 150000);

                    for (int k = 0; k < m_imagesInMatrixForm.Count; k++)
                    {
                        dataSet = extractor.Extract(m_imagesInMatrixForm[i]);
                        net.Handle(dataSet);
                        net.Teach(dataSet, dataSetAnwsers[k], learningSpeed);
                    }
                }

                Console.WriteLine("Training success!");
            }
            catch
            {
                Console.WriteLine("Training failed!");
            }
        }

        private static List<List<FilterName>> CreateConvFiltersScheme()
        {
            List<List<FilterName>> convFilters = new List<List<FilterName>>();

            // Conv 0:
            List<FilterName> filtersConv0 = new List<FilterName>();
            filtersConv0.Add(FilterName.Blur);
            filtersConv0.Add(FilterName.Clarity);
            filtersConv0.Add(FilterName.EdgeSelection);
            filtersConv0.Add(FilterName.Relief);
            filtersConv0.Add(FilterName.StrengthenEdge);

            // Conv 1:
            List<FilterName> filtersConv1 = new List<FilterName>();
            filtersConv1.Add(FilterName.Blur);
            filtersConv1.Add(FilterName.Clarity);
            filtersConv1.Add(FilterName.Relief);

            convFilters.Add(filtersConv0);
            convFilters.Add(filtersConv1);

            return convFilters;
        }
    }
}
