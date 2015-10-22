/**
 * A class for passing the user's answer to the question from the GUI to the Core
 */
public class Answer {
	/**
	 * The type of question being answered
	 * ex: MultipleChoice, ShortAnswer
	 */
	public QuestionType myQuestionType;

	/**
	 * The answer for a multiple choice question
	 * ex: a, b, c, d, e, ..., etc.
	 */
	public char multipleChoiceAnswer;

	/** 
	 * The answer for a short answer question
	 * ex: 5, 2, 7, Fresno
	 */
	public string textAnswer;
}
