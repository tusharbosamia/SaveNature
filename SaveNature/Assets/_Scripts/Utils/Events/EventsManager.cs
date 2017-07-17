using UnityEngine ;
using System.Collections ;

public class EventsManager : MonoBehaviour
{

	public delegate void NoArgumentEvent ( );

	public static NoArgumentEvent PointerDownEvent ;

	public static NoArgumentEvent PointerUpEvent ;

	public static NoArgumentEvent DropCollectedEvent ;

	public static NoArgumentEvent ChemicalDropCollectedEvent ;

	public static NoArgumentEvent DropMissedEvent ;

	public static NoArgumentEvent GrowFruitEvent ;

	public static NoArgumentEvent AnimateBGEvent ;

	public static NoArgumentEvent LevelCompleteEvent ;


	public static void Notify_PointerDownEvent ( )
	{
	
		if ( PointerDownEvent != null )
		{
		
			PointerDownEvent ( ) ;

		}
	
	}

	public static void Notify_PointerUpEvent ( )
	{

		if ( PointerUpEvent != null )
		{

			PointerUpEvent ( ) ;

		}

	}

	public static void Notify_DropCollectedEvent ( )
	{

		if ( DropCollectedEvent != null )
		{

			DropCollectedEvent ( ) ;

		}

	}

	public static void Notify_ChemicalDropCollectedEvent ( )
	{

		if ( ChemicalDropCollectedEvent != null )
		{

			ChemicalDropCollectedEvent ( ) ;

		}

	}

	public static void Notify_DropMissedEvent ( )
	{

		if ( DropMissedEvent != null )
		{

			DropMissedEvent ( ) ;

		}

	}

	public static void Notify_GrowFruitEvent ( )
	{

		if ( GrowFruitEvent != null )
		{

			GrowFruitEvent ( ) ;

		}

	}

	public static void Notify_AnimateBGEvent ( )
	{
		if ( AnimateBGEvent != null )
		{
			AnimateBGEvent ( ) ;
		}
	}

	public static void Notify_LevelCompleteEvent ( )
	{
		if ( LevelCompleteEvent != null )
		{

			LevelCompleteEvent ( ) ;

		}
	}
}
