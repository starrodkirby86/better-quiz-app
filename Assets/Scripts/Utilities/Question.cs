/** 
 * Utility Class used to pass question data between modules
 */
public class Question {
	/**
	 * The type of question being asked
	 */
	QuestionType myQuestionType;

	/**
	 * Question Text
	 */
	string QuestionText;

	/**
	 * Possible answers
	 * Could be multiple choice selections
	 * Could be short answer example response
	 */
	Answer[] answers;
}
