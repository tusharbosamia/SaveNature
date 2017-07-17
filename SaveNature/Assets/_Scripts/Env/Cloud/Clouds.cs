using UnityEngine;
using System.Collections;

public class Clouds : MonoBehaviour {

	float _cloudSpeed = -1.5f;

	float _leftLimit = -15f;

	float _rightLimit = 15f;

	Vector3 _newPosition;

	// Use this for initialization
	void Start () {
		
		InvokeRepeating ("_Reposition", 0.5f, 0.5f);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate (transform.right * Time.deltaTime * _cloudSpeed);
	
	}

	void _Reposition(){
	
		if (transform.position.x < _leftLimit) {

			_newPosition = transform.position;

			_newPosition.x = _rightLimit;

			_newPosition.y = Random.Range(4f, 9f);

			transform.position = _newPosition;

			_cloudSpeed = Random.Range (0.25f, 1f);

			transform.localScale = Vector3.one * _cloudSpeed;

			_cloudSpeed *= -1.5f;

		}

	}
}
