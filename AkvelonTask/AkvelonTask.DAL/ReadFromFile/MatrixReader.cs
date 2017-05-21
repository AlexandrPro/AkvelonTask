using System;
using System.Collections.Generic;
using System.IO;
using AkvelonTask.DAL.Interfaces;

namespace AkvelonTask.DAL.ReadFromFile
{
    public class MatrixReader : IGetMatrix
    {
        public List<List<int>> GetMatrix(string filePath)
        {
            List<List<int>> matrix = new List<List<int>>();

            using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.Default))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    List<int> row = LineToMatrixRow(line);
                }
            }
            return matrix;
        }

        private List<int> LineToMatrixRow(string line)
        {
            List<int> row = new List<int>();
            string[] nums = line.Split(' ');
            int val;
            foreach(string num in nums)
            {
                if (num != "")
                {
                    val = Int32.Parse(num);
                    row.Add(val);
                }
            }

            return row;
        }
    }
}
