using System.Collections.Generic;

public class GridUtility 
{    
    public static List<Node> GetNeighbors(Node node, Node[,] grid)
    {
        List<Node> neighbors = new List<Node>();
        
        Node up = GetUpNeighbor(node, grid);
        if(up != null)
            neighbors.Add(up);
        
        Node down = GetDownNeighbor(node, grid);
        if(down != null)
            neighbors.Add(down);        

        Node left = GetLeftNeighbor(node, grid);
        if(left != null)
            neighbors.Add(left);        

        Node right = GetRightNeighbor(node, grid);
        if(right != null)
            neighbors.Add(right);        

        return neighbors;
    }

    public static Node GetUpNeighbor(Node node, Node[,] grid)
    {
        if (CheckNodeExistance((int)node.Index.y + 1, (int)node.Index.x, grid.GetLength(0), grid.GetLength(1)) == true)
           return grid[(int)node.Index.y + 1, (int)node.Index.x];
        return null;
    }

    public static Node GetDownNeighbor(Node node, Node[,] grid)
    {
        if (CheckNodeExistance((int)node.Index.y - 1, (int)node.Index.x, grid.GetLength(0), grid.GetLength(1)) == true)
            return grid[(int)node.Index.y - 1, (int)node.Index.x];
        return null;
    }

    public static Node GetLeftNeighbor(Node node, Node[,] grid)
    {
        if (CheckNodeExistance((int)node.Index.y, (int)node.Index.x - 1, grid.GetLength(0), grid.GetLength(1)) == true)
            return grid[(int)node.Index.y, (int)node.Index.x - 1];
        return null;
    }

    public static Node GetRightNeighbor(Node node, Node[,] grid)
    {
        if (CheckNodeExistance((int)node.Index.y, (int)node.Index.x + 1, grid.GetLength(0), grid.GetLength(1)) == true)
            return grid[(int)node.Index.y, (int)node.Index.x + 1];
        return null;
    }
    public static bool CheckNodeExistance(int i, int j, int gridGRID_Height, int gridGRID_Width)
    {
        if (i >= 0 && i < gridGRID_Height && j >= 0 && j < gridGRID_Width)
            return true;
        else
            return false;
    }
}
