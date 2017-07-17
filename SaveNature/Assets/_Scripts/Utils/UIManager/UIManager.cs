using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	[SerializeField]
	Text _dropsCollectedTxt;

	[SerializeField]
	Text _dropsMissedTxt;

	StatsManager _statsManagerRef;

	// Use this for initialization
	void Awake () {
		_statsManagerRef = GameObject.Find ("StatsManager").GetComponent<StatsManager> ();

		Reset ();
	}

	void Start()
	{
		InvokeRepeating ("_UpdateDropCounts", 0.25f, 0.25f);
	}
	
	// Update is called once per frame
	void _UpdateDropCounts () {

		_dropsCollectedTxt.text = _statsManagerRef._DropsCollected.ToString ();

		_dropsMissedTxt.text = _statsManagerRef._DropsMissed.ToString ();

	}

	void Reset()
	{
		_dropsCollectedTxt.text = "0";
		_dropsMissedTxt.text = "0";
	}
}
