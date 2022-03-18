using System.Collections.Generic;

public class AStar
{  
    private static List<Node> _open;
    private static List<Node> _close;
    private static Node _start;
    private static Node _end;
    private static int _fuse = 1000;
    
    public static bool TryFindPath(Node start, Node end, Node[,] grid, out List<Node> path)
    {   
        _end = end;
        _start = start;
        _fuse = 1000;

        _open = new List<Node>() { _start };
        _close = new List<Node>();
        foreach (var node in grid)
            node.Reset(_end.Index);

        _start.Gcost = 0;
        path = FindPath(grid);
        
        
        if (path == null)
            return false;
        return true;
    }

    private static List<Node> FindPath(Node[,] grid)
    {
        while (_open.Count > 0)
        {
            _fuse--;
            if (_fuse < 0)
                return null;

            // добавление ноды в закрытый список
            Node currentNode = GetClosestNode(_open);
            _open.Remove(currentNode);
            _close.Add(currentNode);
            
            if (currentNode == _end)
                return CalculatePath();


            List<Node> neighbors = GridUtility.GetNeighbors(currentNode, grid);
                        
            foreach (var node in neighbors)
            {
                if(_close.Contains(node) == true)
                    continue;

                int tentativeGCost = currentNode.Gcost + currentNode.NodeCost + currentNode.GetH(currentNode.Index);   
                if(tentativeGCost < node.Gcost)
                {
                    node.Gcost = tentativeGCost;
                    node.PreviousNode = currentNode;
                    node.CalculateFcost(_end.Index);

                    if(_open.Contains(node) == false && node.IsWalkable == true)
                        _open.Add(node);
                } 
            }
        }
        return null;
    }

    private static List<Node> CalculatePath()
    {
        List<Node> path = new List<Node>();
        _close[0].PreviousNode = null;
        _close.Reverse();

        Node node = _close[0];
        while (node.PreviousNode != null)
        {
            _fuse--;
            if (_fuse < 0)
                return null;
            path.Add(node);
            node = node.PreviousNode;
        }        

        path.Reverse();
        return path;
    }

    private static Node GetClosestNode(List<Node> nodes)
    {
        Node node = nodes[0];
        for (int i = 1; i < nodes.Count; i++)
        {
            if (nodes[i].Fcost < node.Fcost)
                node = nodes[i];
        }
        return node;
    }

    
}
