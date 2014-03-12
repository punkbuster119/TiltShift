using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMediator2 : MonoBehaviour {
	
	public List<Collider> TouchingColliders;
	
	// Use this for initialization
	void Start ()
	{
		TouchingColliders = new List<Collider>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKey("space"))
		{
			Interact();
		}
	}
	
	void Interact()
	{
		//
		// Get the interaction mediator of the other object
		//
		
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		TouchingColliders.Add( other );
	}
	
	void OnTriggerExit(Collider other)
	{
		TouchingColliders.Remove( other );
	}
}
