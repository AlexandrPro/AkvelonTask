using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AkvelonTask.BLL.MatrixProcessing;
using System.IO;
using System.Linq;

namespace AkvelonTask.BLLTests
{
    [TestClass]
    public class UnitTest_MatrixProcessor
    {
        [TestMethod]
        public void BinaryMatrixSet_DefaultArrey_ArreyIsEqual()
        {
            // arrange
            List<List<int>> array = new List<List<int>>();
            array.Add(new List<int>() { 0, 0, 0, 1, 0, 0 });
            array.Add(new List<int>() { 0, 0, 1, 1, 0, 0 });
            array.Add(new List<int>() { 0, 0, 0, 1, 0, 0 });
            MatrixProcessor mProc = new MatrixProcessor();
            // act
            mProc.BinaryMatrix = array;
            // assert
            Assert.AreEqual(mProc.BinaryMatrix, array);
        }

        [TestMethod]
        public void BinaryMatrixSet_SteppedArray1_InvalidDataException()
        {
            // arrange
            List<List<int>> array = new List<List<int>>();
            array.Add(new List<int>() { 1, 1, 1, 1 });
            array.Add(new List<int>() { 1, 1, 1, 1, 1 });
            MatrixProcessor mProc = new MatrixProcessor();
            // act
            try
            {
                mProc.BinaryMatrix = array;
                Assert.Fail();
            }
            // assert
            catch(Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidDataException));
            }
        }

        [TestMethod]
        public void BinaryMatrixSet_SteppedArray2_InvalidDataException()
        {
            // arrange
            List<List<int>> array = new List<List<int>>();
            array.Add(new List<int>() { 1, 1, 1, 1 });
            array.Add(new List<int>() { 1, 1, 1 });
            MatrixProcessor mProc = new MatrixProcessor();
            // act
            try
            {
                mProc.BinaryMatrix = array;
                Assert.Fail();
            }
            // assert
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidDataException));
            }
        }

        [TestMethod]
        public void BinaryMatrixSet_NotBinatyMatrix_InvalidDataException()
        {
            // arrange
            List<List<int>> array = new List<List<int>>();
            array.Add(new List<int>() { 1, 2 });
            array.Add(new List<int>() { 3, 4 });
            MatrixProcessor mProc = new MatrixProcessor();
            // act
            try
            {
                mProc.BinaryMatrix = array;
                Assert.Fail();
            }
            // assert
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidDataException));
            }
        }

        [TestMethod]
        public void LongestSequenceOfOne_Zero_Zero()
        {
            // arrange
            List<List<int>> array = new List<List<int>>();
            array.Add(new List<int>() { 0});
            MatrixProcessor mProc = new MatrixProcessor();
            mProc.BinaryMatrix = array;
            // act
            int n = mProc.LongestSequenceOfOne();
            // assert
            Assert.AreEqual(n, 0);
        }

        [TestMethod]
        public void LongestSequenceOfOne_ZeroMatrix_Zero()
        {
            // arrange
            List<List<int>> array = new List<List<int>>();
            array.Add(new List<int>() { 0, 0, 0, 0 });
            array.Add(new List<int>() { 0, 0, 0, 0 });
            array.Add(new List<int>() { 0, 0, 0, 0 });
            MatrixProcessor mProc = new MatrixProcessor();
            mProc.BinaryMatrix = array;
            // act
            int n = mProc.LongestSequenceOfOne();
            // assert
            Assert.AreEqual(n, 0);
        }

        [TestMethod]
        public void LongestSequenceOfOne_1_1()
        {
            // arrange
            List<List<int>> array = new List<List<int>>();
            array.Add(new List<int>() { 1 });
            MatrixProcessor mProc = new MatrixProcessor();
            mProc.BinaryMatrix = array;
            // act
            int n = mProc.LongestSequenceOfOne();
            // assert
            Assert.AreEqual(n, 1);
        }

        [TestMethod]
        public void LongestSequenceOfOne_SolidLine_5()
        {
            // arrange
            List<List<int>> array = new List<List<int>>();
            array.Add(new List<int>() { 1, 1, 1, 1, 1 });
            MatrixProcessor mProc = new MatrixProcessor();
            mProc.BinaryMatrix = array;
            // act
            int n = mProc.LongestSequenceOfOne();
            // assert
            Assert.AreEqual(n, 5);
        }

        [TestMethod]
        public void LongestSequenceOfOne_PiecewiseLine_3()
        {
            // arrange
            List<List<int>> array = new List<List<int>>();
            array.Add(new List<int>() { 1, 0, 1, 1, 1, 0, 1, 1 });
            MatrixProcessor mProc = new MatrixProcessor();
            mProc.BinaryMatrix = array;
            // act
            int n = mProc.LongestSequenceOfOne();
            // assert
            Assert.AreEqual(n, 3);
        }

        [TestMethod]
        public void LongestSequenceOfOne_SolidRow_5()
        {
            // arrange
            List<List<int>> array = new List<List<int>>();
            array.Add(new List<int>() { 1 });
            array.Add(new List<int>() { 1 });
            array.Add(new List<int>() { 1 });
            array.Add(new List<int>() { 1 });
            array.Add(new List<int>() { 1 });
            MatrixProcessor mProc = new MatrixProcessor();
            mProc.BinaryMatrix = array;
            // act
            int n = mProc.LongestSequenceOfOne();
            // assert
            Assert.AreEqual(n, 5);
        }

        public void LongestSequenceOfOne_PiecewiseRow_3()
        {
            // arrange
            List<List<int>> array = new List<List<int>>();
            array.Add(new List<int>() { 1 });
            array.Add(new List<int>() { 0 });
            array.Add(new List<int>() { 1 });
            array.Add(new List<int>() { 1 });
            array.Add(new List<int>() { 1 });
            array.Add(new List<int>() { 0 });
            array.Add(new List<int>() { 1 });
            array.Add(new List<int>() { 1 });
            MatrixProcessor mProc = new MatrixProcessor();
            mProc.BinaryMatrix = array;
            // act
            int n = mProc.LongestSequenceOfOne();
            // assert
            Assert.AreEqual(n, 3);
        }

        [TestMethod]
        public void LongestSequenceOfOne_LineSequenceLonger_4()
        {
            // arrange
            List<List<int>> array = new List<List<int>>();
            array.Add(new List<int>() { 0, 0, 0, 1, 0, 0 });
            array.Add(new List<int>() { 0, 1, 1, 1, 1, 0 });
            array.Add(new List<int>() { 0, 0, 0, 1, 0, 0 });
            MatrixProcessor mProc = new MatrixProcessor();
            mProc.BinaryMatrix = array;
            // act
            int n = mProc.LongestSequenceOfOne();
            // assert
            Assert.AreEqual(n, 4);
        }

        [TestMethod]
        public void LongestSequenceOfOne_RowSequenceLonger_4()
        {
            // arrange
            List<List<int>> array = new List<List<int>>();
            array.Add(new List<int>() { 0, 0, 0, 1, 0, 0 });
            array.Add(new List<int>() { 0, 1, 1, 1, 0, 0 });
            array.Add(new List<int>() { 0, 0, 0, 1, 0, 0 });
            array.Add(new List<int>() { 0, 0, 0, 1, 0, 0 });
            MatrixProcessor mProc = new MatrixProcessor();
            mProc.BinaryMatrix = array;
            // act
            int n = mProc.LongestSequenceOfOne();
            // assert
            Assert.AreEqual(n, 4);
        }

        [TestMethod]
        public void LongestSequenceOfOne_IncreasingLines_5()
        {
            // arrange
            List<List<int>> array = new List<List<int>>();
            array.Add(new List<int>() { 1, 0, 0, 0, 0, 0 });
            array.Add(new List<int>() { 1, 1, 0, 0, 0, 0 });
            array.Add(new List<int>() { 1, 1, 1, 1, 0, 0 });
            array.Add(new List<int>() { 1, 1, 1, 1, 1, 0 });
            MatrixProcessor mProc = new MatrixProcessor();
            mProc.BinaryMatrix = array;
            // act
            int n = mProc.LongestSequenceOfOne();
            // assert
            Assert.AreEqual(n, 5);
        }

        [TestMethod]
        public void LongestSequenceOfOne_IncreasingRows_4()
        {
            // arrange
            List<List<int>> array = new List<List<int>>();
            array.Add(new List<int>() { 1, 1, 1, 1 });
            array.Add(new List<int>() { 0, 1, 1, 1 });
            array.Add(new List<int>() { 0, 0, 1, 1 });
            array.Add(new List<int>() { 0, 0, 0, 1 });
            array.Add(new List<int>() { 0, 0, 0, 0 });
            MatrixProcessor mProc = new MatrixProcessor();
            mProc.BinaryMatrix = array;
            // act
            int n = mProc.LongestSequenceOfOne();
            // assert
            Assert.AreEqual(n, 4);
        }

        [TestMethod]
        public void LongestSequenceOfOne_SpeadTest_1000()
        {
            // arrange
            int MAX = 1000;
            List<List<int>> array = new List<List<int>>();
            for (int i = 0; i < MAX; i++)
            {
                List<int> line = new List<int>();
                for (int j = 0; j < MAX; j++)
                {
                    line.Add(1);
                }
                array.Add(line);
            }
            MatrixProcessor mProc = new MatrixProcessor();
            mProc.BinaryMatrix = array;
            // act
            int n = mProc.LongestSequenceOfOne();
            // assert
            Assert.AreEqual(n, MAX);
        }
    }
}
