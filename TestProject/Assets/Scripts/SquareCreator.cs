using System;

public class SquareCreator
{
    public int height;
    public int width;

    public void Initialization(int[,] MatrixFromDocument)
    {
        height = MatrixFromDocument.GetLength(0);
        width = MatrixFromDocument.GetLength(1);
    }

    public string CreateSquare(int i0, int j0, int[,] MatrixFromDocument)
    {
        string colorOrder = "";
        for (int i = i0 - 1; i <= i0 + 1; ++i)
        {
            int a = i;
            if (i < 0)
            {
                i = height - 1;
            }
            
            if (i > height - 1)
            {
                i = 0;
            }

            for (int j = j0 - 1; j <= j0 + 1; ++j)
            {
                int b = j;
                if (j < 0)
                {
                    j = width - 1;
                }

                if (j > width - 1)
                {
                    j = 0;
                }
                
                colorOrder += Convert.ToChar(MatrixFromDocument[i, j]);
                
                j = b;
                
                if (j == j0 + 1)
                {
                    i = a;
                }
            }
        }
        return colorOrder;
    }
}
