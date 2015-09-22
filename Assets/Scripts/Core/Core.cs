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
	// All players in the round
	List<Player> players = new List<Player>();

	// Sets to be used for the round
	List<Set> mySets;

	// Generated from mySets at round launch
	List<Question> myQuestions;

/*
 * DataBase Hooks
 */

	/**
	 * Instructs the database to parse the XML file given by filename and add it to the collection
	 */
	public Set addXML(string filename){
		return myDataBase.addXML (filename);
	}

	/**
	 * Returns an array containing all loaded question sets
	 */
	public Set[] getAllSets(){
		return myDataBase.getAllSets();
	}

	/** 
	 * Returns an array containing all questions from the parent set
	 */
	public Question[] getAllQuestions (Set parent){
		return myDataBase.getAllQuestions(parent);
	}

	/**
	 * Adds a question to a set
	 */
	public void addQuestion (Set parent, Question child){
		myDataBase.addQuestion (parent, child);
	}

	/**
	 * Deletes a question from a set
	 */
	public void deleteQuestion (Set parent, Question child){
		myDataBase.deleteQuestion (parent, child);
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
		
		// load sets
		Set[] tempSet = getAllSets ();
		
		//clear sets from last round
		mySets=new List<Set>();
		
		// use all sets
		foreach (Set i in tempSet) {
			useSet(i);
		}
		
		// Make a list of possible questions to ask from mySets
		myQuestions = new List<Question> ();
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
	public void useSet (Set mySet){
		mySets.Add (mySet);
	}

	/**
	 * No longer use a set for this round
	 */
	public void disUseSet(Set mySet){
		mySets.Remove (mySet);
	}

	/**
	 * Starts a round with the current settings
	 */
	public IEnumerator startGame (){
		// Shuffle questions before asking
		shuffle (myQuestions);

		// Keep asking questions until continueGame conditions are no longer met
		while (continueGame()) {
			askQuestion();
		}

		// Wait for all players to answer
		while(playersLeftToAnswer()>0){
			yield return new WaitForSeconds(0.1f);
		}

		// TODO Left off here
	}

/**
 * Main Loop Hooks
 */

	/** 
	 * Records a player's answer for the current question
	 */
	public void answerQuestion (Player myPlayer, Answer myAnswer){
		// TODO Left off here
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
		// TODO Make a real check
		return true;
	}

	/**
	 * Steps to ask a question
	 */
	void askQuestion(){
		// TODO Left off here
		foreach (Player i in players)
			i.lastAnswer = null;
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
