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
	public GUI[] myGUIs;

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

/*
 * DataBase Hooks
 */

	/**
	 * Instructs the database to parse the XML file given by filename and add it to the collection
	 */
	public Binder addXML(string filename){
		return myDataBase.addXML (filename);
	}

	/**
	 * Returns an array containing all loaded binders
	 */
	public Binder[] getAllBinders(){
		return myDataBase.getAllBinders();
	}

	/** 
	 * Returns an array containing all question cards from the parent bidner
	 */
	public Card[] getAllCards (Binder parent){
		return myDataBase.getAllCards(parent);
	}

	/**
	 * Adds a question to a binder
	 */
	public void addCard (Binder parent, Card child){
		myDataBase.addCard(parent, child);
	}

	/**
	 * Deletes a question from a binder
	 */
	public void deleteCard (Binder parent, Card child){
		myDataBase.deleteCard (parent, child);
	}

/*
 * Game Initialization Hooks
 */

	/**
	 * Moves the game to the setup screen
	 */
	public void setupGame(){
		
		// add a dummy player
		addPlayer ("P1");
		
		// load sets from database
		Binder[] allBinders = getAllBinders();
		
		// initialize deck
		myDeck.addManyBinders(allBinders);
		
		// use all sets
		foreach (Binder i in allBinders) {
			useBinder(i);
		}
		
		// Make a list of possible questions to ask from mySets
		myCards = new List<Question> ();
		foreach (Set i in mySets) foreach (Question j in i.myQuestions) {
			myQuestions.Add(j);
		}

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
	 * Use a set for this round
	 */
	public void useBinder (Binder myBinder){
		myBinders.add (myBinder);
	}

	/**
	 * No longer use a set for this round
	 */
	public void disUseBidner(Binder myBinders){
		myBinders.remove (myBinder);
	}

	/**
	 * Starts a round with the current settings
	 */
	public IEnumerator startGame (){

		// Clear old results
		myResults = new List<Results> ();

		// Shuffle questions before asking
		shuffle (myQuestions);

		// Keep asking questions until continueGame conditions are no longer met
		while (continueGame()) {
			askQuestion ();
		

			// Wait for all players to answer
			while (playersLeftToAnswer()>0) {
				yield return new WaitForSeconds (0.1f);
			}

			// Grade all answers to the current question
			Results tempResults = new Results ();
			tempResults.originalQuestion = myQuestions [0];
			foreach (Player i in players) {
				grade (tempResults, i);
			}
			myResults.Add (tempResults);

			// Push the results to the GUI to display
			foreach(Player i in players)
				i.isReady=false;

			foreach(GUI i in myGUIs)
				i.displayQuestionResults(tempResults);

			// Wait for all players to be ready
			while (playersNotReady()>0) {
				yield return new WaitForSeconds (0.1f);
			}

			// Delete current question from question lists
			myQuestions.Remove (myQuestions [0]);
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
	public void playerReady (Player myPlayer){
		
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
		return myQuestions.Count>0;
	}

	/**
	 * Steps to ask a question
	 */
	void askQuestion(){
		// Clear old answers
		foreach (Player i in players)
			i.lastAnswer = null;

		// Push new question to all screens
		foreach(GUI i in myGUIs)
			i.nextQuestion (myQuestions [0]);
	}

	/**
	 * Randomizes a list
	 */
	void shuffle<T>(List<T> myList){
		for (int i = 0; i < myList.Count; i++) {
			T temp = myList[i];
			int randomIndex = Random.Range(i, myList.Count);
			myList[i] = myList[randomIndex];
			myList[randomIndex] = temp;
		}	}

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

		// Hardcode test XML database
		addXML ("test.xml");
	}

	/**
	 * Executes when game starts
	 */
	void Start () {
		// moves from the title screen to the setup round screen // after 5 seconds
		// yield return new WaitForSeconds (5);
		setupGame ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
