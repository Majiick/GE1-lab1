using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_Cubes : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        List<Rigidbody> boxes;

		for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.Translate(i * 1f + 10f, j * 1f, 0);
                cube.AddComponent<Rigidbody>();
                cube.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
        }
    }
}
