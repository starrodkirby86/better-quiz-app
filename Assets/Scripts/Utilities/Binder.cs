/**
 * Utility Class to hold a Binder of Cards. Each binder will correspond to an XML file
 */
using UnityEngine;
using System.Collections.Generic;

public class Binder {

	/**
	 * The absolute path to the XML file holding this binder of cards
	 */
	public string filename;

	/**
	 * The nickname for this binder
	 */
	public string nickname;

	/**
	 * The relative chance of pulling a card from this binder after it is compilled into a deck
	 * A weight of zero means to include no cards from this binder
	 */
	public int weight;

	/**
	 * An array of all the cards in this binder. The cards in the list can be of any question type (multiple choice, short answer, etc)
	 */
	public List<Card> myCards;

	/**
	 * Constructor for binder class with filename.
	 */
	public Binder(string name) {
		filename = name;
		myCards = new List<Card> ();
	}

	/**
	 * Add a card into the binder. This simply inserts a new card node into the list myCards.
	 */
	public void addCard(Card submission) {
		myCards.Add (submission);
	}

	/**
	 * Gets a card from the binder. The card is not removed from the binder.
	 * If the index number is out-of-range, it will draw a random card out instead.
	 * Alternatively, if the random flag is enabled, it'll draw a random card out instead.
	 */
	public Card getCard(int index, bool random) {
		if(index >= 0 && index < myCards.Count && (!random))
			return myCards[index];
		else
			return myCards[(Random.Range(0,myCards.Count-1))];
	}
}
