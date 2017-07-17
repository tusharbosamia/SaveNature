using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour {

	// Use this for initialization
	void Start () {

		transform.localScale -= (Vector3.one * 0.2f);
		transform.localScale += (Vector3.one * Random.Range(0f, 0.6f));

		AudioSource _audioSource = GetComponent<AudioSource> ();
		float _destroyTime = _audioSource.clip.length + 0.5f;
		Destroy (_audioSource, _destroyTime);

		Transform _leavesSprout = transform.Find ("Leaves Sprout");
		Destroy (_leavesSprout.gameObject, _destroyTime+0.5f);

	}
}
