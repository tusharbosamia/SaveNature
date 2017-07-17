using System.Collections ;
using System.Collections.Generic ;
using UnityEngine ;
using UnityEngine.UI ;
using System.Runtime.Serialization.Formatters ;
using UnityEngine.SceneManagement ;

public class LevelsManager : MonoBehaviour
{

	public List<Button> _levels ;

	// Use this for initialization
	void Start ( )
	{
		for ( int i = 0 ; i < _levels.Count ; i++ )
		{
			if ( i <= GD._LastUnloackedLevel - 1 )
			{
				_levels [ i ].interactable = true ;
			}
			else
			{
				_levels [ i ].interactable = false ;

			}
		}
	}
	
	//	// Update is called once per frame
	//	void Update ( )
	//	{
	//
	//	}

	public void  _StartLevel ( int level )
	{
		GD._CurrentLevel = level ;
		SceneManager.LoadScene ( "GamePlay_v1.0.2" ) ;
	}

    public void _Reset() {
        PlayerPrefs.DeleteAll();
    }
}
