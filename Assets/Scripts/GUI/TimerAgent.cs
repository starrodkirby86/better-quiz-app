
using UnityEngine;
using System.Collections;

public class TimerAgent : MonoBehaviour {

	float counter;

	// Use this for initialization
	void Start () {
		counter = 500; 
	}
	
	// Update is called once per frame
	void Update () {
		if (counter > 0)
			counter -= 1 * Time.deltaTime;
		else
			Debug.Log ("Player is supposed to stop answering. STOP IT.");
	}
}
