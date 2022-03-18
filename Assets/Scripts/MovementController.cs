using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class MovementController : MonoBehaviour, IChangeNodes
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private Node _currentNode;
    public event Action<Node> OnCurrentNodeChanged;    
    private InputController _inputController;
    private Grid _grid;
    private Vector2 _moveDirection;   

    private void Start()
    {
        _inputController = FindObjectOfType<InputController>();
        _inputController.OnMoveDirectionInput += direction => _moveDirection = direction;
        _grid = FindObjectOfType<Grid>();
    }
    private void OnDisable() => _inputController.OnMoveDirectionInput -= direction => _moveDirection = direction;
    private void Update() => Move();

    private void Move()
    {
        if (_moveDirection.magnitude == 0)
            return;

        Node target = null;
        int i = 0, j = 0;
        bool moveHorizontal = Mathf.Abs(_moveDirection.x) >= Mathf.Abs(_moveDirection.y);

        if (moveHorizontal == true)
        {
            i = (int)_currentNode.Index.y;
            j = (int)_currentNode.Index.x + (int)Mathf.Round(_moveDirection.x);
        }
        else
        {
            i = (int)_currentNode.Index.y + (int)Mathf.Round(_moveDirection.y) * -1;
            j = (int)_currentNode.Index.x;
        }

        if (GridUtility.CheckNodeExistance(i, j, _grid.Nodes.GetLength(0), _grid.Nodes.GetLength(1)) == true)
            target = _grid.Nodes[i, j];



        if (target != null && target.IsWalkable == false)
        {
            List<Node> neighbors = new List<Node>();
            if (moveHorizontal == true)
            {
                Node up = GridUtility.GetUpNeighbor(_currentNode, _grid.Nodes);
                if (up != null)
                    neighbors.Add(up);

                Node down = GridUtility.GetDownNeighbor(_currentNode, _grid.Nodes);
                if (down != null)
                    neighbors.Add(down);

                if (neighbors != null && neighbors.Count > 0)
                    target = (neighbors.OrderBy(n => Vector3.Distance(transform.position, n.transform.position)).ToList())[0];
            }
            else
            {
                Node left = GridUtility.GetLeftNeighbor(_currentNode, _grid.Nodes);
                if (left != null)
                    neighbors.Add(left);

                Node right = GridUtility.GetRightNeighbor(_currentNode, _grid.Nodes);
                if (right != null)
                    neighbors.Add(right);

                if (neighbors != null && neighbors.Count > 0)
                    target = (neighbors.OrderBy(n => Vector3.Distance(transform.position, n.transform.position)).ToList())[0];
            }
        }



        var tempNode = _currentNode;
        List<Node> walckableNodes = _grid.NodesList.Where(n => n.IsWalkable == true).ToList();
        _currentNode = (walckableNodes.OrderBy(n => Vector3.Distance(transform.position, n.transform.position)).ToList())[0];

        if (tempNode != _currentNode)
            OnCurrentNodeChanged?.Invoke(_currentNode);


        if (target != null && _currentNode.IsWalkable == true)
            transform.position = Vector3.MoveTowards(transform.position, target.gameObject.transform.position, _speed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, _currentNode.gameObject.transform.position, _speed * Time.deltaTime);

    }


}
