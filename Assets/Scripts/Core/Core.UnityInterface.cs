/*
 * Unity Interface for the Core
 * This file contains all of the functions that interface with Unity
 */

using UnityEngine;					// For MonoBehaviour
using System.Collections.Generic; 	// For Lists

public partial class Core : MonoBehaviour{

	/**
	 * Preps the Core for executing
	 */
	void Awake(){
		// This is to keep the game core loaded for the other game scenes.
		DontDestroyOnLoad (transform.gameObject);

		// Initialize the Player List
		players = new List<Player>();

		// Initialize the DataBase object
		myDataBase = new DataBase ();

		// Initialize the GUI List
		myGUIs = new List<GUI> ();
		
		// Add the LocalGUI
		myGUIs.Add (new GUI ());
	}

	/**
	 * Executes when game starts
	 * This function will just go to the title screen when complete, but it is currently hard coded to go directly to the game setup
	 */
	void Start () {
		// Configure the game preferences
		setupGame ();

		// Start the game
		// TODO: This is hardcoded now, but should be called by DisplayAgent
		startGame ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

 /*
  * Debug Functions
  */
	
	/**
	 * This function displays an error when the player's index is out of range
	 */
	void DebugPlayerIndex(int playerID){
		Debug.Log ("Error: Player " + playerID.ToString() + " does not exist\nOnly "+players.Count.ToString()+" people are playing");
	}
}