using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector3 Position => transform.position;
    public Vector2 Index;    

    public int Fcost;
    public int NodeCost;
    public int Gcost;
    public Node PreviousNode;
    public bool IsWalkable = true;   
    
    public void Reset(Vector3 targetCoordinates)
    {
        CalculateFcost(targetCoordinates);
        PreviousNode = null;
        Gcost = int.MaxValue;
    }
    

    public void CalculateFcost(Vector3 targetCoordinates)
    {
        Fcost = GetH(targetCoordinates) + Gcost;
    }

    
    public int GetH(Vector2 targetIndex)
    {
        int x = (int)Mathf.Abs(Index.x - targetIndex.x);
        int y = (int)Mathf.Abs(Index.y - targetIndex.y);
        
        return x + y;
    }

    

}


