/*
 * Game Flow Portion of the Core
 * This file contains all of the states in the state machine
 */

using UnityEngine;					// For MonoBehaviour
using System.Collections.Generic; 	// For Lists

public partial class Core : MonoBehaviour{

	/**
	 * Moves the game to the setup screen
	 * The lead player will use this screen to select which binders to use and add players
	 */
	public void setupGame(){

		// Tell each GUI to go to the NewGame Scene
		 loadScene (Scene.NewGame);

		/**
		 * The reset of this function will preset each preference to some initial values for the user
		 * These values should correspond to the last preferences played by this player
		 * Strech goal: Let the user load/save profiles
		 */

		Debug.Log ("Setting up game...");

		// Hardcode test XML database
		addBinderFromXML ("sample");
		addBinderFromXML ("smashBros");
		addBinderFromXML ("TimeComplexity");
		addBinderFromXML ("doesWeebStuffWorkOnHere");
		addBinderFromXML ("sample"); // This deck is ignored lol

		// add a dummy player
		addPlayer ("P1");
	
		// define deck generation preferences
		myDataBase.setMaxNumberOfCards (5);

		// The DisplayAgent should call startGame() when the player hits the Start Game button
		Debug.Log ("SG");
	}

	/**
	 * The DisplayAgent calls this function to initialize the game and start the round
	 */
	public void startGame(){
		// generate deck
		myDeck = myDataBase.generateDeck ();
		
		// shuffle questions
		myDeck.shuffleDeck ();

		// Clear old results
		myResults = new List<Results> ();

		// Ask the first question
		startRound ();
	}

	/**
	 * Starts a round with the current settings
	 */
	public void startRound (){

		Debug.Log ("Start round called!");

		// Clear the past current results
		currentResults = new Results ();

		// Tells the GUIs to push the Question Card to the screen
		// The GUIs will operate asyncrounously and return before the player see the question because of how loadScene() operates
		askQuestion ();

		// Once a player answers the question, the DisplayAgent will call playerAnswer() to return the results
	}

	/**
	 * DisplayAgent will call this function to pass the player's answer to the core. Once all the players have answered, the Core will call grade()
	 */
	public void playerAnswer(int playerID, Answer playerAnswer){
		// Store player's answer
		if (players.Count > playerID)
			players [playerID].lastAnswer = playerAnswer;
		else
			DebugPlayerIndex (playerID);



		// Move on if all players have answered
		if (playersLeftToAnswer () == 0)
			// Grade all players
			gradeAllPlayers ();
	}

	/**
	 * The Core calls this function to grade all the players' answers to the last question
	 * It returns a Results object containing the original question, each players' answer and their correctness
	 * When grading has completed, it will push the results to the GUIs
	 */
	public void gradeAllPlayers(){
		// Clear old result data
		currentResults = new Results ();

		// Grade all answers to the current question
		currentResults.originalQuestion = currentCard;
		foreach (Player i in players) {
			Debug.Log ("a");

			Debug.Log(i.ToString());
			Debug.Log(currentResults.ToString());
			grade (currentResults, i);
		}

		// Show the results
		viewPlayerResults ();
	}

	/**
	 * The Core calls this function to display the results to the screne
	 */
	public void viewPlayerResults(){
		// Display the round's results on the screen
		displayQuestionResults (currentResults);

		// Flag that players are not ready to go to the next question
		makePlayersNotReady ();

		// As players hit the button to advance to the next scene, the DisplayAgent will call playerReady()
	}

	/**
	 * The DisplayAgent will call this function to signify that the player is ready to move onto the next question
	 * After all players are ready, the Core will call endRound()
	 */
	public void playerReady(int playerID){
	
		// Store player's answer
		if (players.Count > playerID)
			players [playerID].isReady = true;
		else
			DebugPlayerIndex (playerID);

		Debug.Log ("You tickled me!");

		// Move on if all players are ready
		if (playersNotReady() == 0)
			endRound ();
	}

	/**
	 * The Core calls this function to end the round
	 * This function will clean up all the temporary data from the round
	 * 		- currentResults
	 * This function will return by either calling startRound() or endGame()
	 */
	void endRound(){

		Debug.Log ("We got here!");

		// Store this round's results
		myResults.Add (currentResults);

		Debug.Log (myResults.Count + " is the size of the myResults");

		// If we are good to ask another question, start another round
		if (continueGame ())
			startRound ();

		// Else, end the game
		else
			endGame ();
	}
	
	/**
	 * The Core calls this function when the game is over
	 * It will display the final results to the player and ask it to go to the
	 * 		- The Title Screen (keep current settings)
	 * 		- The Setup Screen (keep current settings)
	 * 		- Start another round (regenerate the deck with the same settings)
	 */
	public void endGame (){
		displayFinalResults (myResults);

		// The DisplayAgent will decide which state to go to next based on user input
	}	
}