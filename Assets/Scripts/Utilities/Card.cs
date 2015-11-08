/** 
 * Utility Class used to pass question data between modules
 */

[System.Serializable]
public class Card {
	/**
	 * The type of question being asked
	 * ex: MultipleChoice, ShortAnswer
	 */
	public QuestionType myQuestionType;

	/**
	 * Question Text
	 * This text is parsed from the XML file and is displayed to the user when the question is asked
	 * ex: How many roots does x^2-x-2 have?
	 */
	public string questionText;

	/**
	 * Possible answers
	 * Could be multiple choice selections
	 * Could be short answer example response
	 * ex: Two Imaginary, One Real, Two Real
	 */
	public Answer[] answers;

	/**
	 * The correct answer to the question.
	 * ex: For multiple choice, it would contain the correct choice and answer text
	 * ex: For short answer, it would contain a model answer to the question
	 */
	public Answer correctAnswer;

	/**
	 * True if this card should be placed into the deck
	 */
	public bool includeCard;

	/**
	 * Constructor for a new card (For only supporting text/answer so far
	 */
	public Card(string text, string answer) {
		questionText = text;
		correctAnswer = new Answer(answer);
	}

	/**
	 * Game logic functions
	 * Brought to you by Johnson & Johnson, a family company (thanks colin!)
	 */

	/** Check if solution is correct
	 *  TODO: Add spell error leniency (1 char off for every 4char beyond 1?)
	 *  TODO: More versatile functionality
	 */
	public bool checkCorrectness(string submission) {
		return (submission == correctAnswer.textAnswer);
	}
	
	public string getQuestion() {
		//Debug.Log ("XML is SeXML");
		//Debug.Log (questionText);
		return questionText;
	}
	
	public string getAnswer() {
		// For now, return the textual answer
		// But we need to encompass other answer types too.
		return correctAnswer.textAnswer;
	}
}
