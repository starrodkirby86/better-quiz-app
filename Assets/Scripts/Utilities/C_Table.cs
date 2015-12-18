using System.Linq;
using System.Text;
using System;

[System.Serializable]
public class C_Table
{
    public const int tablelength = 25;
    public const int tablewidth = 6;
    public C_List[,] Table;

    public C_Table()
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

    public static int Get_POS_ID(string text)
    {
        int sum = 0;
        foreach (char c in text)
        {
            sum = sum * 26 + c - 'A' + 1;
        }
        return sum;
    }

    public void insert(Card myCard)
    {
        C_Nodes NewNode = new C_Nodes(myCard);
        string alplha = myCard.Get_first_letter();
        int i = Get_POS_ID(alplha);
        int j = myCard.Get_ID();
        this.Table[i, j].Insert(NewNode);
        return;
    }

    public void change(C_Nodes A, int Pre)
    {
        string alplha = A.Get_Card(A).Get_first_letter();
        int i = Get_POS_ID(alplha);
        int j = A.Get_Card(A).Get_ID();
        this.Table[i, j].Insert(A);
        this.Table[i, Pre].delete(A);
        return;
    }

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

    public Card Get_Card(int ID, string letter, int pos)
    {
        int Num = Get_POS_ID(letter);
        return Table[ID, Num].Get_Card_At(pos);
    }



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




   



