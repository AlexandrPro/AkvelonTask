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

        object maxSequenceLocker = new object();
        int maxSequence = 0;

        public int LongestSequenceOfOne()
        {
            maxSequence = 0;


            Task[] tasks1 = new Task[matrix.Count];
            for (int i = 0; i < matrix.Count; i++)
            {
                
                tasks1[i] = new Task(() =>
                {
                    lineSearch(i);
                });
                tasks1[i].Start();

                //lineSearch(i);
            }

            Task[] tasks2 = new Task[matrix[0].Count];
            for (int i = 0; i < matrix[0].Count; i++)
            {
                
                tasks2[i] = new Task(() =>
                {
                    rowSearch(i);
                });
                tasks2[i].Start();

                //rowSearch(i);
            }

            Task.WaitAll(tasks1);
            Task.WaitAll(tasks2);
            return maxSequence;
        }

        void lineSearch(int lineNum)
        {
            int sequence = 0;
            for (int j = 0; j < matrix[0].Count; j++)
            {
                if (matrix[lineNum][j] == 0)
                {
                    sequence = 0;
                }
                else
                {
                    ++sequence;
                    if (sequence > maxSequence)
                    {
                        lock (maxSequenceLocker)
                        {
                            maxSequence = sequence;
                        }
                    }
                }
            }
        }

        void rowSearch(int rowNum)
        {
            int sequence = 0;
            for (int i = 0; i < matrix.Count; i++)
            {
                if (matrix[i][rowNum] == 0)
                {
                    sequence = 0;
                }
                else
                {
                    ++sequence;
                    if (sequence > maxSequence)
                    {
                        lock (maxSequenceLocker)
                        {
                            maxSequence = sequence;
                        }
                    }
                }
            }
        }
    }
}
