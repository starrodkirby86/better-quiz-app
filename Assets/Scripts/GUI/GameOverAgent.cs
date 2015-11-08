using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverAgent : MonoBehaviour {

	void OnLevelWasLoaded(int level) {
		loadCache ();

		generateResultsString ();
	}

	// Cache the on screen objects to improve performance
	Core myCore;
	Text myText;

	/**
	 * This generates a concatenation of all your hard-earned results in a very
	 * monotonous string file to be displayed on the screen. In the future, we'd
	 * like this to be a bit better in the visual department.
	 */
	void generateResultsString()
	{
		string resultsMessage = "RESULTS: \n";

		// So first we grab the total results from the Core...
		int questionValue = 1;
		foreach(Results i in myCore.myResults)
		{
			resultsMessage += "Question " + (questionValue) + "\n";
			for(int j = 0; j < myCore.players.Count; ++j)
			{
				resultsMessage += "Player " + i.players[j].playerName + ": ";
				if(i.isCorrect[j])
					resultsMessage += "O";
				else
					resultsMessage += "X";

				resultsMessage += "\n==================\n";
			}
			questionValue++;
		}

		// Send it to the UI text on the Game Over screen
		myText.text = resultsMessage;
	}
	
	// Searches out the game for our objects. Caching them improves performance
	void loadCache(){
		// Find Core
		if (myCore == null) {
			myCore = GameObject.Find ("GameCore").GetComponent<Core>();
		}
		
		// Find the text for the results
		if (myText == null) {
			myText = GameObject.Find ("viewScrollViewText").GetComponent<Text> ();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
