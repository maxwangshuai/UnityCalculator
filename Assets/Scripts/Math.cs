using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Math<N>{

    public static double e = 2.718281828459;
    public static double pi = 3.14159265359;
    private static double ln10 = 2.30258509299;
    private static double ln2 = 0.69314718056;
    private static double ln3 = 1.09761228867;
    private static double ln4 = 1.38629436112;
    private static double ln5 = 1.60943791243;
    private static double ln6 = 1.79175946923;
    private static double ln7 = 1.94591014906;
    private static double ln8 = 2.07944154168;
    private static double ln9 = 2.19722457734;

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
        else if((dynamic)number <= 0)
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
            output = (dynamic)((double)powerBase) * ln10 + Ln(mult);
        }
        else
        {
            int round = Round(number);
            switch (round)
            {
                case 1:
                    break;
                case 2:
                    output += (dynamic)ln2;
                    break;
                case 3:
                    output += (dynamic)ln3;
                    break;
                case 4:
                    output += (dynamic)ln4;
                    break;
                case 5:
                    output += (dynamic)ln5;
                    break;
                case 6:
                    output += (dynamic)ln6;
                    break;
                case 7:
                    output += (dynamic)ln7;
                    break;
                case 8:
                    output += (dynamic)ln8;
                    break;
                case 9:
                    output += (dynamic)ln9;
                    break;
            }
            output += ((dynamic)number - round) / round;
            output -= ((dynamic)number - round) * ((dynamic)number - round) / ((dynamic)2 * round * round);
            output += ((dynamic)number - round) * ((dynamic)number - round) * ((dynamic)number - round) / ((dynamic)3 * round * round * round);
            output -= ((dynamic)number - round) * ((dynamic)number - round) * ((dynamic)number - round) * ((dynamic)number - round) / ((dynamic)4 * round * round * round * round);
        }
        return (dynamic)output * flop;
    }

    private static N SineApprox(N number)
    {
        return (number) - (((dynamic)number * number * number) / 6) + (((dynamic)number * number * number * number * number) / 120) - (((dynamic)number * number * number * number * number * number * number) / 5040);
    }

    private static N CosineApprox(N number)
    {
        return 1 - (((dynamic)number * number) / 2) + (((dynamic)number * number * number * number) / 24) - (((dynamic)number * number * number * number * number * number) / 620) + (((dynamic)number * number * number * number * number * number * number * number) / 40320);
    }

    public static N Sin(N number)
    {
        int segment = (int)((number-((dynamic)number%(pi/4)))/(pi/4))%8;
        number = (dynamic)number % (pi / 4);
        if (segment % 4 == 0 || segment % 4 == 3) //Uses SineApprox
        {
            switch (segment)
            {
                case 0:
                    return SineApprox(number);
                case 3:
                    return SineApprox((dynamic)(pi/4) - number);
                case 4:
                    return (dynamic)SineApprox(number) * -1;
                case 7:
                    return (dynamic)SineApprox((dynamic)(pi / 4) - number) * -1;
            }
        }
        else //Uses CosineApprox
        {
            switch (segment)
            {
                case 1:
                    return CosineApprox((dynamic)(pi / 4) - number);
                case 2:
                    return CosineApprox(number);
                case 5:
                    return (dynamic)CosineApprox((dynamic)(pi / 4) - number) * -1;
                case 6:
                    return (dynamic)CosineApprox(number) * -1;
            }
        }
        return (dynamic)0;
    }

    public static N Csc(N number)
    {
        return (dynamic)1 / Sin(number);
    }

    public static N Cos(N number)
    {
        return Sin((dynamic)number + pi / 2);
    }

    public static N Sec(N number)
    {
        return (dynamic)1 / Cos(number);
    }

    public static N Tan(N number)
    {
        return (dynamic)Sin(number) / Cos(number);
    }

    public static N Cot(N number)
    {
        return (dynamic)Cos(number) / Sin(number);
    }


}
