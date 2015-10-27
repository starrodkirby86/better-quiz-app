/**
 * Utility Class to hold a Binder of Cards. Each binder will correspond to an XML file
 */

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
	 * An array of all the cards in this binder. The cards in the array can be of any question type (multiple choice, short answer, etc)
	 */
	public Card[] myCards;

}
