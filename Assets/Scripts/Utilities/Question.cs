/** 
 * Utility Class used to pass question data between modules
 */
public class Question {
	/**
	 * Question Text
	 */
	string questionText;
	string correctAnswer;

	public Question(string text, string answer) {
		questionText = text;
		correctAnswer = answer;
	}

	// At the moment, this checks directly; eventually it'll let you have 1 character off
	// for every 4 characters beyond 1 in the answer to compensate for spelling errors
	public bool checkCorrectness(string submission) {
		if (submission == correctAnswer) {
			return true;
		} else {
			return false;
		}
	}

	public string getQuestion() {
		//Debug.Log ("XML is SeXML");
		//Debug.Log (questionText);
		return questionText;
	}

	public string getAnswer() {
		return correctAnswer;
	}
}
