using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Math<N>{

    private static double[] sincosLookup;
    private static double[] lnLookup;
    private const int sincosIterations = 32;
    private const double sinK = 0.60725293510314;

    public static double e = 2.718281828459;
    public static double pi = 3.14159265359;

    public static void StartMathKernel()
    {
        CreateLnLookupTable();
        CreateSinCosLookupTable();
    }

    private static void CreateLnLookupTable()
    {
        lnLookup = new double[11];
        lnLookup[1] = 0;
        lnLookup[2] = 0.69314718056;
        lnLookup[3] = 1.09761228867;
        lnLookup[4] = 1.38629436112;
        lnLookup[5] = 1.60943791243;
        lnLookup[6] = 1.79175946923;
        lnLookup[7] = 1.94591014906;
        lnLookup[8] = 2.07944154168;
        lnLookup[9] = 2.19722457734;
        lnLookup[10] = 2.30258509299;
}

    private static void CreateSinCosLookupTable()
    {
        sincosLookup = new double[sincosIterations];
        sincosLookup[0] = 0.785398163397;
        sincosLookup[1] = 0.463647609001;
        sincosLookup[2] = 0.244978663127;
        sincosLookup[3] = 0.124354994547;
        sincosLookup[4] = 0.062418809996;
        sincosLookup[5] = 0.0312398334303;
        sincosLookup[6] = 0.0156237286205;
        sincosLookup[7] = 0.0078123410601;
        sincosLookup[8] = 0.00390623013197;
        sincosLookup[9] = 0.00195312251648;
        sincosLookup[10] = 0.000976562189559;
        sincosLookup[11] = 0.000488281211195;
        sincosLookup[12] = 0.000244140620149;
        sincosLookup[13] = 0.000122070311894;
        sincosLookup[14] = 0.0000610351561742;
        sincosLookup[15] = 0.0000305175781155;
        sincosLookup[16] = 0.0000152587890613;
        sincosLookup[17] = 0.0000076293945311;
        sincosLookup[18] = 0.00000381469726561;
        sincosLookup[19] = 0.00000190734863281;
        sincosLookup[20] = 0.00000095367431641;
        sincosLookup[21] = 0.0000004768371582;
        sincosLookup[22] = 0.0000002384185791;
        sincosLookup[23] = 0.00000011920928955;
        sincosLookup[24] = 0.000000059604644775;
        sincosLookup[25] = 0.000000029802322388;
        sincosLookup[26] = 0.000000014901161194;
        sincosLookup[27] = 0.0000000074505805969;
        sincosLookup[28] = 0.0000000037252902985;
        sincosLookup[29] = 0.0000000018626451492;
        sincosLookup[30] = 0.00000000093132257462;
        sincosLookup[31] = 0.00000000046566128731;
    }

    public static N Sign(N number)
    {
        return ((dynamic)number > 0) ? (dynamic)1 : (((dynamic)number < 0) ? (dynamic)(-1) : (dynamic)0);
    }

    public static N AbsoluteValue(N number)
    {
        return ((dynamic)number >= 0) ? number : ((dynamic)(-1) * number);
    }

    public static int Floor(N number)
    {
        return (int)(((dynamic)number * 10)-(((dynamic)number*10)%10)) / 10;
    }
    
    public static int Ceil(N number)
    {
        if ((dynamic)Floor(number) == number) return (int)(dynamic)number;
        return (dynamic)Floor(number) + 1;
    }

    public static int Round(N number)
    {
        int floor = Floor(number);
        int ceil = Ceil(number);
        if (AbsoluteValue((dynamic)number - floor) > AbsoluteValue((dynamic)number - ceil)) return floor;
        return ceil;
    }

    private static N BasicPower(N number, int power)
    {
        N output = (dynamic)1;
        for (int i = 0; i < power; i++)
        {
            output *= (dynamic)number;
        }
        return output;
    }

    public static N Power(N number, N power)
    {
        if((dynamic)power ==0)
        {
            return (dynamic)1;
        }
        else if((dynamic)power < 0)
        {
            return (dynamic)1 / Power(number, (dynamic)power * -1);
        }
        if ((dynamic)power == Floor(power))
        {
            return BasicPower(number, (int)(dynamic)power);
        }
        int round = Round(power);
        N output;
        if ((dynamic)power > 1)
        {
            N diff = (dynamic)power - round;
            output = (dynamic)BasicPower(number, round) * Power(number, diff);
        }
        else
        {
            N powerMult = (dynamic)BasicPower(number, round);
            N baseLog = Ln(number);
            output = powerMult;
            output += (dynamic)powerMult * baseLog * ((dynamic)power - round);
            output += (dynamic)powerMult * baseLog * baseLog * ((dynamic)power - round) * ((dynamic)power - round) / 2;
            output += (dynamic)powerMult * baseLog * baseLog * baseLog * ((dynamic)power - round) * ((dynamic)power - round) * ((dynamic)power - round) / 6;
            output += (dynamic)powerMult * baseLog * baseLog * baseLog * baseLog * ((dynamic)power - round) * ((dynamic)power - round) * ((dynamic)power - round) * ((dynamic)power - round) / 24;
        }
        return output;
    }

    public static N Sqrt(N number)
    {
        return Power(number, (dynamic)0.5);
    }

    public static N Log(N number, N baseIn)
    {
        return (dynamic)Ln(number) / Ln(baseIn);
    }

    public static N Ln(N number)
    {
        int flop = 1;
        N output = (dynamic)0;
        if ((dynamic)number == 1)
        {
            return (dynamic)0;
        }
        else if((dynamic)number < 1)
        {
            flop = -1;
            number = (dynamic)1 / number;
        }
        if ((dynamic)number >= 10)
        {
            int powerBase = 0;
            while (BasicPower((dynamic)10, powerBase + 1) < number)
            {
                powerBase++;
            }
            int power = (int)BasicPower((dynamic)10, powerBase);
            N mult = ((dynamic)number / power);
            output = (dynamic)((double)powerBase) * lnLookup[10] + Ln(mult);
        }
        else
        {
            int round = Round(number);
            output += (dynamic)lnLookup[round];
            output += ((dynamic)number - round) / round;
            output -= ((dynamic)number - round) * ((dynamic)number - round) / ((dynamic)2 * round * round);
            output += ((dynamic)number - round) * ((dynamic)number - round) * ((dynamic)number - round) / ((dynamic)3 * round * round * round);
            output -= ((dynamic)number - round) * ((dynamic)number - round) * ((dynamic)number - round) * ((dynamic)number - round) / ((dynamic)4 * round * round * round * round);
        }
        return (dynamic)output * flop;
    }

    private static N[] SineCosine(N theta)
    {
        if((dynamic)theta < 0 || (dynamic)theta > pi / 2)
        {
            throw new System.Exception("Required value 0 < x < Pi/2");
        }
        double x = sinK;
        double y = 0;
        double z = (dynamic)theta;
        double v = 1.0;
        double d = 0;
        double tx = 0;
        double ty = 0;
        double tz = 0;
        for(int i=0;i< sincosIterations; i++)
        {
            d = (z >= 0) ? +1 : -1;
            tx = x - d * y * v;
            ty = y + d * x * v;
            tz = z - d * sincosLookup[i];
            x = tx; y = ty; z = tz;
            v *= 0.5;
        }
        return new N[2]{ (dynamic)x, (dynamic)y };
    }

    public static N Sin(N theta)
    {
        return ((dynamic)((dynamic)theta % (2 * pi)) > pi) ? SineCosine((dynamic)theta % (pi / 2))[1] * -1 : SineCosine((dynamic)theta % (pi / 2))[1];
    }

    public static N Cos(N theta)
    {
        return Sin((dynamic)theta + (pi / 2));
    }

    public static N Csc(N theta)
    {
        return (dynamic)1 / Sin(theta);
    }

    public static N Sec(N theta)
    {
        return (dynamic)1 / Cos(theta);
    }

    public static N Tan(N theta)
    {
        return (dynamic)Sin(theta) / Cos(theta);
    }

    public static N Cot(N theta)
    {
        return (dynamic)Cos(theta) / Sin(theta);
    }

    public static N ArcSin(N number)
    {
        if((dynamic)number > 1|| (dynamic)number < -1)
        {
            throw new System.Exception("ArcSine cannot be outside of -1 to 1");
        }
        double flop = 1;
        double sinpos = 0.5;
        double sinchange = 0.5;
        double sinval = 0;
        if((dynamic)number == 0)
        {
            return (dynamic)0;
        }
        else if((dynamic)number < 0)
        {
            flop = -1;
            number = (dynamic)number * -1;
        }
        while (AbsoluteValue((dynamic)sinval - number) > 0.00000001)
        {
            if ((dynamic)sinval > number) sinpos -= sinchange;
            else sinpos += sinchange;
            sinval = Math<double>.Sin(sinpos * pi / 2);
            Debug.Log((sinpos * pi / 2) + ", " + sinval);
            sinchange /= 2;
        }
        return (dynamic)sinpos * flop * pi / 2;
    }

    public static N ArcCos(N number)
    {
        return (pi / 2) + ((dynamic)ArcSin(number) * -1);
    }

    public static N ArcCsc(N number)
    {
        if ((dynamic)number < 1 && (dynamic)number > -1)
        {
            throw new System.Exception("ArcSine has to be outside of -1 to 1");
        }
        double flop = 1;
        double cscpos = 0.5;
        double cscchange = 0.5;
        double cscval = 0;
        if ((dynamic)number == 0)
        {
            return (dynamic)0;
        }
        else if ((dynamic)number < 0)
        {
            flop = -1;
            number = (dynamic)number * -1;
        }
        while (AbsoluteValue((dynamic)cscval - number) > 0.00000001)
        {
            if ((dynamic)cscval > number) cscpos -= cscchange;
            else cscpos += cscchange;
            cscval = Math<double>.Csc(cscpos * pi / 2);
            Debug.Log((cscpos * pi / 2) + ", " + cscval);
            cscchange /= 2;
        }
        return (dynamic)cscpos * flop * pi / 2;
    }

    public static N ArcSec(N number)
    {
        return (pi / 2) + ((dynamic)ArcCsc(number) * -1);
    }
}
