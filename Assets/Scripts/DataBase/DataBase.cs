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
        /*
         * This function does several things: first, it computes the sum of all the binder weights.
         * Second, it randomly selects a binder based on its weight.
         * Third, it randomly selects a card in the randomly selected binder.
         * FINALLY, it adds the randomly chosen card into the deck for play.
         * Some time later down the road, this function may need to be refactored, but for now, it appears to be working.
         */

        int sum = 0;

		/*
		 * Apply the 
		 */
		for (int i = 0; i < loadedBinders.Count; i++)
			sum += loadedBinders[i].weight;
		
		if (sum < 0)
			Debug.Log ("Cannot have a weight below 0! You suck. Nothing happens.");
		else {
			while (result.cardsLeft() < deckPreferences.numberOfCards) {
				int randomCard = Random.Range (0, sum);
				int i = 0;
				while (randomCard > loadedBinders[i].weight) {
					randomCard -= loadedBinders [i].weight;
					i++;
				}
				Card newCard = loadedBinders [i].getCard (-1);

				if (!(result.cardMatch (newCard)))
					result.addCard (newCard);

			}
			result.shuffleDeck ();
		}
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
