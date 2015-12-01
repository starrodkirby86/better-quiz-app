using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class TimerAgent : MonoBehaviour {

	float counter;
	bool timerFlag; // If the timer flag is false, the timer should not move.

	// Cache the on screen objects to improve performance
	Core myCore;

	/**
	 * Stops the timer. Actually, it's just a flag to false.
	 */
	public void stopTimer(){
		Debug.Log ("I ran so far away.");
		timerFlag = false;
	}
	
	// Searches out the game for our objects. Caching them improves performance
	void loadCache(){
		// Find Core
		if (myCore == null) {
			myCore = GameObject.Find ("GameCore").GetComponent<Core>();
		}
	}

	// Use this for initialization
	void Start () {

		loadCache ();

		GameObject.Find ("timerText").GetComponent<Text>().text = Mathf.Floor ((counter = myCore.myPreferences.timePerQuestion)).ToString();
		timerFlag = true; 
	}
	
	// Update is called once per frame
	/**
	 * TODO: What should you do after time runs out?
	 */
	void Update () {
		if (counter > 0 && timerFlag)
			GameObject.Find ("timerText").GetComponent<Text>().text = Mathf.Floor ((counter -= 1 * Time.deltaTime)).ToString ();
		else
		{
			//if(myCore.playersNotReady() == 0)
				//GameObject.Find ("DisplayAgent").GetComponent<DisplayAgent>().playerAnswered();
		}

			//Debug.Log ("Player is supposed to stop answering. STOP IT."); // Insert code
	}
}
