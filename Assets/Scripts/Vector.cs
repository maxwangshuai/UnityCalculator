public class Vector<N>{

    private N[] values;
    public int Length;

    public Vector(int length)
    {
        values = new N[length];
        Length = length;
    }

    public Vector(params N[] args)
    {
        values = args;
        Length = args.Length;
    }

    public static Vector<N> operator +(Vector<N> vector1, Vector<N> vector2)
    {
        return Add(vector1, vector2);
    }

    private static Vector<N> Add(Vector<N> vector1, Vector<N> vector2)
    {
        if (vector1.Length != vector2.Length)
        {
            throw new System.Exception("Vectors are not the same length");
        }
        Vector<N> vectorOut = new Vector<N>(vector1.Length);
        for(int i = 0; i < vector1.Length; i++)
        {
            vectorOut[i] = (dynamic)vector1[i] + vector2[i];
        }
        return vectorOut;
    }

    public static Vector<N> operator -(Vector<N> vector1, Vector<N> vector2)
    {
        return Subtract(vector1, vector2);
    }

    private static Vector<N> Subtract(Vector<N> vector1, Vector<N> vector2)
    {
        if (vector1.Length != vector2.Length)
        {
            throw new System.Exception("Vectors are not the same length");
        }
        Vector<N> vectorOut = new Vector<N>(vector1.Length);
        for (int i = 0; i < vector1.Length; i++)
        {
            vectorOut[i] = (dynamic)vector1[i] - vector2[i];
        }
        return vectorOut;
    }

    public static Vector<N> operator *(N value, Vector<N> vector)
    {
        return ScalarMultiply(value, vector);
    }

    public static Vector<N> operator *(Vector<N> vector, N value)
    {
        return ScalarMultiply(value, vector);
    }

    private static Vector<N> ScalarMultiply(N value, Vector<N> vector)
    {
        Vector<N> vectorOut = new Vector<N>(vector.Length);
        for (int i = 0; i < vector.Length; i++)
        {
            vectorOut[i] = (dynamic)value * vector[i];
        }
        return vectorOut;
    }

    public static N operator *(Vector<N> vector1, Vector<N> vector2)
    {
        return DotProduct(vector1, vector2);
    }

    private static N DotProduct(Vector<N> vector1, Vector<N> vector2)
    {
        if (vector1.Length != vector2.Length)
        {
            throw new System.Exception("Vectors are not the same length");
        }
        N output = (dynamic)0;
        for(int i = 0; i < vector1.Length; i++)
        {
            output += (dynamic)vector1[i] * vector2[i];
        }
        return output;
    }

    public static Vector<N> operator %(Vector<N> vector1, Vector<N> vector2)
    {
        return CrossProduct(vector1, vector2);
    }

    private static Vector<N> CrossProduct(Vector<N> vector1, Vector<N> vector2)
    {
        Vector<N> vectorOut = new Vector<N>(1);

        return vectorOut;
    }

    public N this[int i]
    {
        get { return values[i]; }
        set { values[i] = value; }
    }

    public override string ToString()
    {
        string output = "<";
        for (int i = 0; i < Length - 1; i++)
        {
            output += values[i] + ", ";
        }
        output += values[Length - 1] + ">";
        return output;
    }
}
