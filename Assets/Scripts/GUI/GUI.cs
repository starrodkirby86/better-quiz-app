using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


/**
 * The GUI is responsible for all user interaction. It displays everything to the user (duh!) as well as grabbing user input]
 */

[System.Serializable]
public class GUI {

/*
 * Core Hooks
 */

	/**
	 * Instructs the GUI to go to and load the next question.
	 * The GUI will load the scene, and ask the question.
	 * After the player has answered the question, the GUI will report the answer back to the Core.
	 * The next GUI task will occur when all the players have answered the question. The Core will then calculate the results and call displayQuestionResults
	 */
	public void nextQuestion (Card nextQuestion){

		// Keep note of levels so that this function does not have any problems
		// repeatedly loading something unnecessarily or something like that. Grunt.
		loadScene (Scene.AskQuestion);

		// Since the loadScene() function is async, the DisplayAgent will have to setup the GUI


	}

	/**
	 * Tells the GUI what the current question's results are and to display them on the screen.
	 * The results will contain each player's question, answer, and correctness of the answer.
	 * The GUI will first display each player's answer along with the correct answeyth vhur.
	 * A dramatic pause between the player's answer and correct answer can be added.
	 * The GUI should signify which questions are correct and which ones aren't.
	 * 
	 * The GUI should then enable a button to let the player continue to the next question.
	 * When the button is pressed, the GUI will report to the Core.
	 * Once all players are ready to move on, the Core will call nextQuestion for the GUI to ask the next question.
	 * If there are no more questions, the Core will call displayFinalResults instead
	 * 
	 * Just a note: This uses the viewNextButton, which currently has pretty bad ways of hiding
	 * the button. We may need to refactor this code in the future to efficiently and more elegantly
	 * hide and make the button appear.
	 */
	public void displayQuestionResults (Results theResults){
		// Audio to play on question load
		GameObject myViewGradeResult = GameObject.Find ("viewGradeResult"); 
		// Gives feedback on correctness
		GameObject myViewGradeText = GameObject.Find ("viewGradeText");
		// Moves on to next question ("Onwards!")
		GameObject myViewNextButton = GameObject.Find ("viewNextButton");

		//Image myViewGradeResultImage = myViewGradeResult.GetComponents<Image> ();
		Text myViewGradeTextComponent = myViewGradeText.GetComponent<Text> ();

		// Update the contents depending on whether you got it right or not
		if (theResults.isCorrect [0]) {
			myViewGradeTextComponent.text = "Hey, " + theResults.players [0].playerName + " got this correct!";
			myViewGradeTextComponent.color = Color.green;
			// Change the graphic to HAPPY
			//(GameObject.Find ("playerReaction")).GetComponent<Image>().sprite = Resources.Load("Cerulean_Happy") as Sprite;
		} else {
			myViewGradeTextComponent.text = theResults.players [0].playerName + " got this wrong. You suck."; 
			myViewGradeTextComponent.color = Color.red;
			// Change the graphic to SAD
			//(GameObject.Find ("playerReaction")).GetComponent<Image>().sprite = Resources.Load ("Cerulean_Sad") as Sprite;
		}
		// Make things appear.
		// TODO: REFACTORING, I CALL DIBS, HANDS OFF NICK -- Watson
		myViewGradeTextComponent.enabled = true;
		(myViewNextButton.GetComponent<Image> ()).enabled = true;
		((GameObject.Find ("viewNextButtonText")).GetComponent<Text>()).enabled = true;
	
	}

	/**
	 * Tells the GUI what the final results are and that it should display them on the screen. Each element in the array is for a different question.
	 * The GUI should show each player's score compared to the competitors and rank them.
	 * There should also be an option for the player to review all of it's questions and answers
	 */
	public void displayFinalResults (List<Results> theResults){
		loadScene (Scene.GameOver);
	}

	/** 
	 * Tells the GUI to load a scene
	 * ex: Title, AskQuestion, GameOver
	 * The return Scene is the next scene to go to
	 * Asserts that scene is loaded.
	 */
	public void loadScene (Scene nextScene){
		Debug.Log ("LOADING " + nextScene.ToString ());
		Application.LoadLevelAsync (nextScene.ToString());
	}

}
