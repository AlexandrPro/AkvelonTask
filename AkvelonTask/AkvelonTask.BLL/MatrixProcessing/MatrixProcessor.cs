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
            int maxSequence = 0, rowSequence = 0, lineSequence = 0;

            for (int i = 0; i < matrix.Count; i++)
            {
                lineSequence = lineSearch(i);
                if(lineSequence > maxSequence )
                {
                    maxSequence = lineSequence;
                }
            }

            for (int i = 0; i < matrix[0].Count; i++)
            {
                rowSequence = rowSearch(i);
                if (rowSequence > maxSequence)
                {
                    maxSequence = rowSequence;
                }
            }
            
            return maxSequence;
        }

        private int lineSearch(int lineNum)
        {
            int sequence = 0, max = 0;
            for (int j = 0; j < matrix[lineNum].Count; j++)
            {
                if (matrix[lineNum][j] == 0)
                {
                    sequence = 0;
                }
                else
                {
                    ++sequence;
                    if (sequence > max)
                    {
                        max = sequence;
                    }
                }
            }
            return max;
        }

        private int rowSearch(int rowNum)
        {
            int sequence = 0, max = 0;
            for (int i = 0; i < matrix.Count; i++)
            {
                if (matrix[i][rowNum] == 0)
                {
                    sequence = 0;
                }
                else
                {
                    ++sequence;
                    if (sequence > max)
                    {
                        max = sequence;
                    }
                }
            }
            return max;
        }
    }
}
