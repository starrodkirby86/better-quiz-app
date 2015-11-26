/**
 * The Core is the root class in the game. It is responsible for controlling the game flow as well as passing data between the different modules
 */

using UnityEngine;					// For MonoBehaviour
using System.Collections.Generic; 	// For Lists

[System.Serializable]
public partial class Core : MonoBehaviour {
	 
/*
 * References to Objects
 */
	
	public DataBase myDataBase;

	/**
	 * The first element is the LocalGUI
	 * All later elements are RemoteGUI's
	 */
	public List<GUI> myGUIs;

/*
 * Internal Variables
 */
	/**
	 * All players in this round.
	 * Populated in setupGame 
	 */
	public List<Player> players;

	/**
	 * Cards to be used for the round
	 * Populated in setupGame
	 */
	public Deck myDeck;

	/**
	 * Holds the results to every question that has been asked
	 */
	public List<Results> myResults;

	/**
	 * The card coresponding to the current question
	 * It is populated by startRound()
	 */
	public Card currentCard;

	/**
	 * The results of the current question
	 * It is populated by gradeAllPlayers()
	 * It is stored into myResults by endRound()
	 */
	public Results currentResults;

	/**
	 * Game preferences.
	 */
	public GamePreferences myPreferences;
}