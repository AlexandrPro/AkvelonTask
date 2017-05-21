using System;
using Ninject;
using AkvelonTask.BLL.Interfaces;

namespace AkvelonTask
{
    public class MatrixOperations
    {
        private IMatrixManager matrixManager;

        public MatrixOperations(IKernel kernel)
        {
            this.matrixManager = kernel.Get<IMatrixManager>();
        }

        public void Go()
        {
            Console.WriteLine("Enter file path:");
            string filePath = Console.ReadLine();
            try
            {
                matrixManager.SetNewMatrix(filePath);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string matrix = matrixManager.GetWorkMatrix();
            Console.WriteLine();
            Console.WriteLine(matrix);
            int n = matrixManager.LongestSequenceOfOne();
            Console.WriteLine("the longest sequence of 1's either row wise or column wise = "
                + n);

            Console.WriteLine("---------------------------");
        }
    }
}
