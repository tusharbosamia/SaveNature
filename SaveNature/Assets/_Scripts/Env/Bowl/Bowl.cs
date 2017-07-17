using UnityEngine;
using System.Collections;

public class Bowl : MonoBehaviour {

	bool _canBeDragged;

	RaycastHit _raycastHitObj;

	Camera _cam;

	Vector3 _pos;

	AudioSource _bowlAudioSource;

	//Transform _playerHolder;

	//int _moveDir;

	//Vector3 _startPos;

	//Vector3 _startScale;

	//Vector3 _proxyScale;

	// Use this for initialization
	void Awake () {
		_cam = GameObject.Find ("GameCam").GetComponent<Camera> ();
		_pos = transform.position;
		_bowlAudioSource = GetComponent<AudioSource> ();
		//_playerHolder = transform.FindChild ("PlayerHolder");
		//_startScale = _playerHolder.localScale;
		//_proxyScale = _playerHolder.localScale;
	}
	
	// Update is called once per frame
	void Update () {

		if (_canBeDragged) {

			//_moveDir = (Input.mousePosition.x > _startPos.x) ? -1 : ((Input.mousePosition.x < _startPos.x) ? 1 : _moveDir);
		
			_pos.x = _cam.ScreenToWorldPoint (Input.mousePosition).x;
		
			transform.position = _pos;

			//_proxyScale.x = _startScale.x * _moveDir;

			//_playerHolder.localScale = _proxyScale;

			//_startPos = Input.mousePosition;
		}

	}

	void OnEnable()
	{
		EventsManager.PointerDownEvent += PointerDown_EH;
		EventsManager.PointerUpEvent += PointerUp_EH;
	}

	void OnDisable()
	{
		EventsManager.PointerDownEvent -= PointerDown_EH;
		EventsManager.PointerUpEvent -= PointerUp_EH;
	}

	void PointerDown_EH()
	{
		//if (Physics.Raycast (_cam.ScreenPointToRay (Input.mousePosition), out _raycastHitObj, 50f, 1 << 8)) {

		//_startPos = Input.mousePosition;
			
			_canBeDragged = true;

		//}
	}

	void PointerUp_EH()
	{
		_canBeDragged = false;
	}

	void OnTriggerEnter(Collider _drop)
	{
		Destroy (_drop.gameObject);

		_PlayWaterDropletCollectedSound ();

		switch (_drop.GetComponent<Drop> ()._type) {
		case DropType.WATER:
			EventsManager.Notify_DropCollectedEvent ();
			break;

		case DropType.CHEMICAL:
			EventsManager.Notify_ChemicalDropCollectedEvent ();
			break;
		}
			
	}

	void _PlayWaterDropletCollectedSound(){
		_bowlAudioSource.Play ();
	}
}
