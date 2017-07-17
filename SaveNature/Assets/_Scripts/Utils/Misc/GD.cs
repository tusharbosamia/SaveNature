using System.Collections ;
using System.Collections.Generic ;
using UnityEngine ;

public static class GD
{
	public static bool _DateChecked = false;

    public static float _CV_BASE
    {
        get { return PlayerPrefs.GetFloat("CV", 0f); }
        set { PlayerPrefs.SetFloat("CV", value); _RefreshCV(); }
    }

	public static float _RV_BASE
	{
		get { return PlayerPrefs.GetFloat("RV", 0f); }
		set { PlayerPrefs.SetFloat("RV", value); }
	}

    public const float _CV_MAX = 100f;

    public const float _CV_STEP = (1f / 4f);

    public static float _CV;

    public static float _CV_INACTIVE_RATE = 1f;

    public static int _CurrentLevel ;

	public static int _LastUnloackedLevel = 1 ;

    public static Vector2[] _GrowthItemRangeMaps = new Vector2[8] {
        new Vector2(0, 50f),    // 0 - ground
        new Vector2(10f, 60f),  // 1 - border trees
        new Vector2(20f, 70f),  // 2 - mountains
        new Vector2(30f, 80f),  // 3 - sky
        new Vector2(10f, 30f),  // 4 - sky
        new Vector2(25f, 45f),  // 5 - sky
        new Vector2(40f, 60f),  // 6 - sky
        new Vector2(20f, 60f)  // 7 - sky
    };

    public static void _RefreshCV ()
    {
        _CV = _CV_BASE;
    }

    public static void _IncrementCV ()
    {
        _CV_BASE = _CV_BASE + _CV_STEP;
    }

    public static void _DecrementCV ()
    {
        _CV_BASE = _CV_BASE - _CV_STEP;
    }

	public static void _IncrementRV ()
	{
		_RV_BASE = _RV_BASE + _CV_STEP;
		_IncrementCV ();
	}

	public static void _DecrementRV ()
	{
		float _val = _RV_BASE - _CV_STEP;
		if (_val < 0) {
			_RV_BASE = 0.0f;
			_DecrementCV ();
		} else {
			_RV_BASE = _val;
		}
	}
}
