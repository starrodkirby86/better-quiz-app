/**
 * Utility Class used to hold player data
 */

[System.Serializable]
public class Player {

	public Player(string playerName){
		this.playerName = playerName;
		this.playerID = Player.lastPlayerID + 1;
		Player.lastPlayerID++;
	}

	/**
	 * The name of the player (or nickname)
	 */
	public string playerName;

	/**
	 * The player's ID. Must be unique to each player and is automatically generated in the constructor
	 */
	public int playerID;

	/**
	 * The last created playerID
	 * The first player will be player 0. The next player will have a playerID of (lastPlayerID + 1). 
	 * When displayed to the screen, the ID should be incremented by 1.
	 * ex: A player with ID=0 would be P1
	 * ex: A player with ID=1 would be P2
	 * ex: A player with ID=2 would be P3
	 * ex: A player with ID=3 would be P4
	 */
	static int lastPlayerID=-1;

	/**
	 * The player's last answer. The core should set this to null before pushing the next question to the GUI.
	 * The GUI will then fill in the player's answer to the question and pass this object back
	 */
	public Answer lastAnswer;

	/** 
	 * True iff the player is ready to move to the next question
	 */
	public bool isReady = false;


}
