using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerAgent : MonoBehaviour {

	float counter;

	// Use this for initialization
	void Start () {
		GameObject.Find ("timerText").GetComponent<Text>().text = (counter = 500).ToString();

	}
	
	// Update is called once per frame
	/**
	 * TODO: What should you do after time runs out?
	 */
	void Update () {
		if (counter > 0)
			GameObject.Find ("timerText").GetComponent<Text>().text = (counter -= 1 * Time.deltaTime).ToString ();
		else
			Debug.Log ("Player is supposed to stop answering. STOP IT."); // Insert code
	}
}
