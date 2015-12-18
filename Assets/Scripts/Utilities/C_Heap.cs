using System.Collections.Generic;

/** 
 * Utility Class used to hold all the cards for this game
 */
[System.Serializable]
public class C_Heap
{
    public List<Card> Table = new List<Card>();
    public C_Heap(){ }
    public void Insertion(Card A)
    {
        if (Table.Count == 0)
        {
            Table.Insert(0, A);
        }
        int Child = Table.Count - 1;
        int Parent = (Child - 1) / 2;
        while (Parent >= 0 && Table[Parent].random_ID > Table[Child].random_ID)
        {
            Card temp = Table[Parent];
            Table[Parent] = Table[Child];
            Table[Child] = temp;
            Child = Parent;
            Parent = (Child - 1) / 2;
        }

    }
    public Card Get_Min()
    {
        return Table[0];
    }

    public List<Card> Get_List()
    {
        return Table;
    }

    public int Count()
    {
        return Table.Count;
    }

    public void RemoverMin()
    {
        Table[0] = Table[Table.Count - 1];
        Table.RemoveAt(Table.Count - 1);
        int Parent = 0;
        int LeftChild = 2 * Parent + 1;
        int RightChild = LeftChild + 1;
        int minID = 0;
        while (true)
        {
            LeftChild = 2 * Parent + 1;
            RightChild = LeftChild + 1;

            if (LeftChild >= Table.Count - 1)
            {
                break;
            }

            if (Table[LeftChild].random_ID <= Table[RightChild].random_ID)
            {
                minID = LeftChild;
            }
            else
            {
                minID = RightChild;
            }

            if (Table[Parent].random_ID < Table[minID].random_ID)
            {
                Card temp = Table[Parent];
                Table[Parent] = Table[minID];
                Table[minID] = temp;
                Parent = minID;

            }
            else { break; }
        }

    }

}
