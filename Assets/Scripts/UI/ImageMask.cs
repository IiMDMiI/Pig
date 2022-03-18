using UnityEngine;
using UnityEngine.UI;

public class ImageMask : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private float _remainingTime;
    private Image _image;
    private void Start() => _image = GetComponent<Image>();
    private void Update()
    {
        _remainingTime -= Time.deltaTime;        
        _image.fillAmount = _remainingTime / _time;
    }
     
    public void Reset()
    {
        if(_remainingTime > 0)
            return;
        _remainingTime = _time;
    }  
    
        
    
}
