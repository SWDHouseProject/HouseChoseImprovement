using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HouseSupportSystem
{
    class AHP
    {
        double[] r = { 0, 0, 0.58, 0.90, 1.12, 1.24, 1.32, 1.41, 1.45, 1.49, 1.51, 1.53, 1.55, 1.57, 1.58 };
        public double[,] matrix;
        public double[] centroids;
        public double[] average;
        private int counter=0;
        public void Initialize(params double[] value) //params int[] value
        {
            int dimension = CountMatrixLength(value);
            matrix = new double[dimension,dimension];
            average = new double[dimension];
            centroids = new double[dimension];

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                //average[i] = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                        matrix[i, j] = 1;
                    else
                    {
                        if (i < j)
                        {
                            matrix[i, j] = value[counter];
                            counter++;
                            matrix[j, i] = 1/matrix[i, j];
                        }
                    }
                }
            } 
            
        }

        public double[] startCounting()
        {
            CalculateCentroids();
            CalculateVectorMatrix();
            return CalculateAverage();
        }

        public double CalculateConsistency()
        {
            double sum = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                sum += centroids[i]*average[i];
            }
            sum = (sum - matrix.GetLength(1))/(matrix.GetLength(1) - 1);
            sum = sum/r[matrix.GetLength(1)-1];
            return sum;

        }

        public int CountMatrixLength(double[] v)
        {
      
            int counter = 0;
            for (int i = 1; i <= v.Length; i++)
            {
                if(counter == v.Length)
                    return i;
                counter += i;
            }
            return 0;

        }

        public void CalculateCentroids()
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    centroids[i] += matrix[j,i];
                }
            }
        }

        public void CalculateVectorMatrix()
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix[i, j]/centroids[j];
                }
            }
        }

        public double[] CalculateAverage()
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    average[i] += (matrix[i,j] / matrix.GetLength(1));
                }
            }
            return average;
        }
    }
}
