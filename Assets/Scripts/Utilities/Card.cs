/** 
 * Utility Class used to pass question data between modules
 */
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
	public string QuestionText;

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
}
