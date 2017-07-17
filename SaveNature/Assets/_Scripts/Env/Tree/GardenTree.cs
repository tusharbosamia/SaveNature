using UnityEngine ;
using System.Collections.Generic ;
using System.Collections ;
using UnityEngine.UI ;

public class GardenTree : MonoBehaviour
{

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Serialize Fields.
    [SerializeField]
    int GrowthItemID;

    Vector2 GrowthItemRange;

    float _LR, _LV;

    [SerializeField]
	Transform _leavesRef ;

	[SerializeField]
	Transform _grassesRef ;

	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Public Variables.

	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Private Variables.
	//	[HideInInspector]
	public List<GameObject> _growingParts ;

	private List<Vector3> _defaultScales ;

	private float _growthTime = 0.2f ;
	// 0.75f ;

	private int _index, _lastBloomIndex;

	int itration ;

	List<int> numbers = new List<int> ( ) ;

	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// GETTERS SETTERS.
	float _growth ;

	float _Growth
	{
		get
		{
			return _growth ;
		}
		set
		{
			_growth = value ;
			_GrowWithAnimation ( ) ;
		}
	}

	float _InstantGrowth
	{
		set
		{
			_growth = value ;
			_GrowInstantly ( ) ;
		}
	}

	// Use this for initialization
	void Awake ( )
	{
		_PopulateGrowingParts ( ) ;

        GrowthItemRange = GD._GrowthItemRangeMaps[GrowthItemID];
        _LR = GrowthItemRange.y - GrowthItemRange.x;
        _CalculateLocalValue();

        _InstantGrowth = _LV;
	}


    void _CalculateLocalValue() {
        _LV = GD._CV_BASE - GrowthItemRange.x;
        _LV /= _LR;
    }

	void _PopulateGrowingParts ( )
	{
		_growingParts = new List<GameObject> ( ) ;
		_defaultScales = new List<Vector3> ( ) ;

		foreach ( Transform leaf in _leavesRef )
		{
			_growingParts.Add ( leaf.gameObject ) ;
			_defaultScales.Add ( leaf.localScale ) ;
		}
//		shuffelLeafPos ( ) ;
		/*foreach (Transform grass in _grassesRef) {
			_growingParts.Add (grass.gameObject);
			_defaultScales.Add (grass.localScale);
		}*/	
	}

	void Start ( )
	{
       
    }

    void _StartGrowing ( )
	{
		InvokeRepeating ( "_GrowOneByOne" , 0.5f , _growthTime + 0.5f ) ;
	}

	public void _StartGrowingImmediately ( )
	{
//		InvokeRepeating ( "_GrowOneByOne" , 0f , _growthTime + 0.25f ) ;
		InvokeRepeating ( "_GrowOneByOne" , 0f , _growthTime ) ;
	}

	public void _GrowInstantly ( )
	{
        //Stop all iTweens;
        /*foreach ( GameObject growingPart in _growingParts )
		{
			iTween.Stop ( growingPart ) ;
		}*/

        //
        int limit = Mathf.FloorToInt(_growth * (_growingParts.Count - 1));
        Debug.Log(GrowthItemID + ", " + _LV + ", " + limit);
        _index = 0 ;
		foreach ( GameObject growingPart in _growingParts )
		{
            if (_index < limit)
            {
                growingPart.transform.localScale = _defaultScales[_index];
                _lastBloomIndex = _index;
            }else
            {
                growingPart.transform.localScale = _defaultScales[_index] * 0f;
            }
			_index++ ;
		}
	}

	void _GrowWithAnimation ( )
	{
		//Stop all iTweens;
		foreach ( GameObject growingPart in _growingParts )
		{
			iTween.Stop ( growingPart ) ;
		}

		//
		_index = 0 ;
		foreach ( GameObject growingPart in _growingParts )
		{
			iTween.ScaleTo ( growingPart , _FetchHash ( ) ) ;
			_index++ ;
		}
	}

	System.Collections.Hashtable _FetchHash ( )
	{
		return iTween.Hash ( "time" , _growthTime , "scale" , _ScaleWithPercentage ( _defaultScales [ _index ] ) , "easeType" , iTween.EaseType.easeOutQuart ) ;
	}

	Vector3 _ScaleWithPercentage ( Vector3 _scale )
	{
		return _scale * _Growth ;
	}

	///////
	/// 

	int _growthIndex = -1 ;

	public void _GrowOneByOne ( )
	{
		_growthIndex++ ;
		if ( _growthIndex >= _growingParts.Count )
		{
			//_ResetGrowth ();
			//_StartGrowing ();
			CancelInvoke ( "_GrowOneByOne" ) ;
		}
		else
		{
			//  For Random Spawn
//			int index = GetRandomIndex ( ) ;
//			Debug.Log ( index ) ;
//			if ( index != 8 && index != 9 )
//			{
//				iTween.ScaleTo ( _growingParts [ index ] , iTween.Hash ( "time" , _growthTime , "scale" , _defaultScales [ _growthIndex ] , "easeType" , iTween.EaseType.easeOutBack ) ) ;
//			}
//			else
//			if ( index == 8 )
//			{
//				_growthIndex-- ;
//			}
			iTween.ScaleTo ( _growingParts [ _growthIndex ] , iTween.Hash ( "time" , _growthTime , "scale" , _defaultScales [ _growthIndex ] , "easeType" , iTween.EaseType.easeOutBack ) ) ;

		}
	}

	public void _ResetGrowth ( )
	{
		CancelInvoke ( "_GrowOneByOne" ) ;
		_growthIndex = -1 ;
		_InstantGrowth = 0 ;
	}



	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Test.
	[SerializeField]
	Slider _growthSlider ;

	public void _SetGrowthFactor ( )
	{
		_Growth = _growthSlider.value ;
	}

	int GetRandomIndex ( )
	{
		int a = 0 ;
		if ( itration >= _growingParts.Count )
		{
			return 0 ;
		}
		else
		{
			while ( a == 0 )
			{    
				a = Random.Range ( 0 , _growingParts.Count + 1 ) ;
				if ( !numbers.Contains ( a ) )
				{
					numbers.Add ( a ) ;
				}
				else
				{
					a = 0 ;
				}
			}
		}
		itration++ ;
		return a ;
	}

    public void _GrowFully()
    {
        _growth = 1f;
        _GrowInstantly();
    }

    void OnEnable()
    {
        InvokeRepeating("_CheckGrowth", 0f, 1f);
    }

    void OnDisable()
    {
        CancelInvoke("_CheckGrowth");
    }
    
    void _CheckGrowth()
    {
        if (_lastBloomIndex < (_growingParts.Count-1)){
            _CalculateLocalValue();
            int limit = Mathf.FloorToInt(_LV * (_growingParts.Count-1));
            if(_lastBloomIndex < limit)
            {
                Debug.Log(_lastBloomIndex + ", " + limit +", "+ _growingParts.Count);
                iTween.ScaleTo(_growingParts[limit], iTween.Hash("time", _growthTime, "scale", _defaultScales[limit], "easeType", iTween.EaseType.easeOutBack));
                _lastBloomIndex = limit;
            }
        }
    }
}
