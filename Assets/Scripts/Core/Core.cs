using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/**
 * The Core is the root class in the game. It is responsible for controlling the game flow as well as passing data between the different modules
 */
public class Core : MonoBehaviour {

/*
 * References to Objects
 */
	
	public DataBase myDataBase;
	public List<GUI> myGUIs;

/*
 * Internal Variables
 */
	/**
	 * All players in this round.
	 * Populated in setupGame
	 */
	List<Player> players = new List<Player>();

	/**
	 * Cards to be used for the round
	 * Populated in setupGame
	 */
	Deck myDeck;

	/**
	 * Holds the results to every question that has been asked
	 */
	List<Results> myResults;

	/**
	 * The card coresponding to the current question
	 */
	Card currentCard;

/*
 * DataBase Hooks
 */

	/**
	 * Instructs the database to parse the XML file given by filename and add it to the collection
	 */
	public void addBinderFromXML(string filename){
		myDataBase.addBinderFromXML (filename);
	}

	/**
	 * Returns an array containing all loaded binders
	 */
	public Binder[] getAllBinders(){
		return myDataBase.viewBinders();
	}

/*
 * Game Initialization Hooks
 */

	/**
	 * Moves the game to the setup screen
	 * The lead player will use this screen to select which binders to use and add players
	 */
	public void setupGame(){

		// This function doesn't work yet, but it should move the GUI to the setup scene
		foreach(GUI i in myGUIs)
			i.loadScene(Scene.NewGame);

		/**
		 * Currently the setupGame phase is a hard debug function. But this should be
		 * a scene switch or something for preferences.
		 */

		// Hardcode test XML database
		addBinderFromXML ("sample.xml");
		addBinderFromXML ("smashBros.xml");
		addBinderFromXML ("TimeComplexity.xml");

		// add a dummy player
		addPlayer ("P1");
	
		// define deck generation preferences
		myDataBase.setMaxNumberOfCards (5);
		
		// generate deck
		myDeck = myDataBase.generateDeck ();

		// start the game. This should be called by the GUI
		startGame ();
	}

	/**
	 * Adds a player to the game
	 */
	public Player addPlayer (string name){
		Player tempPlayer = new Player (name);
		players.Add (tempPlayer);
		return tempPlayer;
	}

	/**
	 * Starts a round with the current settings
	 */
	public IEnumerator startGame (){

		// Clear old results
		myResults = new List<Results> ();

		// Shuffle questions before asking
		myDeck.shuffleDeck ();

		// Keep asking questions until continueGame conditions are no longer met
		while (continueGame()) {
			askQuestion ();
		

			// Wait for all players to answer
			while (playersLeftToAnswer()>0) {
				yield return new WaitForSeconds (0.1f);
			}

			// Grade all answers to the current question
			Results tempResults = new Results ();
			tempResults.originalQuestion = currentCard;
			foreach (Player i in players) {
				grade (tempResults, i);
			}
			myResults.Add (tempResults);

			
			// Push the results to the GUI to display
			foreach(GUI i in myGUIs)
				i.displayQuestionResults(tempResults);
			
			// flag that players are not ready to go to the next scene
			foreach(Player i in players)
				i.isReady=false;

			// Wait for all players to be ready
			while (playersNotReady()>0) {
				yield return new WaitForSeconds (0.1f);
			}
		}

		// The round is now over
		// Push final resutls to GUI
		foreach (GUI i in myGUIs)
			i.displayFinalResults (myResults);
	}

/**
 * Main Loop Hooks
 */

	/** 
	 * Records a player's answer for the current question
	 */
	public void answerQuestion (Player myPlayer, Answer myAnswer){
		myPlayer.lastAnswer = myAnswer;
	}

	/** 
	 * Tells the Core that the player is ready to start the next question
	 */
	public void playerReady (int playerID){
		foreach (Player i in players)
			if(i.playerID==playerID) 
				i.isReady=true;
	}

	/**
	 * Ends the game and returns to the title screen
	 */
	public void endGame (){
		
	}

/*
 * Subroutines
 */

	/**
	 * Retruns true iff we can ask another question
	 */
	bool continueGame(){
		// See if we have any questions left in the list
		// Later add option for timed countdown
		return myDeck.cardsLeft()>0;
	}

	/**
	 * Steps to ask a question
	 */
	void askQuestion(){
		// Clear old answers
		foreach (Player i in players)
			i.lastAnswer = null;

		// Push new question to all screens
		currentCard=myDeck.drawCard();
		foreach(GUI i in myGUIs)
			i.nextQuestion (currentCard);
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

	/**
	 * Preps the Core for executing
	 */
	void Awake(){

	}

	/**
	 * Executes when game starts
	 */
	void Start () {
		// moves from the title screen to the setup round screen
		setupGame ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
