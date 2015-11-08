/*
 * GUI Interface for the Core
 * This file contains all of the functions that interface with the GUI
 */

using UnityEngine;					// For MonoBehaviour
using System.Collections.Generic; 	// For Lists

public partial class Core : MonoBehaviour{

	/**
	 * Steps to ask a question
	 */
	void askQuestion(){

		Debug.Log ("Asking...");

		// Clear old answers
		foreach (Player i in players)
			i.lastAnswer = null;

		// Push new question to all screens
		currentCard=myDeck.drawCard();

		foreach(GUI i in myGUIs)
			i.nextQuestion (currentCard);
	}

	/**
	 * Display the round's results on each GUI
	 */
	void displayQuestionResults(Results roundResults){
		foreach (GUI i in myGUIs)
			i.displayQuestionResults (roundResults);
	}

	/**
	 * Display the final results on each GUI
	 */
	void displayFinalResults(List<Results> finalResults){
		foreach (GUI i in myGUIs)
			i.displayFinalResults (finalResults);
	}

	/**
	 * Loads the scene on each GUI
	 */
	void loadScene(Scene targetScene){
		foreach (GUI i in myGUIs)
			i.loadScene (Scene.NewGame);
	}
}