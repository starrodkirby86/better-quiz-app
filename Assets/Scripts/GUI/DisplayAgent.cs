
/*
 * The DisplayAgent is responsible for interacting with the user by:
 * 		- Disecte the Card and display the QuestionText and possible answers
 * 		- Processing the user input and calling the appropriate function in the Core to progress it to the next state
 * 		- Disect the Results and display them to the user for
 * 			+ Per round results
 * 			+ Final results
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayAgent : MonoBehaviour {
	 
	/**
	 * Called every time the Scene was loaded
	 * Note: Only triggers on Application.LoadLevel()
	 * When the Ask Question scene first loads, this should execute.
	 */
	void OnLevelWasLoaded(int level) {
		loadCache ();
		if (myCore != null)
			Debug.Log ("We found the Core :D");
		else
			Debug.Log ("No Core.... :(");
		Debug.Log (level);
		Debug.Log ("That level was loaded. ;)");
		editDisplayText();
	}


	/**
	 * Takes the current card of the core (drawn
	 * from the deck), and edits the question text
	 * to reflect this.
	 */
	void editDisplayText()
	{
		Text myText = (GameObject.Find ("viewCardText")).GetComponent<Text> ();
		myText.text = myCore.currentCard.questionText; // Overwrites the debug text
	}

	/**
	 * This function launches from the input field UI object inside
	 * the AskQuestion scene. This should return through to the Core
	 * and get ready for grading (in other words, get a wrong answer!!!).
	 */
	public void playerAnswered()
	{
		// Look for viewInputAnswer game object
		// Grab the text game component of that
		// That Text object has the text string, so we grab that
		// declare a new answer obj passing that text string in the constructor
		// WHERE MY LINES OF CODE AT
		Answer myAnswer = new Answer(((GameObject.Find ("viewInputAnswer")).GetComponent<InputField> ()).text);

		// Pass it to the core for grading.
		// Hardcoded as 0 because you only have one player.
		myCore.playerAnswer (0, myAnswer);

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

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
