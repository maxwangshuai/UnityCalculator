using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMath : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("2^4.5: " + Math<double>.Power(2, 4.5));
        Debug.Log("Ln(450): " + Math<double>.Ln(450));
        for(double i = 0; i < Math<double>.pi; i += 0.1)
        {
            Debug.Log("Sin(" + i + "): " + Math<double>.Sin(i));
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
