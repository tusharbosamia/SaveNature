using System.Collections ;
using System.Collections.Generic ;
using UnityEngine ;
using UnityEngine.UI ;
using UnityEngine.SceneManagement ;

public class LevelManager : MonoBehaviour
{

	public StatsManager _statsManagerObj ;

	public Sprinkler _sprinklerObj ;

	public GameObject _levelCompletePanel ;

	public Text _star ;

	public Text _score ;



	// Use this for initialization
	void Start ( )
	{
		_levelCompletePanel.SetActive ( false ) ;	
	}

	void OnEnable ( )
	{
		EventsManager.LevelCompleteEvent += LevelComplete_EH ;
	}

	void OnDisable ( )
	{		
		EventsManager.LevelCompleteEvent -= LevelComplete_EH ;

	}

	void  LevelComplete_EH ( )
	{
//		_sprinklerObj._stopSprinkler ( ) ;
		float ratio ;
		ratio = _statsManagerObj._DropsCollected / _statsManagerObj._DropsMissed ;
		if ( ratio > 0.7f )
		{
			_star.text = "3" ;
			_score.text = ( _statsManagerObj._DropsCollected * 15 ).ToString ( ) ;
		}
		else
		if ( ratio > 0.3f && ratio < 0.7f )
		{
			_star.text = "2" ;

			_score.text = ( _statsManagerObj._DropsCollected * 10 ).ToString ( ) ;
			
		}
		else
		if ( ratio < 0.3f )
		{
			_star.text = "1" ;
			_score.text = ( _statsManagerObj._DropsCollected * 5 ).ToString ( ) ;
			
		}
		else
		{
			_star.text = "0" ;
			_score.text = ( _statsManagerObj._DropsCollected ).ToString ( ) ;	
		}
		_levelCompletePanel.SetActive ( true ) ;
		Time.timeScale = 0 ;

	}

	public void _Replay ( )
	{
		Time.timeScale = 1 ;
		SceneManager.LoadScene ("GamePlay_v1.0.2") ;
	}

	public void _NextLevel ( )
	{
		Time.timeScale = 1 ;

		if ( GD._CurrentLevel >= GD._LastUnloackedLevel )
		{
			GD._LastUnloackedLevel = GD._CurrentLevel + 1 ;
		}
		SceneManager.LoadScene ( "LevelSelection" ) ;
	}

    
}