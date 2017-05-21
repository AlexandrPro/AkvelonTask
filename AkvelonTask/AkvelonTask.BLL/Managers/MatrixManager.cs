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
    public class MatrixManager : IMatrixManager
    {
        IGetMatrix matrixReader;
        MatrixProcessor mProcessor;

        public MatrixManager(IGetMatrix getMatrix)
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
        
        public string GetWorkMatrix()
        {
            StringBuilder matrix = new StringBuilder();
            for (int i = 0; i < mProcessor.BinaryMatrix.Count; i++)
            {
                for (int j = 0; j < mProcessor.BinaryMatrix[i].Count; j++)
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
