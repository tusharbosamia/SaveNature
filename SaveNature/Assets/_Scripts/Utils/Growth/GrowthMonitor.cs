using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowthMonitor : MonoBehaviour {

    [SerializeField]
    int GrowthItemID;

    Vector2 GrowthItemRange;
    //Vector2 Thresholds;

    [SerializeField]
    //SpriteRenderer _noGrowth;
    SpriteRenderer _fullGrowth;

    //Color _noGrowthColor;
    Color _fullGrowthColor;

    float _LR, _LV;
    //float _LV1, _LV2, _LR1, _LR2;

	// Use this for initialization
	void Start () {
        GrowthItemRange = GD._GrowthItemRangeMaps[GrowthItemID];
        //Thresholds = new Vector2(0.5f, 0f);
        //_noGrowthColor = Color.white;
        _fullGrowthColor = Color.white;
        //_noGrowthColor.a = 1f;
        _fullGrowthColor.a = 0f;
        _LR = GrowthItemRange.y - GrowthItemRange.x;
        //_LR1 = 1f - Thresholds.x;
        //_LR2 = 1f - Thresholds.y;
    }

    void _CheckGrowth()
    {
        //GD._CV += 1f; // This incrementation was for testing purposes.

        /*if (GD._CV < GrowthItemRange.x || GD._CV > GrowthItemRange.y)
        {
            return;
        }*/
        
        _LV = GD._CV - GrowthItemRange.x;
        _LV /= _LR;

        /*if (_LV > Thresholds.x) {
            _LV1 = _LV - Thresholds.x;
            _LV1 /= _LR1;
            _noGrowthColor.a = 1f - _LV1;
            //_noGrowth.color = _noGrowthColor;
        }

        if (_LV > Thresholds.y)
        {
            _LV2 = _LV - Thresholds.y;
            _LV2 /= _LR2;
            _fullGrowthColor.a = _LV2;
            _fullGrowth.color = _fullGrowthColor;
        }*/

        _fullGrowthColor.a = Mathf.Min(_LV, 1f);
        _fullGrowth.color = _fullGrowthColor;
    }

    void OnEnable() {
        InvokeRepeating("_CheckGrowth", 0f, 1f);
    }

    void OnDisable() {
        CancelInvoke("_CheckGrowth");
    }
}
