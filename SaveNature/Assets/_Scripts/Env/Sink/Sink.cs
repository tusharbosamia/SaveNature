using UnityEngine;
using System.Collections;

public class Sink : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider _drop)
	{
		Destroy (_drop.gameObject);

		if (_drop.GetComponent<Drop> ()._type == DropType.WATER) {

			EventsManager.Notify_DropMissedEvent ();
		
		}
	}
}
