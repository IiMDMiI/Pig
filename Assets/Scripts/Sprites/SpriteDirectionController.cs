using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteDirectionController : MonoBehaviour
{
    [Serializable]
    private struct SpritesSet
    {
        public string Name;
        public Sprite[] Sprites;
    }
    public enum Direction
    {   
        Right,
        Left,        
        Down,
        Up          
    }
    [SerializeField] private List<SpritesSet> _spritesSets;
    public string SpritesSetName = "Default";
    public Direction CurrentDirection => _currentDirection;

    private SpriteRenderer _spriteRenderer;
    private Vector3 _previousPosition;
    private Direction _currentDirection;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _previousPosition = transform.position;
    }

    private void Update()
    {
        DefineMoveDirection();
        _spriteRenderer.sprite = (_spritesSets.First(set => set.Name == SpritesSetName)).Sprites[(int)_currentDirection];
    }
    private void DefineMoveDirection()
    {
        if(_previousPosition == transform.position)
            return;

        if (Mathf.Abs(_previousPosition.x - transform.position.x) >= Mathf.Abs(_previousPosition.y - transform.position.y))
        {
            if (_previousPosition.x >= transform.position.x)
                _currentDirection = Direction.Left; 
            else
                _currentDirection = Direction.Right;
        }
        else
        {
            if (_previousPosition.y >= transform.position.y)
                _currentDirection = Direction.Down;
            else
                _currentDirection = Direction.Up;
        }

        _previousPosition = transform.position;
    }
}
