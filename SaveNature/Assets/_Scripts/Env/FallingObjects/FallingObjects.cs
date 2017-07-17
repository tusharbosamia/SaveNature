using UnityEngine;
using System.Collections;

public class FallingObjects : MonoBehaviour {

	protected bool _canFall = false;

	protected float _fallingSpeed = 1f;

	protected Vector3 _newPosition;

	protected void Start () {
		
		_canFall = false;

	}
	
	// Update is called once per frame
	void Update () {
		
		if (_canFall) {

			_FallDown ();
		
		}
	}

	protected void _FallDown(){
	
		_newPosition = transform.position;

		_CalculateNewPostition ();

		transform.position = _newPosition;
	
	}

	protected virtual void _CalculateNewPostition(){
	
		_newPosition.y -= (_fallingSpeed * Time.deltaTime);
	
	}

	public void _StartFalling(){
		_canFall = true;
	}
}
