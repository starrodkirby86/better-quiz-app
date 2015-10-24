/**
 * The DataBase stores all questions and sets into XML files as well as parsing XML files into classes
 */

using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Xml;

public class DataBase {

	public List<Set> setCollection;
/*
 * Core Hooks
 */

	/**
	 * Instructs the database to parse the XML file given by filename and add it to the collection
	 */
	public int addXML(string filename){
		setCollection = new List<Set> ();
		Set newSet = new Set(filename);

		// Not sure if this'll work in the final version, but it should for now
		TextAsset xmlFile = Resources.Load("XML/sample") as TextAsset;
		XmlDocument questionDoc = new XmlDocument ();
		questionDoc.LoadXml (xmlFile.text);

		XmlNodeList questionNodes = questionDoc.DocumentElement.SelectNodes ("/Flipbook/Card");
		
		// For each question in the XML file;
		foreach (XmlNode card in questionNodes) {
			// Parse and assemble the question
			Question newQuestion = new Question(card.SelectSingleNode ("Question").InnerText, card.SelectSingleNode ("Answer").InnerText);
			// Push the question into the set
			newSet.pushQuestion (newQuestion);
		}

		// Once finished, add the set to the collection and return its ID number
		setCollection.Add(newSet);
		return setCollection.Count - 1;
	}

	// Activates the set associated with the given ID
	public string activateSet(int id) {
		return setCollection [id].activateSet ();
	}
	
	/**
	 * Returns an array containing all loaded question sets
	 */
	public Set[] getAllSets(){
		return new Set[0];
	}
	
	/** 
	 * Returns an array containing all questions from the parent set
	 */
	public Question[] getAllQuestions (Set parent){
		return new Question[0];
	}

}
