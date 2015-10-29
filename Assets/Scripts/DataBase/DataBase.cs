using UnityEngine; // For Random
using System.Collections.Generic; // For lists

/**
 * The DataBase stores all cards and binders into XML files as well as parsing XML files into classes
 * It also generates a deck based on user preferences
 */
public class DataBase {

/*
 * Core Hooks
 */

	/**
	 * Instructs the database to parse the XML file given by filename and add it to the collection
	 */
	public void addBinderFromXML(string filename){

	}

	/**
	 * Saves out all binders to disk
	 * returns: true if the write was successful
	 * 			false if the write failled
	 */
	public bool saveBinders(){
		return true; // Pretend everything saved
	}

/**
 * Functions to configure the deck generation
 */
	/**
	 * Compile the deck
	 */
	public Deck generateDeck(){
		Deck result = new Deck ();

		/**
		 * Generate the deck here
		 */

		result.shuffleDeck ();
		return result;
	}

	/**
	 * Set the maximum number of cards to put in the deck
	 */
	public void setMaxNumberOfCards(int max){
		deckPreferences.numberOfCards = max;
	}

/**
 * Functions to modify the binders
 */
	/**
	 * Read the binders
	 */
	public Binder[] viewBinders(){
		return loadedBinders.ToArray ();
	}

/**
 * Internal Variabes
 */
	List<Binder> loadedBinders = new List<Binder> ();
	GenerationPreferences deckPreferences = new GenerationPreferences();

}
