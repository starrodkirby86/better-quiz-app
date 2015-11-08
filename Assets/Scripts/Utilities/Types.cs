/**
 * An enumerated type to differentiate between different GUI scenes
 * 
 * Title: The title screen. A welcoming splash screen that gives the player the option to
 * 		- Start a new game
 * 		- Add folders to the binder library
 * 			- The setup screen will load all binders from the above folder(s) to pick cards from
 * 		- Edit the location for the preferences file (stretch goal)
 * 		- View high scores (stretch goal)
 * 
 * NewGame: Setup a game to play
 * 		- Choose number of players & set nicknames
 * 		- Choose which binders/cards to use (+weights)
 * 		- Choose number of cards to play through
 * 		- Enable speed mode where points are awarded based on response time AND correct answer (stretch goal)
 * 		- Choose win condition:
 * 			- Only stop when all questions are asked
 * 			- Stop after a certain amount of time
 * 			- Stop after a player correctly answers a certain amount of questions
 * 		- Return when setup is complete; Core will move to AskQuestion when game is ready
 * 
 * AskQuestion: Displays a question to the user
 * 		- Multiple Choice: Display possible answers, click on one to submit
 * 		- Short Answer: Display checkbox, click "submit" or press enter to submit
 * 		- Send player's answer to Core
 * 		- Lock answer after submital and return; Core will move to QuestionResults after grading
 * 
 * QuestionResults: Show how the player did
 * 		- Show correct/model answer
 * 		- Show all players' answers and grade
 * 		- Show all players' score up to this point
 * 		- Return when player presses a button to move onto the next question; Core will move to AskQuestion
 * 
 * GameOver: Show overall results; Core will move here when the win condition is completed
 * 		- Show each player's score
 * 		- Rank players
 * 		- Button to play again (return Scene.NewGame when pressed)
 * 			- Core should initialize the settings with the same settings as the last game
 * 		- Button to quit (return Scene.Title when pressed)
 */
public enum Scene {Title, Options, NewGame, AskQuestion, QuestionResults, GameOver};

/**
 * An enumerated type to differentiate between different Question Types
 */
public enum QuestionType {ShortAnswer, MultipleChoice};