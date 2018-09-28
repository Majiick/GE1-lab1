using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour {
    Queue<Transform> wps;
    Vector3 lerpFromPos;
    float lerpValue = 0f;

    void Awake() {
        wps = new Queue<Transform>();

        int i = 0;
        float r = 3f;
        for (float t = 0; t < Mathf.PI * 2; t++) {
            i++;
            float x = r * Mathf.Cos(t);
            float y = r * Mathf.Sin(t);

            GameObject wp = new GameObject();
            wp.transform.position = new Vector3(x, 0, y);
            wp.transform.name = i.ToString();
            wps.Enqueue(wp.transform);
        }
    }

	// Use this for initialization
	void Start () {
        lerpFromPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 moveTowards = wps.Peek().position;
        Vector3 dir = moveTowards - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * 10.0f);

        transform.position = Vector3.Lerp(lerpFromPos, moveTowards, lerpValue);
        lerpValue += 2.0f * Time.deltaTime;


        if (Vector3.Distance(transform.position, moveTowards) < 0.05f) {
            var node = wps.Dequeue();
            wps.Enqueue(node);
            lerpValue = 0.0f;
            lerpFromPos = transform.position;
        }
    }
}
