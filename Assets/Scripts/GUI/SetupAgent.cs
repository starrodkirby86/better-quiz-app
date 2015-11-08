
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
public class DisplayAgent : MonoBehaviour {
	
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
	
	void editDisplayText(){
		// Make sure we have a reference to our Game Object
		loadCache ();
		
		// Grab the Card's questionText and places it on the screen
		questionText.text = myCore.currentCard.questionText;
	}
	
	/**
	 * This function launches from the input field UI object inside
	 * the AskQuestion scene. This should return through to the Core
	 * and get ready for grading (in other words, get a wrong answer!!!).
	 */
	public void playerAnswered()
	{
		// Make sure we have a reference to our Game Object
		loadCache ();
		
		// That InputField object has the text string, so we grab that
		// declare a new answer obj passing that text string in the constructor
		// WHERE MY LINES OF CODE AT
		Answer myAnswer = new Answer(shortAnswerInput.text);
		
		// Hard code short answer questions only
		// TODO: Generalize to other question types
		myAnswer.myQuestionType = QuestionType.ShortAnswer;
		
		// Pass it to the core for grading.
		// Hardcoded as 0 because you only have one player.
		// TODO: Have the DisplayAgent recognize which player it is
		myCore.playerAnswer (0, myAnswer);
	}
	
	// Cache the on screen objects to improve performance
	Core myCore;
	Text questionText;
	InputField shortAnswerInput;
	
	// Searches out the game for our objects. Caching them improves performance
	void loadCache(){
		// Find Core
		if (myCore == null) {
			myCore = GameObject.Find ("GameCore").GetComponent<Core>();
		}
		
		// Find questionText
		if (questionText == null) {
			questionText = GameObject.Find ("viewCardText").GetComponent<Text> ();
		}
		
		// Find myAnswer
		if (shortAnswerInput == null) {
			shortAnswerInput=GameObject.Find ("viewInputAnswer").GetComponent<InputField> ();
		}
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
