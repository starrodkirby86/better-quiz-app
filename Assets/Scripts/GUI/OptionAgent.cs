/*
 * The OptionAgent is responsible for letting the user configure where to save
 * the preferences file and where to look for binders
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class OptionAgent : MonoBehaviour {
	
	/**
	 * Tells the Core to save the preferences
	 */
	
	public void saveAndQuit(){
		// Make sure we have a reference to our Game Object
		loadCache ();

		//TODO: Save Preferences

		// After preferences are saved, quit to title screen
		quit ();
	}
	
	/**
	 * Tells the Core to go to the title screen
	 */

	public void quit(){
		// Make sure we have a reference to our Game Object
		loadCache ();

		// Load the title scene
		myCore.loadScene (Scene.Title);
	}
	
	public void options(){
		myCore.loadScene (Scene.Options);
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


