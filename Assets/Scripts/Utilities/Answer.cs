/**
 * A class for passing the user's answer to the question from the GUI to the Core
 */
public class Answer {
	/**
	 * The type of question being answered
	 */
	public QuestionType myQuestionType;

	/**
	 * The answer for a multiple choice question
	 * a, b, c, d, e, ..., etc.
	 */
	public char multipleChoiceAnswer;

	/**
	 * The text of the multiple choice (optional)
	 */
	public char multipleChoiceAnswerText;

	/** 
	 * The answer for a short answer question
	 */
	public string shortAnswer;
}
