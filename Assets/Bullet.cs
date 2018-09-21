using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void Create(Vector3 pos, Vector3 dir, float force)
    {
        GameObject bullet = GameObject.Instantiate(Resources.Load("Bullet")) as GameObject;
        bullet.transform.position = pos;
        bullet.GetComponent<Rigidbody>().AddForce(dir * force);
    }
}
