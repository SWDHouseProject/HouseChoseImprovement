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
        
        public float[,] matrix;
        public float[] centroids;
        public float[] average;
        private int counter=0;
        public void Initialize(params float[] value) //params int[] value
        {
            int dimension = CountMatrixLength(value);
            matrix = new float[dimension,dimension];
            average = new float[dimension];
            centroids = new float[dimension];

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

        public float[] startCounting()
        {
            CalculateCentroids();
            CalculateVectorMatrix();
            return CalculateAverage();
        }

        public int CountMatrixLength(float[] v)
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

        public float[] CalculateAverage()
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
