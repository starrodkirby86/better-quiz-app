/**
 * Utility Class to hold a set of Questions. Each set will correspond to an XML file
 */

public class Set {

	// The path to the XML file holding this set of question
	public string filename;

	// An array of all the question in this set. The questions in the array can be of any superclass (multiple choice, short answer, etc)
	public Question[] myQuestions;

}
