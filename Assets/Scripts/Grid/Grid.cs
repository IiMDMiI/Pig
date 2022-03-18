using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public List<Node> NodesList;
    private int _width = 17;
    private int _height = 9;
    public Node[,] Nodes;
    private void Awake()
    {
        Nodes = new Node[_height, _width];

        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
                Nodes[i, j] = NodesList[j + (i * _width)];
        }        
    }

    



}
