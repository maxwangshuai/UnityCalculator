using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Math<N>{

	public static N Sign(N number)
    {
        return ((dynamic)number > 0) ? (dynamic)1 : (((dynamic)number < 0) ? (dynamic)(-1) : (dynamic)0);
    }

    public static N AbsoluteValue(N number)
    {
        return ((dynamic)number >= 0) ? number : ((dynamic)(-1) * number);
    }

}
