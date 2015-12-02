/**
 * This class holds the user's choices on how to generate the deck
 * In the future, it should be saved to a file and loaded at initialization time
 */

[System.Serializable]
public class GenerationPreferences{
	
	// Maximum number of cards to generate
	public int numberOfCards;
};

public class GamePreferences{

	// Maximum time per question
	public int timePerQuestion;
};