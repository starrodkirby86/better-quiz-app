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
			if(i.lastAnswer!=null) result++;
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
		return result;
	}
	
	/**
	 * Grades the player's answer and stores the result
	 */
	void grade(Results myResults, Player myPlayer){
		// Add player
		myResults.players.Add (myPlayer);
		
		// Add player's answer
		myResults.playerAnswers.Add (myPlayer.lastAnswer);
		
		// Grade answer
		switch (myPlayer.lastAnswer.myQuestionType) {
			// Compare multiple choice answers
		case QuestionType.MultipleChoice:
			myResults.isCorrect.Add(myPlayer.lastAnswer.multipleChoiceAnswer == myResults.originalQuestion.correctAnswer.multipleChoiceAnswer);
			break;
			
		default:myResults.isCorrect.Add(false);
			break;
			
		}
	}
}