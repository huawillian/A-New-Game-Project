using UnityEngine;
using System.Collections;

public class Enemy_Movement : MonoBehaviour
{
	public NavMeshAgent agent;
	public GameObject person;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		agent.destination = person.transform.position; //transform of the person object
		agent.updateRotation = false;
	}
}
