/**
 * Utility Class to hold a set of Questions. Each set will correspond to an XML file
 */
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Xml;

public class Set {

	string setName;
	int questionIterator;
	List<Question> myQuestions;

	public Set(string name) {
		setName = name;
		myQuestions = new List<Question> ();
	}

	public void pushQuestion(Question submission) {
		myQuestions.Add (submission);
	}

	// Prepares a set to be used and returns the text of the first question
	public string activateSet() {
		questionIterator = 0;
		// You never know what some people will get up to
		if (questionIterator >= myQuestions.Count) {
			return "EXIT"; //  Sentinel value; probably a better way of checking for this
		} else {
			return myQuestions [questionIterator].getQuestion ();
		}
	}

	// Pushes the question forward one and returns the text of the next question
	public string nextQuestion() {
		questionIterator += 1;
		if (questionIterator >= myQuestions.Count) {
			return "EXIT"; //  Sentinel value; probably a better way of checking for this
		} else {
			return myQuestions [questionIterator].getQuestion ();
		}
	}

	// Checks whether the given answer is correct
	public bool checkAnswer(string submission) {
		return myQuestions [questionIterator].checkCorrectness (submission);
	}

	// Returns the text of the correct answer
	public string getRightAnswer() {
		return myQuestions [questionIterator].getAnswer ();
	}
}
