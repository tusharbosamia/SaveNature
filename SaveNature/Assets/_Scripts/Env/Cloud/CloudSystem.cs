using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSystem : MonoBehaviour {

    [SerializeField]
    int GrowthItemID;

    [SerializeField]
    GameObject cloud1, cloud2, cloud3;

    Vector2 GrowthItemRange;

    float mid;

    // Use this for initialization
    void Start () {
        cloud1.SetActive(false);
        cloud2.SetActive(false);
        cloud3.SetActive(false);
        GrowthItemRange = GD._GrowthItemRangeMaps[GrowthItemID];
        mid = GrowthItemRange.x + ((GrowthItemRange.y - GrowthItemRange.x) / 2f);
    }
	
	// Update is called once per frame
	void _CheckGrowth() {
		if(GD._CV_BASE >= GrowthItemRange.y)
        {
            cloud1.SetActive(true);
            cloud2.SetActive(true);
            cloud3.SetActive(true);
        }else if (GD._CV_BASE >= mid)
        {
            cloud1.SetActive(false);
            cloud2.SetActive(true);
            cloud3.SetActive(true);
        }else if (GD._CV_BASE >= GrowthItemRange.x)
        {
            cloud1.SetActive(false);
            cloud2.SetActive(false);
            cloud3.SetActive(true);
        }else
        {
            cloud1.SetActive(false);
            cloud2.SetActive(false);
            cloud3.SetActive(false);
        }
    }

    void OnEnable()
    {
        InvokeRepeating("_CheckGrowth", 0f, 1f);
    }

    void OnDisable()
    {
        CancelInvoke("_CheckGrowth");
    }
}
