[System.Serializable]
public class C_Nodes
{
    public Card Data;
    public C_Nodes NextNode;

    public C_Nodes()
    {
        Data = null;
        NextNode = null;
    }
    public C_Nodes(Card MyCard)
    {
        Data = MyCard;
        NextNode = null;

    }

    public Card Get_Card(C_Nodes A)
    {
        return A.Data;

    }
    public int Get_ID(C_Nodes A)
    {
        return A.Data.weight_ID;
    }

    public string Get_Name(C_Nodes A)
    {
        return A.Data.Cardname;
    }

    public C_Nodes Get_Next()
    {
        return this.NextNode;
    }

    public void Set_Next(C_Nodes myNode)
    {
        this.NextNode = myNode;
        return;
    }

   



}