using UnityEngine;
using UnityEngine.UI; // this is only needed because of testing
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

	// Holds each question results in an element
	List<Results> myResults;

/*
 * DataBase Hooks
 */

	/**
	 * Instructs the database to parse the XML file given by filename and add it to its collection; returns the address of the new collection
	 */
	public int addXML(string filename){
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

	// I ripped out a lot of stuff here, I'll toss it back in later

	/**
	 * Preps the Core for executing
	 */
	void Awake(){
		myDataBase = new DataBase ();
		// Hardcode test XML database
		myDataBase.addXML ("sample");
	}

	void Start(){
		// This is happening because I slapped the core script onto a text object to see if it works
		Text display = gameObject.GetComponent<Text> ();
		display.text = myDataBase.activateSet (0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
