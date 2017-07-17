using UnityEngine;
using System.Collections;

public class Drop : FallingObjects {

	public DropType _type;

    private float _swayFactor;

	// Use this for initialization
	void Start () {
		_fallingSpeed = Random.Range (6f, 12f);

        if (_type == DropType.CHEMICAL) {
            _fallingSpeed *= 2f;
            _swayFactor = Random.Range(-1, 2) * 2f;
        }

		float speedPercent = (_fallingSpeed - 4f) / 4 * 0.1f;

		transform.localScale += ((Vector3.one * speedPercent * 0.5f) - (Vector3.one * 0.1f));

        base.Start ();
	}

    protected override void _CalculateNewPostition()
    {
        if (_type == DropType.CHEMICAL)
        {
            _newPosition.x += (_swayFactor * Time.deltaTime);
        }
        base._CalculateNewPostition();
    }
}

public enum DropType{
	WATER,
	CHEMICAL
}