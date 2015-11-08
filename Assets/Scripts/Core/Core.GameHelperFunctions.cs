/*
 * Game Logic Helper Functions for the Core
 * This file contains all of the helper functions for the Game Control
 */

using UnityEngine;					// For MonoBehaviour
using System.Collections.Generic; 	// For Lists

public partial class Core : MonoBehaviour{
	/**
	 * Adds a player to the game
	 */
	public Player addPlayer (string name){
		Player tempPlayer = new Player (name);
		players.Add (tempPlayer);
		return tempPlayer;
	}

	/**
	 * Retruns true iff we can ask another question
	 */
	bool continueGame(){
		// See if we have any questions left in the list
		// Later add option for timed countdown
		return myDeck.cardsLeft()>0;
	}

	/**
	 * Flag each player as not ready to go to the next question
	 */
	void makePlayersNotReady(){
		foreach (Player i in players)
			i.isReady = false;
	}
	
	/**
	 * Returns how many players have not answered
	 */
	int playersLeftToAnswer(){
		int result=0;
		foreach (Player i in players) {
			if(i.lastAnswer==null) result++;
		}
		return result;
	}
	
	/**
	 * Returns how many players are not ready to move on
	 */
	int playersNotReady(){
		int result=0;
		foreach (Player i in players) {
			if(!i.isReady) result++;
		}
		Debug.Log (result);
		return result;
	}
	
	/**
	 * Grades the player's answer and stores the result
	 */
	void grade(Results myResults, Player myPlayer){
		Debug.Log ("At grade");
		Debug.Log (myResults.players.Count);
		// Add player
		myResults.players.Add (myPlayer);

		Debug.Log (myResults.players.Count);

		if (myPlayer == null)
			Debug.Log ("Don't show me... >_<");

		// Add player's answer
		myResults.playerAnswers.Add (myPlayer.lastAnswer);

		Debug.Log ("Yatta!");

		Debug.Log ("You picked " + myResults.playerAnswers[0].textAnswer + " which is an awful answer.");

		Debug.Log (myResults.playerAnswers.Count + "WOW!");


		// Grade answer
		// The answers should be case insensitive
		switch (myPlayer.lastAnswer.myQuestionType) {
			// Compare multiple choice answers
		case QuestionType.MultipleChoice:
			myResults.isCorrect.Add(myPlayer.lastAnswer.multipleChoiceAnswer.ToString().ToUpper() == myResults.originalQuestion.correctAnswer.multipleChoiceAnswer.ToString().ToUpper());
			break;
		case QuestionType.ShortAnswer:
			myResults.isCorrect.Add (myPlayer.lastAnswer.textAnswer.ToUpper() == myResults.originalQuestion.correctAnswer.textAnswer.ToUpper());
			break;
		default:
			myResults.isCorrect.Add(false);
			break;
			
		}
	}
}