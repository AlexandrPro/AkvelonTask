using AkvelonTask.BLL.Interfaces;
using AkvelonTask.BLL.Managers;
using AkvelonTask.DAL.Interfaces;
using AkvelonTask.DAL.ReadFromFile;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkvelonTask
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IGetMatrix>().To<MatrixReader>();
            kernel.Bind<IMatrixManager>().To<MatrixManager>();

            MatrixOperations matrixOperations = new MatrixOperations(kernel);
            while (true)
            {
                matrixOperations.Go();
            }
        }
    }
}
