using AkvelonTask.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkvelonTask.BLL.MatrixProcessing
{
    public class MatrixProcessor 
    {
        List<List<int>> matrix = new List<List<int>>();

        public List<List<int>> BinaryMatrix
        {
            get { return matrix; }
            set
            {
                for (int i = 0; i < value.Count; i++)
                {
                    for (int j = 0; j < value[i].Count; j++)
                    {
                        if (!(value[i][j] == 0 || value[i][j] == 1))
                        {
                            throw new InvalidDataException("This is not a bynary matrix");
                        }
                    }
                    if (value[i].Count != value[0].Count)
                    {
                        throw new InvalidDataException("Number of elements in the " + i + " row does not match whis number of elements in the first row");
                    }
                }
                matrix = value;
            }
        }

        public int LongestSequenceOfOne()
        {
            int maxSequence = 0, sequence = 0;
            for(int i = 0; i < matrix.Count; i++)//rows
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        if (sequence > maxSequence)
                        {
                            maxSequence = sequence;
                        }
                        sequence = 0;
                    }
                    else
                    {
                        ++sequence;
                    }
                }
            }
            
            for (int i = 0, j = 0; i < matrix[0].Count; i++)//colnums
            {
                for (j = 0; j < matrix.Count; j++)
                {
                    if (matrix[j][i] == 0)
                    {
                        if (sequence > maxSequence)
                        {
                            maxSequence = sequence;
                        }
                        sequence = 0;
                    }
                    else
                    {
                        ++sequence;
                    }
                }
            }

            return maxSequence;
        }
    }
}
