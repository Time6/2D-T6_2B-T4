using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    // Use this for initialization
    float seconds;
    int minutes;
    [SerializeField]Text timeUI;
   


	void Start () {

        seconds = 60f;
        minutes = 7;
	}
	
	// Update is called once per frame
	void Update () {

        seconds -= Time.deltaTime;
        if (seconds <= 0)
        {
            minutes -= 1;
            seconds = 60f;
        }
        timeUI.text = minutes.ToString() + ":" + seconds.ToString();
       

	}
}
