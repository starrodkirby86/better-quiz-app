/*
 * The LoadingAgent is responsible for moving the game to the title screen
 * when the assets are loaded.
 * Any persistant objects must be declared here and call DontDestroyOnLoad(transform.gameObject);
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class LoadingAgent : MonoBehaviour {

	void OnLevelWasLoaded(int level) {
		// Make sure we have a reference to our Game Object
		loadCache ();
		Debug.Log ("a");
		// Move the core to the title screen
		myCore.loadScene (Scene.Title);
	}
	
	// Cache the on screen objects to improve performance
	Core myCore;
	
	// Searches out the game for our objects. Caching them improves performance
	void loadCache(){
		// Find Core
		if (myCore == null) {
			myCore = GameObject.Find ("GameCore").GetComponent<Core>();
		}
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}



