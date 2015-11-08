/*
 * The DisplayAgent is responsible for interacting with the user by:
 * 		- Disecte the Card and display the QuestionText and possible answers
 * 		- Processing the user input and calling the appropriate function in the Core to progress it to the next state
 * 		- Disect the Results and display them to the user for
 * 			+ Per round results
 * 			+ Final results
 */

using UnityEngine;
using System.Collections;

public class DisplayAgent : MonoBehaviour {
	
	/**
	 * Called every time the Scene was loaded
	 * Note: Only triggers on Application.LoadLevel()
	 */
	void OnLevelWasLoaded(int level) {
		loadCache ();
		if (myCore != null)
			Debug.Log ("We found the Core :D");
		else
			Debug.Log ("No Core.... :(");
		Debug.Log (level);
		Debug.Log ("That level was loaded. ;)");
	}

	// Cache the GameCore to improve performance
	Core myCore;

	// Searches out the game for our objects. Caching them improves performance
	void loadCache(){
		// Find Core
		if (myCore == null) {
			GameObject coreObject = GameObject.Find ("GameCore");
			myCore = coreObject.GetComponent<Core>();
		}
	}

	// Use this for initialization
	void Start () {
		// Grab the Game Objects
		loadCache ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
