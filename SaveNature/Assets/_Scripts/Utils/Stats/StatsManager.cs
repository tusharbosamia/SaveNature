using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    [SerializeField]
	Text _CVText, _RVText;

	[SerializeField]
	Transform _RVValueBar;

	Vector3 _RVValueBarScale;

	int _minDropsToStartTrigerEvent = 0 ;

	int _dropstoTiggerNextEvent = 20 ;

	int _nextFruitAt = 0 ;

	int _dropsCollected ;

	public int _DropsCollected
	{
		get
		{ 
			return _dropsCollected ;
		}
	}

	int _chemicalDropsCollected ;

	public int _ChemicalsDropsCollected
	{
		get
		{ 
			return _chemicalDropsCollected ;
		}
	}

	int _dropsMissed ;

	public int _DropsMissed
	{
		get
		{ 
			return _dropsMissed ;
		}
	}

	// Use this for initialization
	void Awake ( )
	{
		Reset ( ) ;
	}
	
	// Update is called once per frame
	void Update ( )
	{
		_CVText.text = GD._CV_BASE.ToString();
		_RVText.text = GD._RV_BASE.ToString();
		_RVValueBarScale.x = GD._RV_BASE / 100.0f;
		_RVValueBar.localScale = _RVValueBarScale;
    }

	void OnEnable ( )
	{
		EventsManager.DropCollectedEvent += DropCollected_EH ;
		EventsManager.ChemicalDropCollectedEvent += ChemicalDropCollected_EH ;
		EventsManager.DropMissedEvent += DropMissed_EH ;
	}

	void OnDisable ( )
	{
		EventsManager.DropCollectedEvent -= DropCollected_EH ;
		EventsManager.ChemicalDropCollectedEvent -= ChemicalDropCollected_EH ;
		EventsManager.DropMissedEvent -= DropMissed_EH ;
	}

	void DropCollected_EH ( )
	{
		_dropsCollected++ ;
        GD._IncrementRV();
		CheckDate._UpdateLastActiveDate ();
	}

	void ChemicalDropCollected_EH ( )
	{
		_chemicalDropsCollected++ ;
		_dropsCollected-- ;
        GD._DecrementRV();
		CheckDate._UpdateLastActiveDate ();
    }

    void DropMissed_EH ( )
	{
		_dropsMissed++ ;
		CheckDate._UpdateLastActiveDate ();
	}

	void Reset ( )
	{
        GD._RefreshCV();

		_dropsCollected = 0 ;

		_chemicalDropsCollected = 0 ;

		_dropsMissed = 0 ;

		_nextFruitAt = _minDropsToStartTrigerEvent + _dropstoTiggerNextEvent ;

		_RVValueBarScale = new Vector3 (0.0f, 1.0f, 1.0f);

		_RVValueBar.localScale = _RVValueBarScale;
	}
}
