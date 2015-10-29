/**
 * The DataBase stores all cards and binders into XML files as well as parsing XML files into classes
 */
public class DataBase {

/*
 * Core Hooks
 */

	/**
	 * Instructs the database to parse the XML file given by filename and add it to the collection
	 */
	public Binder addBinderFromXML(string filename){
		return new Binder ();
	}
	
	/**
	 * Returns an array containing all loaded question sets.
	 * Each question set contains questions
	 */
	public Binder[] getAllBinders(){
		return new Binder[0];
	}
	
	/** 
	 * Returns an array containing all questions from the parent set
	 */
	public Card[] getAllCards (Binder parent){
		return new Card[0];
	}
	
	/**
	 * Adds a question card to a binder
	 */
	public void addCard (Binder parent, Card child){
		
	}
	
	/**
	 * Deletes a question from a set
	 */
	public void deleteCard (Binder parent, Card child){
		
	}

	/**
	 * Saves out all binders to disk
	 * returns: true if the write was successful
	 * 			false if the write failled
	 */
	public bool save(){
		return true; // Pretend everything saved
	}
}
