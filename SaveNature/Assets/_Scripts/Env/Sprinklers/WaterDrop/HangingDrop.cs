using UnityEngine ;
using System.Collections ;

public class HangingDrop : MonoBehaviour
{

	[SerializeField]
	Transform _waterDropDownPrefab ;

	float _xPosRange = 6f ;

	float _yPosFixed = 10.3f ;

	float _zPosFixed = -45f ;

	int _dropsToBeDropped ;

	Transform _waterDroplet ;

	Vector3 _waterDropletPosition ;

	Quaternion _waterDropletRotation = Quaternion.Euler ( 0 , 0 , 0 ) ;

	// Use this for initialization
	void  Awake ( )
	{
        _xPosRange = Sprinkler.DROPSXPOSRANGE - 0.75f;

        Reset ( ) ;
	}

	void Reset ( )
	{
		_Reposition ( ) ;
		_PrepareWaterDrops ( ) ;
	}

	void _Reposition ( )
	{
		transform.position = new Vector3 ( Random.Range ( -_xPosRange , _xPosRange ) , _yPosFixed , _zPosFixed ) ;
        _waterDropletPosition = transform.position ;
		_waterDropletPosition.y -= 0.1f ;
		_waterDropletPosition.z += 0.1f ;
	}

	void _PrepareWaterDrops ( )
	{
		_dropsToBeDropped = Random.Range ( 1 , 4 ) ;
		_StartDropping ( ) ;
	}

	void _StartDropping ( )
	{
		_DropAWaterDroplet ( ) ;
		_dropsToBeDropped-- ;
		Invoke ( ( _dropsToBeDropped > 0 ) ? "_StartDropping" : "Reset" , Random.Range ( 2f , 5f ) ) ;
	}

	void _DropAWaterDroplet ( )
	{
		_waterDroplet = Instantiate ( _waterDropDownPrefab , _waterDropletPosition , _waterDropletRotation ) as Transform ;
	}
}
