[System.Serializable]
// typical linklist class ,write this since want to add search by letter function//
public class C_List
{
    public C_Nodes RootNode;
    public int length;
    
    public C_List()
    {
        RootNode = null;
        length = 0;
    }
    public C_List(C_Nodes MyNode)
    {
        RootNode = new C_Nodes();
        RootNode = MyNode;
        length = 0;
    }

    public C_Nodes Get_Root()
    {
        return this.RootNode;
    }
    public void Insert(C_Nodes MyNode)
    {
        if (RootNode == null)
        {
            RootNode = MyNode;
            return;
        }
        else
        {
            C_Nodes A = new C_Nodes();
            A = RootNode;
            while (A.NextNode!= null)
            {
                A = A.Get_Next();
            }
            A.Set_Next(MyNode);
            length++;
            return;
        }
    }

    public int Get_length()
    {
        return this.length;
    }

    public Card Search(string letter)
    {
        C_Nodes A = new C_Nodes();
        A = RootNode;
        while (A.Get_Name(A) != letter && A.Get_Next() != null) {
            A = A.Get_Next();
        }
        if (A.Get_Name(A) == letter) {
            return A.Get_Card(A);
        }
        else
        {
            return null;
        }
    }

    public Card Get_Card_At(int pos)
    {
        C_Nodes A = new C_Nodes();
        A = RootNode;
        for (int i= 0; i<pos; i++)
        {
            A = A.Get_Next();
        }
        return A.Get_Card(A);
    }
   
    public Card Search(int ID)
    {
        C_Nodes A = new C_Nodes();
        A = RootNode;
        while (A.Get_ID(A) != ID && A.Get_Next() != null)
        {
            A = A.Get_Next();
        }
        if (A.Get_ID(A)== ID)
        {
            return A.Get_Card(A);
        }
        else
        {
            return null;
        }

    }




    public void delete(C_Nodes A)
    {
        C_Nodes Pre = new C_Nodes();
        C_Nodes Temp = new C_Nodes();
        Temp = this.RootNode;
        while(Temp != A && Temp.Get_Next()!=null)
        {
            Pre = Temp;
            Temp = Temp.Get_Next();
        }
        if(RootNode == A)
        {
            RootNode = Temp.Get_Next();
            return;
        }
        else
        {
            Pre.Set_Next(Temp.Get_Next());
            return;
        } 
    }

   
    public Card display()
    {
        return null;
    }
    


}