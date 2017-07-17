using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDate : MonoBehaviour {

    void Start()
    {
		Debug.Log ("GD._DateChecked : " + GD._DateChecked);
		if (GD._DateChecked) {
			_UpdateLastActiveDate ();
		} else {
			_FindInactiveDays ();
		}
    }


    public static void _FindInactiveDays()
    {
        DateTime lastActiveDate = System.DateTime.Now;

        if (PlayerPrefs.HasKey("LastActiveDate")) {
            lastActiveDate = System.Convert.ToDateTime(PlayerPrefs.GetString("LastActiveDate"));
        } else {
			PlayerPrefs.SetString("LastActiveDate", lastActiveDate.ToString());
        }

        //Debug.Log("lastActiveDate : " + lastActiveDate.ToString());

        DateTime today = System.DateTime.Now;

        System.TimeSpan elapsed = today.Subtract(lastActiveDate);

		//double days = elapsed.TotalDays;
		double days = elapsed.TotalMinutes;

        int inactiveDays = int.Parse(days.ToString("0"));

		//Debug.Log("NoOfInactiveDays : " + inactiveDays);

        inactiveDays =  Mathf.Max(0, inactiveDays);

		//float _cv_base = GD._CV_BASE - (inactiveDays * GD._CV_INACTIVE_RATE);
		float _deduction = inactiveDays * GD._CV_INACTIVE_RATE;
		float _balanceDeduction = 0f + _deduction;
		if (GD._RV_BASE > 0) {
			float _balanceRV = GD._RV_BASE - _deduction;
			if (_balanceRV < 0) {
				GD._RV_BASE = 0.0f;
				_balanceDeduction = -_balanceRV;
			} else {
				GD._RV_BASE = _balanceRV;
				_balanceDeduction = 0;
			}
		}

		if (_balanceDeduction > 0) {
			float _cv_base = GD._CV_BASE - _balanceDeduction;
			GD._CV_BASE = Mathf.Max(0, _cv_base);
		}


        _UpdateLastActiveDate();

		GD._DateChecked = true;

		/*DateTime _dummy = new DateTime (2017, 4, 1);

		elapsed = today.Subtract(_dummy);

		Debug.Log("Minutes : " + elapsed.Minutes);
		Debug.Log("Total Minutes : " + elapsed.TotalMinutes);
		Debug.Log("Seconds : " + elapsed.Seconds);
		Debug.Log("Total Seconds : " + elapsed.TotalSeconds);*/

    }

    public static void _UpdateLastActiveDate()
    {
        DateTime lastActiveDate = System.DateTime.Now;
        PlayerPrefs.SetString("LastActiveDate", lastActiveDate.ToString());
    }

    /*void OnApplicationPause(bool pauseStatus)
    {
		//Debug.Log ("OnApplicationPause");

        //_UpdateLastActiveDate();
    }*/

    void OnApplicationQuit()
    {
		//Debug.Log ("OnApplicationQuit");

        _UpdateLastActiveDate();
    }
}
