/** 
 * Utility Class used to pass question data between modules
 */
public class Question {
	/**
	 * The type of question being asked
	 */
	public QuestionType myQuestionType;

	/**
	 * Question Text
	 */
	public string QuestionText;

	/**
	 * Possible answers
	 * Could be multiple choice selections
	 * Could be short answer example response
	 */
	public Answer[] answers;

	public Answer correctAnswer;
}
