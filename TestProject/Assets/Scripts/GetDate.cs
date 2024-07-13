using System;
using System.IO;
using System.Linq;
using UnityEngine;

public class GetDate
{
    private int[,] MatrixFromDocument;
    
    // {
    //     {1, 2, 3, 4, 3, 2, 1, 2, 3, 1}, 
    //     {2, 3, 4, 1, 2, 3, 4, 1, 2, 3}, 
    //     {4, 4, 3, 2, 1, 2, 3, 4, 3, 2}, 
    //     {4, 3, 3, 2, 2, 1, 4, 4, 1, 4}, 
    //     {2, 3, 3, 2, 2, 2, 4, 4, 1, 4}, 
    //     {4, 3, 3, 3, 2, 1, 1, 2, 3, 4}, 
    //     {4, 3, 2, 1, 1, 2, 3, 4, 3, 2}, 
    //     {4, 3, 3, 2, 1, 2, 3, 4, 3, 1}, 
    //     {4, 4, 3, 2, 1, 1, 2, 3, 4, 1}
    // };
    
    public int[,] ReturnArray()
    {
        string[] lines = File
            .ReadAllLines(Application.streamingAssetsPath + "/Numbers.txt");
        
        int[][] MatrixFromDocumentString = new int[lines.Length][];
        
        for (int i = 0; i < lines.Length; i++)
        {
            MatrixFromDocumentString[i] = new int[lines[i].Length];
            for (int j = 0; j < lines[i].Length; j++)
            {
                MatrixFromDocumentString[i][j] = lines[i][j] - '0';
            }
        }
        MatrixFromDocument = JaggedToMultidimensional(MatrixFromDocumentString);
        return MatrixFromDocument;
    }
    
    public T[,] JaggedToMultidimensional<T>(T[][] jaggedArray)
    {
        int rows = jaggedArray.Length;
        int cols = jaggedArray.Max(subArray => subArray.Length);
        T[,] array = new T[rows, cols];
        for(int i = 0; i < rows; i++)
        {
            cols = jaggedArray[i].Length;
            for(int j = 0; j < cols; j++)
            {
                array[i, j] = jaggedArray[i][j];
            }
        }
        return array;
    }
    
}
