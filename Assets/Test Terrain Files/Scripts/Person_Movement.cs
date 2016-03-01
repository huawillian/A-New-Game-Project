using UnityEngine;
using System.Collections;

public class Person_Movement : MonoBehaviour
{
	public Rigidbody rigidbody;


	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		Vector3 vel = Vector3.zero;

		if (Input.GetKey (KeyCode.W)) {
			print ("W is held down");
			vel += new Vector3 (0,0,2);
		}

		if (Input.GetKey (KeyCode.A)) {
			print ("A is held down");
			vel += new Vector3 (-2,0,0);
		}

		if (Input.GetKey (KeyCode.S)) {
			print ("S is held down");
			vel += new Vector3 (0,0,-2);
		}

		if (Input.GetKey (KeyCode.D)) {
			print ("D is held down");
			vel += new Vector3 (2,0,0);
		}

		rigidbody.velocity = vel;
	}
}
