using UnityEngine;
using System.Collections;

public class EventTriggerMediator : MonoBehaviour {
	
	public string ConversationID;
	
	void OnTriggerEnter(Collider other)
	{
		PlayerMediator2 player = other.GetComponent<PlayerMediator2>();
		
		if(player != null)
		{
			//
			// invoke the history event
			//
			
			Messenger.Broadcast(HistoryEvent.Start, ConversationID);
		}
	}
}
