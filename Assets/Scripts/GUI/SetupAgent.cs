
/*
 * The SetupAgent is responsible for interacting with the user by:
 * 		- Gathering deck generation parameters
 * 		- Generating the deck
 * 		- Calling Core.startRound()
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class SetupAgent : MonoBehaviour {
	
	/**
	 * Called every time the Scene was loaded
	 * Note: Only triggers on Application.LoadLevel()
	 * When the Ask Question scene first loads, this should execute.
	 */
	void OnLevelWasLoaded(int level) {
		// Make sure we have a reference to our Game Object
		loadCache ();
		
		// Initialize sliders with the last used values
	}
	
	
	/**
	 * This function tells the core that the player is done modifying
	 * the deck generation preferences and is ready to create the deck
	 * and start playing
	 */
	
	public void startGame(){
		// Make sure we have a reference to our Game Object
		loadCache ();
		
		// Start the game
		myCore.startGame ();
	}

	/**
	 * This function tells the Core to adjust the number of cards to generate
	 */
	public void updateNumberOfCards(){
		// Make sure we have a reference to our Game Object
		loadCache ();

		// Find what the new max number of cards is
		int max = int.Parse(numberOfCards.text);

		// Update the Core
		myCore.setNumberOfCards (max);

	}
	

	
	// Cache the on screen objects to improve performance
	Core myCore;
	InputField numberOfCards;
	
	// Searches out the game for our objects. Caching them improves performance
	void loadCache(){
		// Find Core
		if (myCore == null) {
			myCore = GameObject.Find ("GameCore").GetComponent<Core>();
		}
		
		// Find myAnswer
		if (numberOfCards == null) {
			numberOfCards=GameObject.Find ("NumberOfCards").GetComponent<InputField> ();
		}
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
