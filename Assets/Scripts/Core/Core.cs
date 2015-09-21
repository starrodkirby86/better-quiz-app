using UnityEngine;
using System.Collections;

/**
 * The Core is the root class in the game. It is responsible for controlling the game flow as well as passing data between the different modules
 */
public class Core : MonoBehaviour {

/*
 * DataBase Hooks
 */

	/**
	 * Instructs the database to parse the XML file given by filename and add it to the collection
	 */
	public Set addXML(string filename){
		return new Set ();
	}

	/**
	 * Returns an array containing all loaded question sets
	 */
	public Set[] getAllSets(){
		return new Set[0];
	}

	/** 
	 * Returns an array containing all questions from the parent set
	 */
	public Question[] getAllQuestions (Set parent){
		return new Question[0];
	}

	/**
	 * Adds a question to a set
	 */
	public void addQuestion (Set parent, Question child){

	}

	/**
	 * Deletes a question from a set
	 */
	public void deleteQuestion (Set parent, Question child){

	}

/*
 * Game Initialization Hooks
 */

	/**
	 * Moves the game to the setup screen
	 */
	public void setupGame(){
		
	}

	/**
	 * Adds a player to the game
	 */
	public Player addPlayer (string name){
		return new Player(name);
	}

	/**
	 * Use a set for this round
	 */
	public void useSet (Set mySet){
		
	}

	/**
	 * No longer use a set for this round
	 */
	public void disUseSet(Set mySet){
		
	}

	/**
	 * Starts a round with the current settings
	 */
	public void startGame (){
		
	}

/**
 * Main Loop Hooks
 */

	/** 
	 * Records a player's answer for the current question
	 */
	public void answerQuestion (Player myPlayer, Answer myAnswer){
		
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
	 * References to Objects
	 */

	public DataBase db;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
