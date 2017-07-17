using System.Collections ;
using System.Collections.Generic ;
using UnityEngine ;

public class NewBehaviourScript : MonoBehaviour
{

	public int maxNumbers = 20 ;

	public List<int> uniqueNumbers ;

	public  List<int> finishedList ;

	public int ir ;

	public int _r ;

	public int itration ;

	void Start ( )
	{
//		uniqueNumbers = new List<int> ( ) ;
		finishedList = new List<int> ( ) ;
//		prepare ( ) ;
		_r = GenerateRandomList ( ) ;
	}

	void prepare ( )
	{
		for ( int i = 0 ; i < maxNumbers ; i++ )
		{
			uniqueNumbers.Add ( i ) ;
		}
	}

	public void callRand ( )
	{
		_r = GenerateRandomList ( ) ;
	}


	public int GenerateRandomList ( )
	{

		int a = 0 ;
		if ( itration >= maxNumbers )
		{
			return 0 ;
		}
		while ( a == 0 )
		{    
			a = Random.Range ( 0 , maxNumbers + 1 ) ;
			if ( !finishedList.Contains ( a ) )
			{
				finishedList.Add ( a ) ;
			}
			else
			{
				a = 0 ;
			}
		}
		ir = a ;
		itration++ ;
		return ir ;

//		Debug.Log ( "Called" ) ;
//		
////		for ( int i = 0 ; i < maxNumbers ; i++ )
////		{
//		int ranNum = uniqueNumbers [ Random.Range ( 0 , uniqueNumbers.Count ) ] ;
////		
//
//		if ( finishedList.Count == 0 )
//		{
//			ir = ranNum ;
//			finishedList.Add ( ranNum ) ;
//
//		}
//		else
//		{
//			for ( int i = 0 ; i < finishedList.Count ; i++ )
//			{
//				if ( finishedList [ i ] == ranNum )
//				{
////					callRand ( ) ;
//					ir = GenerateRandomList ( ) ;
//					break ;
//				}
//				else
//				{
//					ir = ranNum ;
//					finishedList.Add ( ranNum ) ;
//				}
//			}
//		}
////			
//			foreach ( int i in finishedList )
//			{
//				if ( i != ranNum )
//				{
//					finishedList.Add ( ranNum ) ;
//					ir = ranNum ;
//					//				break ;
//				}
//				else
//				{
//					callRand ( ) ;
//					//return  ir ;
//					//				break ;
//				}
//			}
//		}
//		return ir ;
		//finishedList.Add ( ranNum ) ;

		//uniqueNumbers.Remove ( ranNum ) ;
//		} 
		//Done.
	}
	//	}
}
