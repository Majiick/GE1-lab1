using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.Find("Player Model").transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

        CharacterController controller = GetComponent<CharacterController>();
        // gravity
        if (!controller.isGrounded)
        {
            controller.Move(new Vector3(0, -9.81f, 0) * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.A))
        {
            controller.Move(transform.TransformDirection(Vector3.left) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            controller.Move(transform.TransformDirection(Vector3.right) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            controller.Move(transform.TransformDirection(Vector3.forward) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            controller.Move(transform.TransformDirection(Vector3.back) * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Bullet.Create(transform.Find("Player Model/Flare Gun/Tip").transform.position, 
                transform.Find("Player Model").transform.TransformDirection(Vector3.forward), 
                1000.0f);
        }
    }
}
