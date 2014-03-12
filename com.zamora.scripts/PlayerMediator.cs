using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerMediator : MonoBehaviour {
	
	public float speed = 3.0F;
	
    public float rotateSpeed = 3.0F;
	
	private CharacterController controller;
	
	private Vector3 targetPosition = Vector3.zero;
	
	void Start()
	{
		controller = GetComponent<CharacterController>();
		
		//
		// make the camera follow me
		//
		
		Messenger.Broadcast(CameraEvent.Focus, transform);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//
		// get mouse click position
		//
		
		Vector3 clickPosition = Vector3.zero;
		
		Vector3 direction = Vector3.zero;
		
		if(Input.GetMouseButton(0))
		{
			Plane playerPlane = new Plane(Vector3.up, transform.position);
			
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			float hitdist = 0.0f;
	 
			if (playerPlane.Raycast (ray, out hitdist)) 
			{
				var targetPoint = ray.GetPoint(hitdist);
				targetPosition = ray.GetPoint(hitdist);
				var targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
				transform.rotation = targetRotation;
			}
 
			direction = transform.position - targetPosition;
			
			/*clickPosition = Camera.main.ScreenToWorldPoint( new Vector3( Input.mousePosition.x, Input.mousePosition.y, 1f ) );
			
			Debug.Log( "000: " + clickPosition );
			
			direction = transform.position - clickPosition;*/
		}
		else
		{
			float horizontalAxis = Input.GetAxis("Horizontal");
		
			float verticalAxis = Input.GetAxis("Vertical");
		
			direction = new Vector3(horizontalAxis, 0f, verticalAxis);
			
			//
			// adjust the direction because we need to rotate the axis 45 degrees in y 
			//
			
			direction = Quaternion.AngleAxis(45f, Vector3.up) * direction;
		}
		
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
			//Vector3.Lerp (transform.position, targetPosition, Time.deltaTime);
		
		
		
		//controller.SimpleMove(direction * speed);
	}
}
