using System.Collections.Generic;

/**
 * The GUI is responsible for all user interaction. It displays everything to the user (duh!) as well as grabbing user input]
 */
public class GUI {
/*
 * Core Hooks
 */

	/**
	 * Instructs the GUI to go to and load the next question.
	 * The GUI will load the scene, and ask the question.
	 * After the player has answered the question, the GUI will report the answer back to the Core.
	 * The next GUI task will occur when all the players have answered the question. The Core will then calculate the results and call displayQuestionResults
	 */
	public void nextQuestion (Card nextQuestion){
		
	}

	/**
	 * Tells the GUI what the current question's results are and to display them on the screen.
	 * The results will contain each player's question, answer, and correctness of the answer.
	 * The GUI will first display each player's answer along with the correct answer.
	 * A dramatic pause between the player's answer and correct answer can be added.
	 * The GUI should signify which questions are correct and which ones aren't.
	 * 
	 * The GUI should then enable a button to let the player continue to the next question.
	 * When the button is pressed, the GUI will report to the Core.
	 * Once all players are ready to move on, the Core will call nextQuestion for the GUI to ask the next question.
	 * If there are no more questions, the Core will call displayFinalResults instead
	 */
	public void displayQuestionResults (Results theResults){
		
	}

	/**
	 * Tells the GUI what the final results are and that it should display them on the screen. Each element in the array is for a different question.
	 * The GUI should show each player's score compared to the competitors and rank them.
	 * There should also be an option for the player to review all of it's questions and answers
	 */
	public void displayFinalResults (List<Results> theResults){
		
	}

	/** 
	 * Tells the GUI to load a scene
	 * ex: Title, AskQuestion, GameOver
	 */
	public void loadScene (Scene nextScene){
		
	}

}
