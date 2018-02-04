public class Matrix<N>
{

    private N[,] values;
    public int Width;
    public int Height;

    public Matrix(int width, int height)
    {
        values = new N[width, height];
        Width = width;
        Height = height;
    }

    public static Matrix<N> operator +(Matrix<N> matrix1, Matrix<N> matrix2)
    {
        return Add(matrix1, matrix2);
    }

    private static Matrix<N> Add(Matrix<N> matrix1, Matrix<N> matrix2)
    {
        if (matrix1.Width != matrix2.Width || matrix1.Height != matrix2.Height)
        {
            throw new System.Exception("Matrices are not the same length");
        }
        Matrix<N> matrixOut = new Matrix<N>(matrix1.Width, matrix1.Height);
        for (int i = 0; i < matrix1.Width; i++)
        {
            for(int j = 0; j < matrix1.Height; j++)
            {
                matrixOut[i, j] = (dynamic)matrix1[i, j] + matrix2[i, j];
            }
        }
        return matrixOut;
    }

    public static Matrix<N> operator -(Matrix<N> matrix1, Matrix<N> matrix2)
    {
        return Subtract(matrix1, matrix2);
    }

    private static Matrix<N> Subtract(Matrix<N> matrix1, Matrix<N> matrix2)
    {
        if (matrix1.Width != matrix2.Width || matrix1.Height != matrix2.Height)
        {
            throw new System.Exception("Matrices are not the same length");
        }
        Matrix<N> matrixOut = new Matrix<N>(matrix1.Width, matrix1.Height);
        for (int i = 0; i < matrix1.Width; i++)
        {
            for (int j = 0; j < matrix1.Height; j++)
            {
                matrixOut[i, j] = (dynamic)matrix1[i, j] - matrix2[i, j];
            }
        }
        return matrixOut;
    }

    public static Matrix<N> operator *(N value, Matrix<N> vector)
    {
        return ScalarMultiply(value, vector);
    }

    public static Matrix<N> operator *(Matrix<N> vector, N value)
    {
        return ScalarMultiply(value, vector);
    }

    private static Matrix<N> ScalarMultiply(N value, Matrix<N> matrix)
    {
        Matrix<N> matrixOut = new Matrix<N>(matrix.Width, matrix.Height);
        for (int i = 0; i < matrix.Width; i++)
        {
            for (int j = 0; j < matrix.Height; j++)
            {
                matrixOut[i, j] = (dynamic)value * matrix[i, j];
            }
        }
        return matrixOut;
    }

    public static Matrix<N> operator *(Matrix<N> matrix1, Matrix<N> matrix2)
    {
        return Multiply(matrix1, matrix2);
    }

    private static Matrix<N> Multiply(Matrix<N> matrix1, Matrix<N> matrix2)
    {
        if (matrix1.Width != matrix2.Height)
        {
            throw new System.Exception("Matrix 1 width is not the same as matrix 2 height");
        }
        Matrix<N> matrixOut = new Matrix<N>(matrix2.Width, matrix1.Height);
        N sum = (dynamic)0;
        for(int i = 0; i < matrixOut.Width; i++)
        {
            for(int j = 0; j < matrixOut.Height; j++)
            {
                for(int i2 = 0; i2 < matrix1.Width; i2++)
                {
                    for (int j2 = 0; j2 < matrix2.Height; j2++)
                    {
                        sum += (dynamic)matrix1[i, i2] * matrix2[j2, j];
                    }
                }
                matrixOut[i, j] = sum;
                sum = (dynamic)0;
            }
        }
        return matrixOut;
    }

    public static Matrix<N> Transpose(Matrix<N> matrix)
    {
        Matrix<N> matrixOut = new Matrix<N>(matrix.Height, matrix.Width);
        for(int i = 0; i < matrix.Width; i++)
        {
            for(int j = 0; j < matrix.Height; j++)
            {
                matrixOut[i, j] = matrix[j, i];
            }
        }
        return matrixOut;
    }

    public static N Determinant(Matrix<N> matrix)
    {
        if(matrix.Width != matrix.Height)
        {
            throw new System.Exception("Determinant can only be taken of a square matrix");
        }
        if (matrix.Width == 1)
        {
            return matrix[0, 0];
        }
        N sum = (dynamic)0;
        for(int i = 0; i < matrix.Width; i++)
        {
            sum += (dynamic)matrix[i, 0] * Determinant(Minor(matrix, i, 0)) * (((i % 2) * 2) - 1);
        }
        return sum;
    }

    private static Matrix<N> Minor(Matrix<N> matrix, int x, int y)
    {
        Matrix<N> matrixOut = new Matrix<N>(matrix.Width - 1, matrix.Height - 1);
        for(int i = 0; i < matrixOut.Width; i++)
        {
            for (int j = 0; j < matrixOut.Height; j++)
            {
                if (i < x && j < y)
                {
                    matrixOut[i, j] = matrix[i, j];
                }
                else if(i < x && j + 1 >= y)
                {
                    matrixOut[i, j] = matrix[i, j + 1];
                }
                else if (i + 1 >= x && j < y)
                {
                    matrixOut[i, j] = matrix[i + 1, j];
                }
                else
                {
                    matrixOut[i, j] = matrix[i + 1, j + 1];
                }
            }
        }
        return matrixOut;
    }

    public N this[int i, int j]
    {
        get { return values[i, j]; }
        set { values[i, j] = value; }
    }

    public override string ToString()
    {
        string output = "[";
        for (int i = 0; i < Width - 1; i++)
        {
            output += "[";
            for(int j = 0; j < Height - 1; j++)
            {
                output += values[i, j] + ", ";
            }
            output += values[i, Height - 1] + "], ";
        }
        output += "[";
        for (int j = 0; j < Height - 1; j++)
        {
            output += values[Width - 1, j] + ", ";
        }
        output += values[Width - 1, Height - 1] + "]";
        return output;
    }
}
