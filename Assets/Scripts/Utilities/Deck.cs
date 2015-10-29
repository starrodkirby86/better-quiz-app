using UnityEngine; // For Random
using System.Collections.Generic; // For lists

/** 
 * Utility Class used to hold all the cards for this game
 */
public class Deck {
	
	/**
	 * An array of cards that have yet to be drawn
	 */
	List<Card> drawPile = new List<Card>();
	
	/**
	 * An array of cards that have already been drawn
	 */
	List<Card> discardPile = new List<Card>();


	/**
	 * Function to add an array of binders into the deck
	 */
	public void addManyBinders(Binder[] newBinders){
		foreach (Binder b in newBinders) {
			addBinder(b);
		}
	}

	/**
	 * Function to add cards from a binder into the deck.
	 * New cards should go into the drawPile
	 */
	public void addBinder(Binder newBinder){
		foreach (Card i in newBinder.myCards) {
			drawPile.Add(i);
		}
	}

	/**
	 * Function to remove every card in binder from the deck
	 */
	public void removeBinder(Binder myBinder){
		foreach (Card i in myBinder.myCards) {
			drawPile.Remove(i);
			discardPile.Remove(i);
		}
	}

	/**
	 * Function for the Core to draw a card	
	 */
	public Card drawCard(){
		Card result = drawPile [0];
		drawPile.Remove(result);
		discardPile.Add(result);
		return result;
	}

	/**
	 * Function to return the number of cards left
	 */
	public int cardsLeft(){
		return drawPile.Count;
	}

	/**
	 * A function to shuffle the drawPile with the discardPile. Result will go into the drawPile. Call before the game starts
	 */
	public void shuffleDeck(){

		// Combine drawPile with discardPile and store in drawPile
		foreach (Card i in discardPile) {
			drawPile.Add (i);
			discardPile.Remove (i);
		}

		// Shuffles the drawPile
		for (int i = 0; i < drawPile.Count; i++) {
			Card temp = drawPile [i];
			int randomIndex = Random.Range (i, drawPile.Count);
			drawPile [i] = drawPile [randomIndex];
			drawPile [randomIndex] = temp;
		}
	}
}
