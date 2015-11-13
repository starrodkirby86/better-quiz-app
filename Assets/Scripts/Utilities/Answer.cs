/**
 * A class for passing the user's answer to the question from the GUI to the Core
 */

[System.Serializable]
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
	const char defaultmultipleChoiceAnswer = '-';
	public char multipleChoiceAnswer = defaultmultipleChoiceAnswer;

	/** 
	 * The answer for a short answer question
	 * ex: 5, 2, 7, Fresno
	 */
	const string defaultTextAnswer = "-";
	public string textAnswer = defaultTextAnswer;

	public Answer(string inputAnswer){
		textAnswer = inputAnswer;
	}

	/**
	 * Returns true iff this question has an anwer for one of it's fields
	 */
	public bool isAnswered(){
		return(
			// the question is answered if the multiple choice answer changed or
			(multipleChoiceAnswer!=defaultmultipleChoiceAnswer)||

			// if the short answer changed
			(textAnswer!=defaultTextAnswer)
		);

	}
}
