using System;
using Ninject;
using AkvelonTask.BLL.Interfaces;

namespace AkvelonTask
{
    public class MatrixOperations
    {
        private readonly IMatrixManager matrixManager;

        public MatrixOperations(IKernel kernel)
        {
            this.matrixManager = kernel.Get<IMatrixManager>();
        }

        public void Go()
        {
            Console.WriteLine("Enter file path:");
            string filePath = Console.ReadLine();
            matrixManager.SetNewMatrix(filePath);
            Console.WriteLine(matrixManager.GetMatrix());
            Console.WriteLine("---------------------------");
            int n = matrixManager.LongestSequenceOfOne();
            Console.WriteLine("the longest sequence of 1's either row wise or column wise = "
                + n);
        }
    }
}
