using System.Linq;
using System.Text;
using System;
// The Table to to construct the data , A 2D-array Array of Linklist
[System.Serializable]
public class C_Table
{
    public const int tablelength = 25; // Length = alphbelt
    public const int tablewidth = 6;   // width is consit of different degree of weight_ID
    public C_List[,] Table;

    public C_Table() // constructor 
    {
        Table = new C_List[tablelength, tablewidth];
        for (int i = 0; i < tablelength; i++)
        {
            for (int j = 0; j < tablewidth; j++)
            {
                Table[i, j] = null;
            }

        }
    }
    // Input :question Name; output Fisrt letter corresponding  to their code a - p//
    public static int Get_POS_ID(string text) 
                                       
    {
        int sum = 0;
        foreach (char c in text)
        {
            sum = sum * 26 + c - 'A' + 1;
        }
        return sum;
    }
    // insert a card from xml file, located first then push into linklist//
    public void insert(Card myCard)  
    {
        C_Nodes NewNode = new C_Nodes(myCard);
        string alplha = myCard.Get_first_letter();
        int i = Get_POS_ID(alplha);
        int j = myCard.Get_ID();
        this.Table[i, j].Insert(NewNode);
        return;
    }
    //input CurrentI(pre) and Node, then change its postion due to its new weight_ID//
    public void change(C_Nodes A, int Pre)
    {
        string alplha = A.Get_Card(A).Get_first_letter();
        int i = Get_POS_ID(alplha);
        int j = A.Get_Card(A).Get_ID();
        this.Table[i, j].Insert(A);
        this.Table[i, Pre].delete(A);
        return;
    }
    //search by first letter of question name//
    public Card Search(string letter)
    {
        string subletter = letter.Substring(0);
        int i = Get_POS_ID(subletter);
        int j = 0;
        Card Mycard = this.Table[i, j].Search(letter);
        while (Mycard == null && j < tablewidth)
        {
            j++;
            Mycard = this.Table[i, j].Search(letter);
        }
        return Mycard;
    }
    //
    public Card Get_Card(int ID, string letter, int pos)
    {
        int Num = Get_POS_ID(letter);
        return Table[ID, Num].Get_Card_At(pos);
    }


    //If the Cell in the array is null ,search the the nearest cell//
    public C_List Nearest_One(int length, int width)
    {
        int i = 0;
        int j = 0;
        double distance = Math.Sqrt((length - i) ^ 2 + (width - j) ^ 2);

        C_List List = Table[i, j];

        for (; i < tablewidth; i++)
        {   
            for (; j < tablelength; j++)
            {   
                double D = Math.Sqrt((length - i) ^ 2 + (width - j) ^ 2);
                if (this.Table[i, j].Get_Root()!= null && D < distance)
                {   
                    distance = D;
                    List = this.Table[i, j];
                }

            }
             
        }
        return List;
    }

}




   



