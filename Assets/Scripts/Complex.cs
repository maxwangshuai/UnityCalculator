using System.Collections;
using System.Collections.Generic;

public class Complex<N>
{

    public N real;
    public N imaginary;

    public Complex()
    {
        real = (dynamic)0;
        imaginary = (dynamic)0;
    }

    public Complex(N real, N imaginary)
    {
        this.real = real;
        this.imaginary = imaginary;
    }

    public static Complex<N> operator +(Complex<N> complex1, Complex<N> complex2)
    {
        return Add(complex1, complex2);
    }

    private static Complex<N> Add(Complex<N> complex1, Complex<N> complex2)
    {
        Complex<N> output = new Complex<N>();
        output.real = (dynamic)complex1.real + complex2.real;
        output.imaginary = (dynamic)complex1.imaginary + complex2.imaginary;
        return output;
    }

    public static Complex<N> operator -(Complex<N> complex1, Complex<N> complex2)
    {
        return Subract(complex1, complex2);
    }

    private static Complex<N> Subract(Complex<N> complex1, Complex<N> complex2)
    {
        Complex<N> output = new Complex<N>();
        output.real = (dynamic)complex1.real - complex2.real;
        output.imaginary = (dynamic)complex1.imaginary - complex2.imaginary;
        return output;
    }

    public static Complex<N> operator *(Complex<N> complex1, Complex<N> complex2)
    {
        return Multiply(complex1, complex2);
    }

    private static Complex<N> Multiply(Complex<N> complex1, Complex<N> complex2)
    {
        Complex<N> output = new Complex<N>();
        output.real = ((dynamic)complex1.real * complex2.real) - ((dynamic)complex1.imaginary * complex2.imaginary);
        output.imaginary = ((dynamic)complex1.real * complex2.imaginary) + ((dynamic)complex1.imaginary * complex2.real);
        return output;
    }

    public static Complex<N> operator /(Complex<N> complex1, Complex<N> complex2)
    {
        return Divide(complex1, complex2);
    }

    private static Complex<N> Divide(Complex<N> complex1, Complex<N> complex2)
    {
        Complex<N> output = new Complex<N>();
        output.real = ((dynamic)complex1.real * complex2.real) + ((dynamic)complex1.imaginary * complex2.imaginary)/(((dynamic)complex2.real * complex2.real) + ((dynamic)complex2.imaginary * complex2.imaginary));
        output.imaginary = ((dynamic)complex1.imaginary * complex2.real) - ((dynamic)complex1.real * complex2.imaginary) / (((dynamic)complex2.real * complex2.real) + ((dynamic)complex2.imaginary * complex2.imaginary));
        return output;
    }

}
