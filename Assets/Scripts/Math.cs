using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Math<N>{

	public static N Sign(N number)
    {
        return (number > 0) ? 1 : ((number < 0) ? -1 : 0);
    }

    public static N AbsoluteValue(N number)
    {
        return (number >= 0) ? number : (-1 * number);
    }

}
