using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AlphaChanger : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;    
    public event Action HideAnimationEnded;
    public enum Animation
    {
        Hold,
        Show,
        Hide
    }
    private Animation _state;
    private SpriteRenderer _spriteRenderer;
    private float _t;
    
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();        
    }
    
    private void Update()
    {
        switch (_state)
        {
            case Animation.Show:
                Show();
                break;

            case Animation.Hide:
                Hide();
                break;
        }
    }

    public void SetState(Animation state)
    {
        _state = state;
    }

    private void Show()
    {
        ChangeAlpha(0, 1);
        
        if (_t >= 1)
        {
            _state = Animation.Hold;
            _t = 0;
        }
    }
    private void Hide()
    {
        ChangeAlpha(1, 0);

        if (_t >= 1)
        {
            _state = Animation.Hold;
            _t = 0;
            HideAnimationEnded?.Invoke();
        }
    }

    private void ChangeAlpha(int startPoint, int endPoint)
    {    
        _t += _speed * Time.deltaTime;    
        var tempColor = _spriteRenderer.color;
        tempColor.a = Mathf.Lerp(startPoint, endPoint, _t);;
        _spriteRenderer.color = tempColor;
    }
    
}
