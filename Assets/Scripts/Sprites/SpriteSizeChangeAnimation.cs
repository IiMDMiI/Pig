using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteSizeChangeAnimation : MonoBehaviour
{   
    [SerializeField] private float _sizeIncreasePercent = 10;
    [SerializeField] private float _increaseStep = 0.05f;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _defaultScale;
    private Vector3 _increasedScale;
    private bool _increasing = true;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();   
        _defaultScale = transform.localScale;         
        _increasedScale = _defaultScale * (1 + _sizeIncreasePercent / 100);  
    }
    
    private void Update()
    {
        ChangeSize();
    }

    private void ChangeSize()
    {
        if(_increasing == true)
        {   
            transform.localScale = Vector3.MoveTowards(transform.localScale, _increasedScale, _increaseStep * Time.deltaTime); 
            if(transform.localScale == _increasedScale)
                _increasing = false;
        }
        
        else
        {   
            transform.localScale = Vector3.MoveTowards(transform.localScale, _defaultScale, _increaseStep * Time.deltaTime); 
            if(transform.localScale == _defaultScale)
                _increasing = true;
        }
            
        

    }
}
