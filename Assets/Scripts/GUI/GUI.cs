using System.Collections.Generic;

/**
 * The GUI is responsible for all user interaction. It displays everything to the user (duh!) as well as grabbing user input]
 */
public class GUI {

/*
 * Core Hooks
 */

	/**
	 * Instructs the GUI to go to and load the next question
	 */
	public void nextQuestion (Question nextQuestion){
		
	}

	/**
	 * Tells the GUI what the current question's results are and to display them on the screen
	 */
	public void questionResults (Results theResults){
		
	}

	/**
	 * Tells the GUI what the final results are and that it should display them on the screen. Each element in the array is for a different question
	 */
	public void finalResults (List<Results> theResults){
		
	}

	/** 
	 * Tells the GUI to load a scene
	 */
	public void setScene (Scene nextScene){
		
	}

}
