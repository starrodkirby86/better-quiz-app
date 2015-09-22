/**
 * Utility Class used to hold player data
 */
public class Player {

	public Player(string playerName){
		this.playerName = playerName;
		this.playerID = Player.lastPlayerID + 1;
		Player.lastPlayerID++;
	}

	/**
	 * The name of the player
	 */
	string playerName;

	/**
	 * The player's ID
	 */
	int playerID;

	/**
	 * The last created playerID. The next player will have a playerID of (lastPlayerID + 1)
	 */
	static int lastPlayerID=0;

	/**
	 * The player's last answer. Set to null at beginning of question
	 */
	public Answer lastAnswer;

}
