using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour {

	EventSystem _eventSystemRef;

	// Use this for initialization
	void Start () {
		
		_eventSystemRef = FindObjectOfType<EventSystem> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (_eventSystemRef != null && _eventSystemRef.IsPointerOverGameObject ()) 
		{
			return;
		}

		if (Input.GetMouseButtonDown (0)) 
		{
			EventsManager.Notify_PointerDownEvent ();
		}

		if (Input.GetMouseButtonUp (0)) 
		{
			EventsManager.Notify_PointerUpEvent ();
		}

	}
}
