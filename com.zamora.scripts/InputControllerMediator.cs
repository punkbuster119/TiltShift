using UnityEngine;
using System.Collections;

/// <summary>
/// Input controller mediator.
/// handle the player input
/// </summary>
public class InputControllerMediator : MonoBehaviour 
{	
	float direction = 1f;
	
	float inputX = 0f;
	
	public bool stopped = false;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		#if UNITY_EDITOR || UNITY_WEBPLAYER
			
		inputX = Input.GetAxisRaw("Horizontal");
		
		if(Input.GetKeyDown( KeyCode.Space ))
		{
			Messenger.Broadcast(InputEvent.Jump);
		}
		
		#endif
		
		Messenger.Broadcast(InputEvent.Move, inputX);
	}
	
	void leftButtonClickDownHandler ()
	{
		inputX = -1;
		
		Debug.Log("left button pressed");
	}

	void leftButtonClickUpHandler ()
	{
		inputX = 0;
	}
	
	void rightButtonClickDownHandler ()
	{
		inputX = 1;
		
		Debug.Log("right button pressed");
	}
	
	void rightButtonClickUpHandler ()
	{
		inputX = 0;
	}
	
	void stopRunButtonClickHandler ()
	{
	}
	
	void jumpButtonClickHandler ()
	{
		Debug.Log("jump button pressed");
		
		Messenger.Broadcast(InputEvent.Jump);
	}
}
