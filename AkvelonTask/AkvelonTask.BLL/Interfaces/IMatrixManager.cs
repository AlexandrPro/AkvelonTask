using System.Collections.Generic;

namespace AkvelonTask.BLL.Interfaces
{
    public interface IMatrixManager
    {
        void SetNewMatrix(string someInformation);
        string GetWorkMatrix();
        int LongestSequenceOfOne();
    }
}
