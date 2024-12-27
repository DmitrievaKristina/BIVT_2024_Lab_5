using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
public class Program
{
    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;
        
        // code here
        answer = Combinations(n, k);
        // create and use Combinations(n, k);        
        // create and use Factorial(n);
        // end
        
        return answer;
    }
    public long Combinations(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }
    public long Factorial(int n)
        {
            long fact = 1;
            for (int i = 2; i <= n; i++)
                fact *= i;
            return fact;
        }
    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;
        // code here
        if (first == null || second == null || first.Length != 3 || second.Length != 3) return -1;
        double a1 = first[0], b1 = first[1], c1 = first[2];
        double a2 = second[0], b2 = second[1], c2 = second[2];
        if (a1 + b1 <= c1 || a1 + c1 <= b1 || b1 + c1 <= a1) return -1;
        if (a2 + b2 <= c2 || a2 + c2 <= b2 || b2 + c2 <= a2) return -1;
        
        //if (first) return -1;
        if (GeronArea(a1, b1, c1) > GeronArea(a2, b2, c2)) answer = 1;
        else if (GeronArea(a1, b1, c1) < GeronArea(a2, b2, c2)) answer = 2;
        else if (GeronArea(a1, b1, c1) == GeronArea(a2, b2, c2)) answer = 0;
        
        // create and use GeronArea(a, b, c);
        // end
        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }
    public double GeronArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a)*(p - b)*(p - c));
        }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;
        // code here
        if (GetDistance(v1, a1, time) > GetDistance(v2, a2, time)) answer = 1;
        else if (GetDistance(v1, a1, time) < GetDistance(v2, a2, time)) answer = 2;
        else answer = 0;
        
        // create and use GetDistance(v, a, t); t - hours
        // end
        // first = 1, second = 2, equal = 0
        
        return answer;
    }
    public double GetDistance(double v, double a, int t)
        {
            return v*t + a*t*t/2;
        }
    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        // int answer = 0;
        // code here
        for (int time = 1; ; time++)
            if (GetDistance(v1, a1, time) <= GetDistance(v2, a2, time)) return time;
        
        // use GetDistance(v, a, t); t - hours
        // end
        // return answer;
    }
    #endregion
    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here
        if (A == null || B == null || A.GetLength(0) != 5 || A.GetLength(1) != 6 || B.GetLength(0) != 3 || B.GetLength(1) != 5) return;
        FindMaxIndex(A, out int row1, out int column1); FindMaxIndex(B, out int row2, out int column2);
        int temp = A[row1, column1];
        A[row1, column1] = B[row2, column2];
        B[row2, column2] = temp;
        // create and use FindMaxIndex(matrix, out row, out column);
        // end
    }
    public void FindMaxIndex(int[,] matrix, out int row, out int column)
        {
            row = 0; 
            column = 0;
            int max = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        row = i;
                        column = j;
                    }
        }
    public void Task_2_2(double[] A, double[] B)
    {
        // code here
        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!
        // end
    }
    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here
        if (C == null || B == null || C.GetLength(0) != 6 || C.GetLength(1) != 6 || B.GetLength(0) != 5 || B.GetLength(1) != 5) return;
        B = FindDiagonalMaxIndex(B); C = FindDiagonalMaxIndex(C);
        
        // create and use method FindDiagonalMaxIndex(matrix);
        // end
    }
    public int[,] FindDiagonalMaxIndex(int[,] matrix)
        {
            int max = int.MinValue, index = 0, n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int i = 0; i < matrix.GetLength(0); i++)
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    index = i;
                }
            int[,] matrix_new = new int[n-1, m];
            for (int i = 0; i < n-1; i++)
                for (int j = 0; j < m; j++)
                {
                    if (i < index) matrix_new[i, j] = matrix[i, j];
                    else matrix_new[i, j] = matrix[i+1, j];
                }
            return matrix_new;
        }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here
        // create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3
        // end
    }
    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here
        if (A == null || B == null || A.GetLength(0) != 4 || A.GetLength(1) != 6 || B.GetLength(0) != 6 || B.GetLength(1) != 6) return;
        FindMaxInColumn(A, 0, out int index1); FindMaxInColumn(B, 0, out int index2);
        for (int j = 0; j < A.GetLength(1); j++)
        {
            int temp = A[index1, j];
            A[index1, j] = B[index2, j];
            B[index2, j] = temp;
        }

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);
        // end
    }
    public void FindMaxInColumn(int[,] matrix, int columnIndex, out int rowIndex)
        {
            int max = int.MinValue, n = matrix.GetLength(0); 
            rowIndex = 0;
            for (int i = 0; i < n; i++)
                if (matrix[i, columnIndex] > max)
                {
                    rowIndex = i;
                    max = matrix[i, columnIndex];
                }
        }
    public void Task_2_6(ref int[] A, int[] B)
    {
        
        // code here
        
        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);
        // end
    }
    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here
        if (C == null || B == null || C.GetLength(0) != 5 || C.GetLength(1) != 6 || B.GetLength(0) != 4 || B.GetLength(1) != 5) return;
        int index_rowB = CountRowPositive(B), index_colC = CountColumnPositive(C), n = B.GetLength(0), m = B.GetLength(1);
        if (index_rowB == 0 || index_colC == -1) return;
        int[,] B_new = new int[n + 1, m];
        for(int i = 0; i < n + 1; i++)
            for (int j = 0; j < m; j++)
            {
                if (i < index_rowB)
                    B_new[i, j] = B[i, j];
                else if (i > index_rowB) 
                    B_new[i, j] = B[i-1, j];
                else
                    B_new[index_rowB, j] = C[j, index_colC];
            }
        B = B_new;
        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);
        // end
    }
    public int CountRowPositive(int[,] matrix)
        {
            int rowIndex = -1, max_count = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for(int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > 0) count++;
                if (count > max_count)
                {
                    max_count = count;
                    rowIndex = i;
                }
            }
            return rowIndex + 1;   
        }
    public int CountColumnPositive(int[,] matrix)
        {
            int colIndex = -1, max_count = 0;
            for(int j = 0; j < matrix.GetLength(1); j++) 
            {
                int count = 0;
                for(int i = 0; i < matrix.GetLength(0); i++)
                    if (matrix[i, j] > 0) count++;
                if (count > max_count)
                {
                    max_count = count;
                    colIndex = j;
                }
            }
            return colIndex;   
        }
    public void Task_2_8(int[] A, int[] B)
    {
        // code here
        // create and use SortArrayPart(array, startIndex);
        // end
    }
    public int[] Task_2_9(int[,] A, int[,] C)
    {
        // code here
        if (A == null || C == null || (A.GetLength(0) != 7 && A.GetLength(1) != 4) || (C.GetLength(0) != 6 && C.GetLength(1) != 5)) return null;
        // Массивы местами перепутаны, по условию у них наоборот размеры
        
        int[] Sum_A = SumPositiveElementsInColumns(A), Sum_C = SumPositiveElementsInColumns(C);
        int[] answer = new int[Sum_A.Length + Sum_C.Length];
        for (int i = 0; i < Sum_A.Length; i++)
            answer[i] = Sum_A[i];
        
        for (int i = 0; i < Sum_A.Length+1; i++)
            answer[i+Sum_A.Length] = Sum_C[i];

        // create and use SumPositiveElementsInColumns(matrix);
        // end
        return answer;
    }
    public int[] SumPositiveElementsInColumns(int [,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] sum_col = new int[m];
            for (int j = 0 ; j < m; j++)
            {
                int sum_pos = 0;
                for (int i = 0 ; i < n; i ++)
                    if (matrix[i, j] > 0) sum_pos += matrix[i, j];
                sum_col[j] = sum_pos;
            }
            return sum_col;
        }
    public void Task_2_10(ref int[,] matrix)
    {
        // code here
        // create and use RemoveColumn(matrix, columnIndex);
        // end
    }
    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here
        if (A == null || B == null || A.GetLength(0) == 0 || A.GetLength(1) == 0 || B.GetLength(0) == 0 || B.GetLength(1) == 0) return;
        FindMaxIndex(A, out int row1, out int column1); FindMaxIndex(B, out int row2, out int column2);
        int temp = A[row1, column1];
        A[row1, column1] = B[row2, column2];
        B[row2, column2] = temp;

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here
        // create and use FindMaxColumnIndex(matrix);
        // end
    }
    public void Task_2_13(ref int[,] matrix)
    {
        // code here
        //if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) return;
        FindIndexMinandMax(matrix, out int index_min, out int index_max);
        if (index_max == index_min) 
            matrix = RemoveRow(matrix, index_max);
        else
        {
            matrix = RemoveRow(matrix, index_min);
            matrix = RemoveRow(matrix, index_max);
        }
        // create and use RemoveRow(matrix, rowIndex);
        // end
    }
    public int[,] RemoveRow(int[,] matrix, int rowIndex)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[,] matrix_new = new int[n - 1, m];
            for(int i = 0; i < n - 1; i++)
                for(int j = 0; j < m; j++)
                {
                    if (i < rowIndex) matrix_new[i, j] = matrix[i, j];
                    else matrix_new[i, j] = matrix[i + 1, j];
                }
            return matrix_new;
        }
    public void FindIndexMinandMax(int[,] matrix, out int index_min, out int index_max)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1), min = int.MaxValue, max = int.MinValue;
            index_min = 0; index_max = 0;
            for(int i = 0; i < n; i++)
                for(int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        index_min = i;
                    }
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        index_max = i;
                    }
                }
        }
    public void Task_2_14(int[,] matrix)
    {
        // code here
        // create and use SortRow(matrix, rowIndex);
        // end
    }
    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        //int answer = 0;
        // code here
        if (A == null || B == null || C == null || A.GetLength(0) == 0 || A.GetLength(1) == 0 || B.GetLength(0) == 0 || B.GetLength(1) == 0 || C.GetLength(0) == 0 || C.GetLength(1) == 0) return 0;
        double ave_A = GetAverageWithoutMinMax(A), ave_B = GetAverageWithoutMinMax(B), ave_C = GetAverageWithoutMinMax(C);
        if (ave_A < ave_B && ave_B < ave_C) return 1;
        if (ave_A > ave_B && ave_B > ave_C) return -1;
        else return 0;
        // create and use GetAverageWithoutMinMax(matrix);
        // end
        // 1 - increasing 0 - no sequence -1 - decreasing
        // return answer;
    }
    public double GetAverageWithoutMinMax(int[,] matrix)
        {
            double average = 0;
            int n = matrix.GetLength(0), m = matrix.GetLength(1), max = int.MinValue, min = int.MaxValue;
            for(int i = 0; i < n; i++)
                for(int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max) max = matrix[i, j];
                    if (matrix[i, j] < min) min = matrix[i, j];
                }
            int count = 0;
            for(int i = 0; i < n; i++)
                for(int j = 0; j < m; j++)
                    if (matrix[i, j] != max && matrix[i, j] != min)
                    {
                        average += matrix[i, j];
                        count++;
                    }
            
            return average/count;
        }
    public void Task_2_16(int[] A, int[] B)
    {
        // code here
        // create and use SortNegative(array);
        // end
    }
    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here
        //if (A == null || B == null || A.GetLength(0) == 0 || A.GetLength(1) == 0 || B.GetLength(0) == 0 || B.GetLength(1) == 0) return;
        A = SortRowsByMaxElement(A); B = SortRowsByMaxElement(B);
        // Print_matrix(A, 2.17); Print_matrix(B, 2.17);
        // create and use SortRowsByMaxElement(matrix);
        // end
    }
    public int[,] SortRowsByMaxElement(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[,] maxs = new int[n, 2], matrix_new = new int[n, m];
            for(int i = 0; i < n; i++)
            {
                int max = int.MinValue;
                for(int j = 0; j < m; j++)
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                maxs[i, 0] = max;
                maxs[i, 1] = i;
            }
            for(int i = 1, j = 2; i < n; )
            {
                if (i == 0 || maxs[i, 0] <= maxs[i-1, 0])
                {
                    i = j;
                    j++;
                }
                else
                {
                    int temp = maxs[i, 0];
                    maxs[i, 0] = maxs[i-1, 0];
                    maxs[i-1, 0] = temp;
                    int temp_ind = maxs[i, 1];
                    maxs[i, 1] = maxs[i-1, 1];
                    maxs[i-1, 1] = temp_ind;
                    
                    i--;
                }
            }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix_new[i, j] = matrix[maxs[i, 1], j];
            return matrix_new;
        }
    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here
        // create and use SortDiagonal(matrix);
        // end
    }
    public void Task_2_19(ref int[,] matrix)
    {
        // code here
        for (int i = 0; i < matrix.GetLength(0); i ++)
            for (int j = 0; j < matrix.GetLength(1); j ++)
            {
                if (matrix[i, j] == 0)
                    matrix = RemoveRow(matrix, i);
            } 
        // use RemoveRow(matrix, rowIndex); from 2_13
        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here
        // use RemoveColumn(matrix, columnIndex); from 2_10
        // end
    }
    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        // code here
        answerA = CreateArrayFromMins(A); answerB = CreateArrayFromMins(B);
        // create and use CreateArrayFromMins(matrix);
        // end
    }
    public int[] CreateArrayFromMins(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int[] answer = new int[n];
            for (int i = 0; i < n; i++)
            {
                int min = int.MaxValue;
                for (int j = i; j < n; j++)
                    if (matrix[i, j] < min) min = matrix[i, j];
                answer[i] = min;
            }
            return answer;
        }
    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;
        // code here
        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);
        // end
    }
    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here
        MatrixValuesChange(ref A); MatrixValuesChange(ref B);
        // create and use MatrixValuesChange(matrix);
        // end
    }
    public void MatrixValuesChange(ref double[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1), index = 0;
            double[] array = new double[n*m];
            for(int i = 0; i < n; i++) 
                for(int j = 0; j < m; j++)
                    array[index++] = matrix[i, j];

            for(int i = 1, j = 2; i < array.Length; )
            {
                if (i == 0 || array[i] < array[i-1])
                {
                    i = j;
                    j++;
                }
                else
                {
                    double temp = array[i];
                    array[i] = array[i-1];
                    array[i-1] = temp;
                    i--;
                }
            }
            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    bool max = false;
                    for (int ind = 0; ind < 5; ind++)
                    {
                        if (matrix[i, j] == array[ind]) 
                        {
                            max = true;
                            break;
                        }
                    }
                    if (max)
                    {
                        switch (matrix[i, j])
                        {
                            case > 0:
                                matrix[i, j] *= 2;
                                break;
                            case < 0:
                                matrix[i, j] /= 2;
                                break;
                        }
                    }
                    else
                    {
                        switch (matrix[i, j])
                        {
                            case > 0:
                                matrix[i, j] /= 2;
                                break;
                            case < 0:
                                matrix[i, j] *= 2;
                                break;
                        }
                    }
                }
            }
        }
    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here
        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);
        // end
    }
    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        // code here
        maxA = FindRowWithMaxNegativeCount(A); 
        maxB = FindRowWithMaxNegativeCount(B);
        // create and use FindRowWithMaxNegativeCount(matrix);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22
        // end
    }
    public int FindRowWithMaxNegativeCount(int[,] matrix)
        {
            int row_max = 0, max_count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                if (CountNegativeInRow(matrix, i) > max_count) 
                {
                    max_count = CountNegativeInRow(matrix, i);
                    row_max = i;
                }
            return row_max;
        }
        public int CountNegativeInRow(int[,] matrix, int rowIndex)
        {
            int count = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (matrix[rowIndex, j] < 0)
                    count++;
            return count;
        }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here
        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22
        // end
    }
    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here
        A = ReplaceMaxElementEven(A); A = ReplaceMaxElementOdd(A);
        B = ReplaceMaxElementEven(B); B = ReplaceMaxElementOdd(B);
        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);
        // end
    }
    public int FindRowMaxIndex(int[,] matrix, int rowIndex)
    {
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        int max = int.MinValue, columnIndex = 0;
        for (int j = 0; j < m; j++)
            if (matrix[rowIndex, j] > max) 
            {
                max = matrix[rowIndex, j];
                columnIndex = j;
            }
        return columnIndex;
    }
    public int[,] ReplaceMaxElementOdd(int[,] matrix)
    {
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        for (int i = 0; i < n; i += 2)
            matrix[i, FindRowMaxIndex(matrix, i)] *= FindRowMaxIndex(matrix, i) + 1;
        return matrix;
    }
    public int[,] ReplaceMaxElementEven(int[,] matrix)
    {
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        for (int i = 1; i < n; i += 2)
            matrix[i, FindRowMaxIndex(matrix, i)] = 0;
        return matrix;
    }
    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here
        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence, -1 - decreasing
        // A and B - start and end indexes of elements from array for search
        // end
    }
    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here
        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search
        // end
    }
    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here
        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search
        // end
    }
    #endregion
    #region Level 3
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here
        firstSumAndY = GetSumAndY(FirstSum, FirstY, 0.1, 1, 0.1, 0);
        secondSumAndY = GetSumAndY(SecondSum, SecondY, Math.PI/5, Math.PI, Math.PI/25, 1);
        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x
        // end
    }
    public delegate double SumFunction(double x, int i, ref int acts);
    public delegate double YFunction(double x);
    public double[,] GetSumAndY(SumFunction sFunction, YFunction yFunction, double a, double b, double h, int acts)
    {
        double[,] answer = new double[(int)((b - a)/h) + 1, 2];
        for(int i = 0; i < ((b - a)/h + 1); i++)
        {
            answer[i, 0] = Sum(sFunction, a + i*h, acts);
            answer[i, 1] = yFunction(a + i*h);
        }
        return answer;
    }
    public double FirstSum(double x, int i, ref int fact)
    {
        if(i > 0) fact *= i;
        return Math.Cos(i*x)/fact;
    }
    public double FirstY(double x)
    {        
        return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
    }
    public double SecondSum(double x, int i, ref int sign)
    {
        sign *= -1;
        return sign*Math.Cos(i*x)/(i*i);
    }
    public double Sum(SumFunction sumFunction, double x, int i)
    {
        int sign = 1; double memb = sumFunction(x, i, ref sign), sum = 0;
            while(Math.Abs(memb) > 0.0001)
            {
                i++;
                sum += memb;
                memb = sumFunction(x, i, ref sign);
            }
        return sum;
    }
    public double SecondY(double x)
    {
        return (x*x - Math.PI*Math.PI/3)/4;
    }
    public void Task_3_2(int[,] matrix)
    {
        // SortRowStyle sortStyle = default(SortRowStyle); - uncomment me
        // code here
        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting
        // end
    }
    public double Task_3_3(double[] array)
    {
        double answer = 0;
        SwapDirection swapper = default(SwapDirection);
        
        // code here
        double average = 0;
        for (int i = 0; i < array.Length; i++)
            average += array[i];
        average /= array.Length + 1;
        if (array[0] > average) 
            swapper = SwapRight;
        else 
            swapper = SwapLeft;
        answer = GetSum(swapper(array), 1, 2);
        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array)
        // create and use method GetSum(array, start, h) that sum elements with a negative indexes
        // change method in variable swapper in the if/else and than use swapper(matrix)
        // end
        return answer;
    }
    public delegate double[] SwapDirection(double[] array);
    public double[] SwapRight(double[] array)
    {
        for (int i = 0; i < array.Length - 1; i += 2)
        {
            double temp = array[i];
            array[i] = array[i+1];
            array[i+1] = temp;
        }
        return array;
    }
    public double[] SwapLeft(double[] array)
    {
        for (int i = array.Length - 2; i >= 0; i -= 2)
        {
            double temp = array[i];
            array[i] = array[i+1];
            array[i+1] = temp;
        }
        return array;
    }
    public double GetSum(double[] array, int start, int h)
    {
        double sum = 0;
        for (int i = start; i < array.Length; i += h) sum += array[i];
        return sum;
    }
    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;
        // code here
        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)
        // end
        return answer;
    }
    public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;
        // code here
        func1 = CountSignFlips(GetFunction1(), 0, 2, 0.1);
        func2 = CountSignFlips(GetFunction2(), -1, 1, 0.2);

        // use public delegate YFunction(x, a, b, h) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        // create and use 2 methods for both functions
        // end
    }
    public int CountSignFlips(YFunction yFunction, double a, double b, double h)
    {
        int count = 0; double prev_y = yFunction(a);
        for(double x = a + h; x <= b; x += h)
        {
            double y = yFunction(x);
            if (prev_y != 0 && !Sign(y, prev_y)) count++;
            prev_y = y;
        }
        return count;
    }
    public YFunction GetFunction1()
    {
        double F1(double x)
        {
            return x*x - Math.Sin(x);
        }
        return F1;
    }
    public YFunction GetFunction2()
    {
        double F2(double x)
        {
            return Math.Exp(x) - 1;
        }
        return F2;
    }
    public bool Sign(double input1, double input2)
    {
        if ((input1 > 0 && input2 > 0) || (input1 < 0 && input2 < 0) || (input1 == 0 && input2 == 0)) return true;
        else return false;
    }
    public void Task_3_6(int[,] matrix)
    {
        // code here
        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
        // end
    }
    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here
        B = InsertColumn(B, CountRowPositive(), C, CountColumnPositive);
        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);
        // end
    }
    public delegate int CountPositive(int [,] matrix, int index);
    public int[,] InsertColumn(int[,] matrixB, CountPositive CountRow, int[,] matrixC, CountPositive CountColumn)
    {
        int n = matrixB.GetLength(0), m = matrixB.GetLength(1), i_max_B = 0, j_max_C = 0;
        int max_B = -1, max_C = -1;
        for (int i = 0; i < n; i++)
        {
            if (CountRow(matrixB, i) > max_B)
            {
                max_B = CountRow(matrixB, i);
                i_max_B = i;
            }
            if (CountColumn(matrixC, i) > max_C)
            {
                max_C = CountColumn(matrixC, i);
                j_max_C = i;
            }
        }
        int[,] matrix_new = new int[n + 1, m];
        for (int i = 0; i < m; ++i)
            matrix_new[i_max_B + 1, i] = matrixC[i, j_max_C];
        
        for (int i = 0; i <= i_max_B; ++i)
            for (int j = 0; j < m; ++j)
                matrix_new[i, j] = matrixB[i, j];
        
        for (int i = i_max_B + 2; i < n + 1; ++i)
            for (int j = 0; j < m; ++j)
                matrix_new[i, j] = matrixB[i - 1, j];
        
        return matrix_new;
    }
    public void Task_3_10(ref int[,] matrix)
    {
        // FindIndex searchArea = default(FindIndex); - uncomment me
        // code here
        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        // create and use method FindMinAboveDiagonalIndex(matrix);
        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)
        // end
    }
    public void Task_3_13(ref int[,] matrix)
    {
        // code here
        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)
        // end
    }
    public delegate void FindElementDelegate(int[,] matrix, out int index_i, out int index_j);
    public void FindMinIndex(int[,] matrix, out int index_i, out int index_j)
    {
        index_i = 0; index_j = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (matrix[i, j] < matrix[index_i, index_j])
                {
                    index_i = i;
                    index_j = j;
                }
    }
    public void RemoveRows(ref int[,] matrix, FindElementDelegate findMax, FindElementDelegate findMin)
    {
        int maxI, maxJ, minI, minJ;
        findMax(matrix, out maxI, out maxJ);
        findMin(matrix, out minI, out minJ);

        if (minI < maxI)
        {
            RemoveRow(matrix, maxI);
            RemoveRow(matrix, minI);
        }
        else if (minI > maxI)
        {
            RemoveRow(matrix, minI);
            RemoveRow(matrix, maxI);
        }
        else
        {
            RemoveRow(matrix, minI);
        }
    }
    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;
        // code here
        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);
        // end
    }
    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here
        // create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
        // use ReplaceMaxElementOdd(matrix) from Task_2_27
        // use ReplaceMaxElementEven(matrix) from Task_2_27
        // create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);
        // end
    }
    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here
        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);
        // end
    }
    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here
        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);
        // end
    }
    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)
    {
        // MatrixConverter[] mc = new MatrixConverter[4]; - uncomment me
        // code here
        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle
        // end
        return matrix;
    }
    #endregion
    //public delegate void Print(, double Task_Num);
    public void Print_matrix(int[,] matrix, double Task_Num)
    {
        Console.WriteLine("Task_" + Task_Num);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.WriteLine();
            for (int j = 0; j < matrix.GetLength(1); j++) Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
    public void Print_arr(int[] array, double Task_Num)
    {
        Console.WriteLine("Task_" + Task_Num);
        for (int i = 0; i < array.Length; i++)
            Console.Write(array[i] + " ");
    }

    public void Print(double a)
    {
        Console.WriteLine(a);
    }
}
