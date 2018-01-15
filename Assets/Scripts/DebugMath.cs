using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMath : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        Math<double>.StartMathKernel();
        Debug.Log("2^4.5: " + Math<double>.Power(2, 4.5));
        Debug.Log("Ln(450): " + Math<double>.Ln(450));
        Debug.Log("Sin(2.094): " + Math<double>.Sin(2.094));
        Debug.Log("Arcsin(0.5): " + Math<double>.ArcSin(0.5));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
