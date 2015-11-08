using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/**
 * The Core is the root class in the game. It is responsible for controlling the game flow as well as passing data between the different modules
 */
public class Core : MonoBehaviour {

/*
 * References to Objects
 */
	
	public DataBase myDataBase;
	public List<GUI> myGUIs;

/*
 * Internal Variables
 */
	/**
	 * All players in this round.
	 * Populated in setupGame
	 */
	List<Player> players = new List<Player>();

	/**
	 * Cards to be used for the round
	 * Populated in setupGame
	 */
	Deck myDeck;

	/**
	 * Holds the results to every question that has been asked
	 */
	List<Results> myResults;

	/**
	 * The card coresponding to the current question
	 * It is populated by startRound()
	 */
	Card currentCard;

	/**
	 * The results of the current question
	 * It is populated by gradeAllPlayers()
	 * It is stored into myResults by endRound()
	 */
	Results currentResults;

/*
 * DataBase Hooks
 */

	/**
	 * Instructs the database to parse the XML file given by filename and add it to the collection
	 */
	public void addBinderFromXML(string filename){
		myDataBase.addBinderFromXML (filename);
	}

	/**
	 * Returns an array containing all loaded binders
	 */
	public Binder[] getAllBinders(){
		return myDataBase.viewBinders();
	}

/*
 * Game Initialization Hooks
 */

	/**
	 * Moves the game to the setup screen
	 * The lead player will use this screen to select which binders to use and add players
	 */
	public void setupGame(){

		/**
		// This function doesn't work yet, but it should move the GUI to the setup scene
		foreach(GUI i in myGUIs)
			i.loadScene(Scene.NewGame);
		*/

		/**
		 * Currently the setupGame phase is a hard debug function. But this should be
		 * a scene switch or something for preferences.
		 */

		/*
		 * I think we need to initialize a database and GUI or something.
		 */
		myDataBase = new DataBase ();
		myGUIs = new List<GUI> ();
		myGUIs.Add (new GUI ());

		Debug.Log ("Setting up game...");

		// Hardcode test XML database
		addBinderFromXML ("sample");
		addBinderFromXML ("smashBros");
		addBinderFromXML ("TimeComplexity");

		// add a dummy player
		addPlayer ("P1");
	
		// define deck generation preferences
		myDataBase.setMaxNumberOfCards (5);
		
		// generate deck
		myDeck = myDataBase.generateDeck ();

		// shuffle questions
		myDeck.shuffleDeck ();
	}

	/**
	 * Adds a player to the game
	 */
	public Player addPlayer (string name){
		Player tempPlayer = new Player (name);
		players.Add (tempPlayer);
		return tempPlayer;
	}

	/**
	 * Starts a round with the current settings
	 */
	public void startRound (){

		Debug.Log ("Start round called!");

		// Clear old results
		myResults = new List<Results> ();

		// Tells the GUIs to push the Question Card to the screen
		// The GUIs will operate asyncrounously and return before the player see the question because of how loadScene() operates
		askQuestion ();

		// Once a player answers the question, the DisplayAgent will call playerAnswer to return the results
	}

	/**
	 * DisplayAgent will call this function to pass the player's answer to the core. Once all the players have answered, the Core will call grade()
	 */
	public void playerAnswer(int playerID, Answer playerAnswer){
		// Store player's answer
		if (players.Count () < playerID)
			players [playerID].lastAnswer = playerAnswer;
		else
			DebugPlayerIndex (playerID);

		// Move on if all players have answered
		if (playersLeftToAnswer () == 0)
			// Grade all players
			gradeAllPlayers ();
	}

	/**
	 * The Core calls this function to grade all the players' answers to the last question
	 * It returns a Results object containing the original question, each players' answer and their correctness
	 * When grading has completed, it will push the results to the GUIs
	 */
	public void gradeAllPlayers(){
		// Clear old result data
		currentResults = new Results ();

		// Grade all answers to the current question
		currentResults.originalQuestion = currentCard;
		foreach (Player i in players) {
			grade (currentResults, i);
		}

		// Display the round's results on the screen
		displayQuestionResults (currentResults);

		// Flag that players are not ready to go to the next question
		makePlayersNotReady ();

		// As players hit the button to advance to the next scene, the DisplayAgent will call playerReady()
	}

	/**
	 * The DisplayAgent will call this function to signify that the player is ready to move onto the next question
	 * After all players are ready, the Core will call endRound()
	 */
	void playerReady(int playerID){
		// Store player's answer
		if (players.Count () < playerID)
			players [playerID].isReady = false;
		else
			DebugPlayerIndex (playerID);

		// Move on if all players are ready
		if (playersNotReady == 0)
			endRound ();
	}

