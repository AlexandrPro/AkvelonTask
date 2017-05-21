using AkvelonTask.BLL.Interfaces;
using AkvelonTask.BLL.MatrixProcessing;
using AkvelonTask.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkvelonTask.BLL.Managers
{
    class MatrixManager : IMatrixManager
    {
        IGetMatrix matrixReader;
        MatrixProcessor mProcessor;

        MatrixManager(IGetMatrix getMatrix)
        {
            matrixReader = getMatrix;
            mProcessor = new MatrixProcessor();
        }

        public int LongestSequenceOfOne()
        {
            return mProcessor.LongestSequenceOfOne();
        }

        public void SetNewMatrix(string someInformation)
        {
            try
            {
                mProcessor.BinaryMatrix = matrixReader.GetMatrix(someInformation);
            }
            catch
            {
                throw;
            }
        }
        
        public string GetMatrix()
        {
            StringBuilder matrix = new StringBuilder();
            for (int i = 0; i < mProcessor.BinaryMatrix.Capacity; i++)
            {
                for (int j = 0; j < mProcessor.BinaryMatrix[i].Capacity; j++)
                {
                    matrix.Append(mProcessor.BinaryMatrix[i][j]);
                    matrix.Append(' ');
                }
                matrix.Append("|\n");
            }
            return matrix.ToString();
        }
    }
}
