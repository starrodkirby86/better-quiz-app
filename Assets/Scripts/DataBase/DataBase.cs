/**
 * The DataBase stores all questions and sets into XML files as well as parsing XML files into classes
 */
public class DataBase : MonoBehaviour {

/*
 * Core Hooks
 */

	/**
	 * Instructs the database to parse the XML file given by filename and add it to the collection
	 */
	public Set addXML(string filename){
		return new Set ();
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
	
	/**
	 * Adds a question to a set
	 */
	public void addQuestion (Set parent, Question child){
		
	}
	
	/**
	 * Deletes a question from a set
	 */
	public void deleteQuestion (Set parent, Question child){
		
	}

/*
 * References to Objects
 */

	public Core core;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
