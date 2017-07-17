using UnityEngine ;
using System.Collections ;

public class Sprinkler : MonoBehaviour
{
    public static float DROPSXPOSRANGE;

	public GameObject _waterDropPrefab ;

	public GameObject _chemicalDropPrefab ;

	Vector3 _dropPosition = Vector3.zero ;

	int [] randomizer = new int [5] ;

	int randomizerIndex = 0 ;

	int numberOfPollutanDropsPerTenDrops = 1 ;

	int _numberOfHangingDrops = 5 ;


	// Use this for initialization
	void Start ( )
	{
        DROPSXPOSRANGE = Camera.main.ViewportToWorldPoint(new Vector3(1, 1)).x;
        
		_dropPosition.y = 1f ;

		_dropPosition.z = 10f ;

		UpdateRandomizer ( ) ;

		Invoke ( "_Sprinkle" , 1f ) ;
	}
	
	//	// Update is called once per frame
	//	void Update ( )
	//	{
	//
	//	}



	void UpdateRandomizer ( )
	{
	
		int i = 0 ;
		for ( i = 0 ; i < 5 ; i++ )
		{
		
			randomizer [ i ] = 0 ;
		
		}

		i = numberOfPollutanDropsPerTenDrops ;

		int j = Random.Range ( 0 , randomizer.Length ) ;

		while ( i > 0 )
		{
		
			while ( randomizer [ j ] == 1 )
			{

				j = Random.Range ( 0 , randomizer.Length ) ;

			}

			randomizer [ j ] = 1 ;

			i-- ;

		}

		randomizerIndex = -1 ;

	}

	GameObject _GetRandomDrop ( )
	{

		randomizerIndex++ ;

		if ( randomizerIndex >= randomizer.Length )
		{
		
			UpdateRandomizer ( ) ;
		
			randomizerIndex++ ;

		}

		if ( randomizer [ randomizerIndex ] == 1 )
		{
			return _chemicalDropPrefab ;
		}

		return _waterDropPrefab ;
	}

	Transform _GenerateDrop ( )
	{
	
		return( Instantiate ( _GetRandomDrop ( ) ).transform ) ;
	
	}

	void PlaceDrop ( Transform _drop )
	{

		_drop.SetParent ( transform ) ;

		_dropPosition.x = Random.Range ( 0f , 1f ) ;

		_drop.position = Camera.main.ViewportToWorldPoint ( _dropPosition ) ;

	}

	void _Sprinkle ( )
	{
		Debug.Log ( "NO Stop 1" ) ;
	
		//PlaceDrop (GenerateDrop ());		
		_GenerateDrop ( ) ;		

		_numberOfHangingDrops-- ;

		if ( _numberOfHangingDrops > 0 )
		{
			Debug.Log ( "NO Stop 2" ) ;

			Invoke ( "_Sprinkle" , Random.Range ( 0.3f , 0.8f ) ) ;
		}
	}
}
