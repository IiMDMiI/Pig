using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : State, IChangeNodes
{
    [SerializeField] private float _speed = 4;    
    private Player _target;
    private SpriteDirectionController _spriteDirectionController;    
    private int _pathNodeIndex = 0;
    private List<Node> _path = new List<Node>();
    public event Action<Node> OnCurrentNodeChanged;
    private void Awake()
    {
        Initialize();
        _spriteDirectionController = GetComponent<SpriteDirectionController>();
        _target = FindObjectOfType<Player>();
    } 

    public override void Enter()
    {
        SetDistantion();        
    }

    public override void Exit()
    {

    }

    public override void UpdateState()
    {
        if (_enemy.CurrentNode != _enemy.PreviousNode)
            OnCurrentNodeChanged?.Invoke(_enemy.CurrentNode);

        SearchPlayer();
        Move();        
        
    }

    private void SetDistantion()
    {
        _pathNodeIndex = 0;
        var walckableNodes = _enemy.Grid.NodesList.Where(n => n.IsWalkable == true).ToList();
        AStar.TryFindPath(_enemy.CurrentNode, walckableNodes[UnityEngine.Random.Range(0, walckableNodes.Count)], _enemy.Grid.Nodes, out _path);
        if (_path == null || _path.Count < 2)
            SetDistantion();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _path[_pathNodeIndex].transform.position, _speed * Time.deltaTime);
        if (transform.position == Vector3.MoveTowards(transform.position, _path[_pathNodeIndex].transform.position, _speed * Time.deltaTime))
        {
            if (_pathNodeIndex < _path.Count - 1)
                _pathNodeIndex += 1;
            else
                SetDistantion();
        }
    }

    private void SearchPlayer()
    {
        switch(_spriteDirectionController.CurrentDirection)
        {
            case SpriteDirectionController.Direction.Down:
            {
                if((_enemy.CurrentNode.Index.x == _target.CurrentNode.Index.x) && (_enemy.CurrentNode.Index.y > _target.CurrentNode.Index.y))
                    _enemy.ChangeState(typeof(Pursue));
                break;                                  
            }
            case SpriteDirectionController.Direction.Up:
            {
                if((_enemy.CurrentNode.Index.x == _target.CurrentNode.Index.x) && (_enemy.CurrentNode.Index.y < _target.CurrentNode.Index.y))
                    _enemy.ChangeState(typeof(Pursue));
                break;                                  
            }
            case SpriteDirectionController.Direction.Left:
            {
                if((_enemy.CurrentNode.Index.y == _target.CurrentNode.Index.y) && (_enemy.CurrentNode.Index.x > _target.CurrentNode.Index.x))
                    _enemy.ChangeState(typeof(Pursue));
                break;                                  
            }
            case SpriteDirectionController.Direction.Right:
            {
                if((_enemy.CurrentNode.Index.y == _target.CurrentNode.Index.y) && (_enemy.CurrentNode.Index.x < _target.CurrentNode.Index.x))
                    _enemy.ChangeState(typeof(Pursue));
                break;                                  
            }
        }
    }
}
