using System.Collections.Generic;

namespace AkvelonTask.DAL.Interfaces
{
    public interface IGetMatrix
    {
        List<List<int>> GetMatrix(string someInformation);
    }
}
