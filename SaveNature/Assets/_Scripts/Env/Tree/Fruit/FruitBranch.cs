using UnityEngine ;
using System.Collections.Generic ;

public class FruitBranch : MonoBehaviour
{

	[SerializeField]
	Transform FruitPrefab ;

	Transform _FruitPositions ;

	List<Vector3> Positions = new List<Vector3> ( ) ;

	Transform Fruit ;

	// Use this for initialization
	void Awake ( )
	{
		_FruitPositions = transform.Find ( "FruitPositions" ) ;
		foreach ( Transform fruitPosition in _FruitPositions )
		{
			Positions.Add ( fruitPosition.position ) ;
		}
		Destroy ( _FruitPositions.gameObject ) ;
	}
	
	// Update is called once per frame
	void Update ( )
	{
	
	}

	Vector3 _GetFruitPosition ( )
	{
	
		Vector3 pos = Vector3.zero ;

		if ( Positions.Count > 0 )
		{
		
			pos = Positions [ 0 ] ;

			Positions.RemoveAt ( 0 ) ;
		}

		return pos ;
	
	}

	void OnEnable ( )
	{

		EventsManager.GrowFruitEvent += GrowFruit_EH ;

	}

	void OnDisable ( )
	{

		EventsManager.GrowFruitEvent -= GrowFruit_EH ;

	}

	void GrowFruit_EH ( )
	{
	
		Vector3 pos = _GetFruitPosition ( ) ;

		if ( Positions.Count > 0 )
		{
			
			Fruit = Instantiate ( FruitPrefab ) as Transform ;

			Fruit.SetParent ( transform ) ;

			Fruit.position = pos ;
		}
	}
}
