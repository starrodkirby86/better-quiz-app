using UnityEngine; // For Random
using System.Collections.Generic; // For lists

/** 
 * Utility Class used to hold all the cards for this game
 */
[System.Serializable]
public class Deck {
	
	/**
	 * An array of cards that have yet to be drawn
	 */
	public List<Card> drawPile = new List<Card>();
	
	/**
	 * An array of cards that have already been drawn
	 */
	List<Card> discardPile = new List<Card>();


    public Deck(int number, C_Table A)
    {
        int i, j;
        C_Heap Heap = new C_Heap();
        for (i = 0; i < 25; i++)
        {
            for (j = 0; j < 6; j++)
            {
                if (A.Table[i, j].Get_Root() != null)
                {
                    C_Nodes Temp = A.Table[i, j].Get_Root();
                    while (Temp.Get_Next() != null)
                    {
                        Temp.Get_Card(Temp).random_ID = Random.Range(0, 1) ^ (1 / (Temp.Get_Card(Temp).random_ID));
                        if (Heap.Count() < number)
                        {
                            Heap.Insertion(Temp.Get_Card(Temp));
                        }
                        else
                        {
                            if (Heap.Get_Min().random_ID < Temp.Get_Card(Temp).random_ID)
                            {
                                Heap.RemoverMin();
                                Heap.Insertion(Temp.Get_Card(Temp));
                            }

                        }
                        Temp.Get_Next();
                    }

                }
            }
        }
    }
	/**
	 * Function to add an array of cards into the deck
	 */
	public void addManyCards(Card[] newCards){
		foreach (Card i in newCards) {
			addCard(i);
		}
	}

	/**
	 * Function to add a card into the deck.
	 * New cards should go into the drawPile
	 */
	public void addCard(Card newCard){
		drawPile.Add(newCard);
	}

	/**
	 * Function to permanently remove an array of cards from the deck
	 */
	public void removeManyCards(Card[] myCards){
		foreach (Card i in myCards) {
			removeCard(i);
		}
	}

	/**
	 * Function to permanently remove a card from the deck
	 */
	public void removeCard(Card myCard){
		drawPile.Remove (myCard);
		discardPile.Remove (myCard);
	}

	/**
	 * Function for the Core to draw a card	
	 */
	public Card drawCard(){
		Card result = drawPile [0];
		drawPile.Remove(result);
		discardPile.Add(result);
		return result;
	}

	/**
	 * Function to return the number of cards left
	 */
	public int cardsLeft(){
		return drawPile.Count;
	}

	/**
	 * A function to shuffle the drawPile with the discardPile. Result will go into the drawPile. Call before the game starts
	 */


     public void merge()
    {
        foreach (Card i in discardPile)
        {
            drawPile.Add(i);
            discardPile.Remove(i);
        }
    }

    public void Cycle_Lead(int head)
    {
        Card temp = null;
        Card End = drawPile[head];
        int i = 0;
        int n = drawPile.Count;
        for (i = head * 2 % (2 * (n + 1)); i != head; i = (2 * i) % (2 * n + 1))
        {
            temp = drawPile[i - 1];
            drawPile[i - 1]= End;
            End = temp;
        }
        drawPile[head] = End;
    }

    public void reverse(int For,int End) {
        Card myCard = null;
        while (For < End)
        {
            myCard = drawPile[For];
            drawPile[For] = drawPile[End];
            drawPile[End] = myCard;

        }

    }

    public void shift_N(int m ,int n)
    {
        reverse(m + 1, n);
        reverse(n + 1, 2*n);
        reverse(m + 1, n);
    }

    
    public void shuffle(int HalfSize ,int m)
    {
        Card Temp = null; 
        if (HalfSize ==1)
        {
            Temp = drawPile[0];
            drawPile[0] = drawPile[1];
            drawPile[1] = Temp;
            return;
        }
        if (HalfSize > 1)
        {  int m2 = 1;
           int k = 0;
            while ((2 * HalfSize)/ m2 >= 3)
            {
                k++;
                m2 = m2 * 3;
            }
            m = m + (m2 / 2);
            this.shift_N(m, HalfSize);
            for(int i=0; i< k; i++)
            {
                int h = 1;
                this.Cycle_Lead(h);
                h = h * 3;
            }
            this.shuffle(HalfSize - m, 2 * m);
        }
       
    }


	public void shuffleDeck(){

		// Combine drawPile with discardPile and store in drawPile
		foreach (Card i in discardPile) {
			drawPile.Add (i);
			discardPile.Remove (i);
		}

		// Shuffles the drawPile
		for (int i = 0; i < drawPile.Count; i++) {
			Card temp = drawPile [i];
			int randomIndex = Random.Range (i, drawPile.Count);
			drawPile [i] = drawPile [randomIndex];
			drawPile [randomIndex] = temp;
		}
	}

	/**
	 * Function to verify if an existing card in drawPile
	 * matches the input card
	 */
	public bool cardMatch(Card inputCard)
	{
		for (int i = 0; i < drawPile.Count; i++) {
			if(drawPile[i] == inputCard)
				return true;
		}
		return false; // Reaching here implies card wasn't found
	}
}