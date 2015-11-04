using UnityEngine; // For Random
using System.Collections.Generic; // For lists
using System.Xml; // For XML

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
	public int addBinderFromXML(string filename){
		Binder newBinder = new Binder (filename); // Declare a new binder to be later added.
		
		TextAsset xmlFile = Resources.Load ("XML/" + filename) as TextAsset; // We'll see how this works for now :)
		XmlDocument questionDoc = new XmlDocument ();
		questionDoc.LoadXml (xmlFile.text);

		XmlNodeList questionNodes = questionDoc.DocumentElement.SelectNodes ("/Flipbook/Card");

		// For each question in the XML file...
		foreach (XmlNode card in questionNodes) {
			// Parse and assemble the question
			Card newCard = new Card(card.SelectSingleNode("Question").InnerText, card.SelectSingleNode ("Answer").InnerText);
			// Push the question into the binder
			newBinder.addCard (newCard);
		}

		// Now we here
		// Add the set to the collection and return its ID number
		loadedBinders.Add (newBinder); // Binders full of women
		return (loadedBinders.Count - 1);
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
		 * TODO:
		 * X - Random implementation first.
		 *   - Sorted implementation based on weights.
		 *   - ???
		 *   - PROFIT!
		 */

		/**
		 * Doing it randomly is kinky.
		 * We keep picking cards until the amount of cards in the drawPile
		 * is that of the numberOfCards in preferences.
		 * 
		 * In the future, this code will need to be refactored elsewhere
		 * depending on the user's preferences in sorting.
		 */

		Debug.Log ("Starting deck generation...");

		while (result.cardsLeft() != deckPreferences.numberOfCards) {
			/**
			 * Pick a random deck and get a random card from that deck
			 */
			Card newCard = loadedBinders[(Random.Range (0,loadedBinders.Count))].getCard (-1);

			/**
			 * Is that card not in the deck yet?
			 */
			if(!(result.cardMatch (newCard)))
				result.addCard (newCard); // Add it in! Else, nothing happens.

			Debug.Log (result.cardsLeft ());
		}

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
