using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMath : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        Math<double>.StartMathKernel();
        Debug.Log("Average: " + Math<double>.Mean(4, 6, 2, 0));
        Debug.Log("Median: " + Math<double>.Median(4, 6, 2, 0));
        Debug.Log("Min: " + Math<double>.Min(4, 6, 2, 0));
        Debug.Log("Max: " + Math<double>.Max(4, 6, 2, 0));
        Debug.Log("Range: " + Math<double>.Range(4, 6, 2, 0));
        Debug.Log("Var: " + Math<double>.Var(4, 6, 2, 0));
        Debug.Log("StDev: " + Math<double>.StDev(4, 6, 2, 0));
        Debug.Log("Varp: " + Math<double>.Varp(4, 6, 2, 0));
        Debug.Log("StDevp: " + Math<double>.StDevp(4, 6, 2, 0));
        Debug.Log("5!: " + Math<double>.Factorial(5));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
