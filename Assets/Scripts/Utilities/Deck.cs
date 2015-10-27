/** 
 * Utility Class used to hold all the cards for this game
 */
public class Deck {

	/**
	 * Function to add an array of binders into the deck
	 */
	public void addManyBinders(Binder[] newBinders){
		foreach (Binder b in newBinders) {
			addManyBinders (b);
		}
	}

	/**
	 * Function to add cards from a binder into the deck.
	 * New cards should go into the drawPile
	 */
	public void addBinder(Binder newBinder){

	}

	/**
	 * An array of cards that have yet to be drawn
	 */
	Card[] drawPile;

	/**
	 * An array of cards that have already been drawn
	 */
	Card[] discardPile;

	/**
	 * Function for the Core to draw a card
	 */
	Card drawCard(){

	}

	/**
	 * A function to shuffle the drawPile with the discardPile. Result will go into the drawPile. Call before the game starts
	 */
	public void shuffleDeck(){

	}
}
