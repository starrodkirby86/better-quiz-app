
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

		// Push the questionText to the screen
		editDisplayText();
	}


	/**
	 * Takes the current card of the core (drawn
	 * from the deck), and edits the question text
	 * to reflect this.
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
		// Hardcoded as 1 because you only have one player.
		// TODO: Have the DisplayAgent recognize which player it is
		myCore.playerAnswer (myCore.players[0].playerID, myAnswer);
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
