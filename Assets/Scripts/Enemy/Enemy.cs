using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pursue)), RequireComponent(typeof(Patrolling)), RequireComponent(typeof(Stun)), RequireComponent(typeof(SpriteDirectionController))]
public class Enemy : MonoBehaviour
{
    public Node PreviousNode { get => _previousNode; private set {; } }
    public Node CurrentNode { get => (_grid.NodesList.OrderBy(n => Vector3.Distance(transform.position, n.transform.position)).ToList())[0]; }
    public Grid Grid => _grid;

    private SpriteDirectionController _spriteDirectionController;
    private Dictionary<Type, State> _states = new Dictionary<Type, State>();
    private State _currentState;
    private Grid _grid;
    private Node _previousNode;
    private Vector3 _startPosition;
    private void Start()
    {
        var statesArray = GetComponents<State>();
        _spriteDirectionController = GetComponent<SpriteDirectionController>();
        _grid = FindObjectOfType<Grid>();
        foreach (var state in statesArray)
            _states.Add(state.GetType(), state);

        
        _previousNode = CurrentNode;
        _startPosition = transform.position;
        ChangeState(typeof(Patrolling));
    }

    private void Update() => _currentState.UpdateState();
      
    public void ChangeState(Type type)
    {   
        if(_currentState != null)
            _currentState.Exit();
        
        _currentState = _states[type];
        _currentState.Enter();
        _spriteDirectionController.SpritesSetName = type.ToString();
    }

    public void Reset()
    {
        transform.position = _startPosition;
        ChangeState(typeof(Patrolling));
    }
    

}
