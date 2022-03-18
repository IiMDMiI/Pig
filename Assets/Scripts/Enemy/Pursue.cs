using System;
using UnityEngine;
using System.Collections.Generic;

public class Pursue : State, IChangeNodes
{
    [SerializeField] private float _speed = 5;
    public event Action<Node> OnCurrentNodeChanged;
    private Player _target;
    private AudioSource _audioSource;

    private void Awake()
    {
        Initialize();
        _audioSource = GetComponent<AudioSource>();
        _target = FindObjectOfType<Player>();
    } 

    public override void Enter() {_audioSource.Play();}
    public override void Exit() {}

    public override void UpdateState()
    {
        if (_enemy.CurrentNode != _enemy.PreviousNode)
            OnCurrentNodeChanged?.Invoke(_enemy.CurrentNode);
        
        
        if (_enemy.CurrentNode == _target.CurrentNode)
        {
             
            transform.position = Vector3.MoveTowards(transform.position, _target.gameObject.transform.position, _speed * Time.deltaTime);
            return;
        }

        List<Node> path = new List<Node>();
        AStar.TryFindPath(_enemy.CurrentNode, _target.CurrentNode, _enemy.Grid.Nodes, out path);
        if (path == null || path.Count == 0)
            return;

        transform.position = Vector3.MoveTowards(transform.position, path[0].transform.position, _speed * Time.deltaTime);
    }
}