	/**
	 * The Core calls this function to end the round
	 * This function will clean up all the temporary data from the round
	 * 		- currentResults
	 * This function will return by either calling startRound() or endGame()
	 */
	void endRound(){
		// Store this round's results
		myResults.Add (currentResults);

		// If we are good to ask another question, start another round
		if (continueGame ())
			startRound ();

		// Else, end the game
		else
			endGame ();
	}
	
	/**
	 * The Core calls this function when the game is over
	 * It will display the final results to the player and ask it to go to the
	 * 		- The Title Screen (keep current settings)
	 * 		- The Setup Screen (keep current settings)
	 * 		- Start another round (regenerate the deck with the same settings)
	 */
	public void endGame (){
		displayFinalResults ();

		// The DisplayAgent will decide which state to go to next based on user input
	}

/**
 * Main Loop Hooks
 */

	/** 
	 * Records a player's answer for the current question
	 */
	public void answerQuestion (Player myPlayer, Answer myAnswer){
		myPlayer.lastAnswer = myAnswer;
	}

	/** 
	 * Tells the Core that the player is ready to start the next question
	 */
	public void playerReady (int playerID){
		foreach (Player i in players)
			if(i.playerID==playerID) 
				i.isReady=true;
	}

/*
 * Subroutines
 */

	/**
	 * Retruns true iff we can ask another question
	 */
	bool continueGame(){
		// See if we have any questions left in the list
		// Later add option for timed countdown
		return myDeck.cardsLeft()>0;
	}

	/**
	 * Steps to ask a question
	 */
	void askQuestion(){

		Debug.Log ("Asking...");

		// Clear old answers
		foreach (Player i in players)
			i.lastAnswer = null;

		// Push new question to all screens
		currentCard=myDeck.drawCard();

		foreach(GUI i in myGUIs)
			i.nextQuestion (currentCard);
	}

	/**
	 * Display the round's results on each GUI
	 */
	void displayQuestionResults(Results roundResults){
		foreach (GUI i in myGUIs)
			i.displayQuestionResults (roundResults);
	}

	/**
	 * Display the final results on each GUI
	 */
	void displayFinalResults(finalResults){
		foreach (GUI i in myGUIs)
			i.displayFinalResults (finalResults);
	}

	/**
	 * Flag each player as not ready to go to the next question
	 */
	void makePlayersNotReady(){
		foreach (Player i in players)
			i.isReady = false;
	}

	/**
	 * Returns how many players have not answered
	 */
	int playersLeftToAnswer(){
		int result=0;
		foreach (Player i in players) {
			if(i.lastAnswer!=null) result++;
		}
		return result;
	}

	/**
	 * Returns how many players are not ready to move on
	 */
	int playersNotReady(){
		int result=0;
		foreach (Player i in players) {
			if(!i.isReady) result++;
		}
		return result;
	}

	/**
	 * Grades the player's answer and stores the result
	 */
	void grade(Results myResults, Player myPlayer){
		// Add player
		myResults.players.Add (myPlayer);

		// Add player's answer
		myResults.playerAnswers.Add (myPlayer.lastAnswer);

		// Grade answer
		switch (myPlayer.lastAnswer.myQuestionType) {
			// Compare multiple choice answers
			case QuestionType.MultipleChoice:
				myResults.isCorrect.Add(myPlayer.lastAnswer.multipleChoiceAnswer == myResults.originalQuestion.correctAnswer.multipleChoiceAnswer);
				break;

			default:myResults.isCorrect.Add(false);
				break;

		}
	}

	/**
	 * Assert level was true.
	 */
	public void makeGUILevelTrue()
	{
		foreach(GUI i in myGUIs)
			i.levelIsLoaded ();
	}

	/**
	* This is a dummy wait function.
	*/
	IEnumerator dontWorryAboutThis() {
		print (Time.time);
		yield return new WaitForSeconds (5);
		print (Time.time);
	}
	/**
	 * Preps the Core for executing
	 */
	void Awake(){
		DontDestroyOnLoad (transform.gameObject); // This is to keep the game core loaded for the other game scenes.
	}

	/**
	 * Executes when game starts
	 */
	void Start () {
		// moves from the title screen to the setup round screen
		// I will kill dontWorryAboutThis soon, I Just need this for sanity
		// and flow
		StartCoroutine (dontWorryAboutThis ());
		setupGame ();
		startRound ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

 /*
  * Debug Functions
  */
	
	/**
	 * This function displays an error when the player's index is out of range
	 */
	void DebugPlayerIndex(int playerID){
		Debug.Log ("Error: Player " + playerID + " does not exist\nOnly "+players.Count"+ people are playing");
	}
		
}
