using UnityEngine;

[RequireComponent (typeof(Animator))]
public class Popup : MonoBehaviour
{   
    public static Popup Instance; 
    private Animator _animator;  
   
    private void Start()
    {
        Instance = this;
        _animator = GetComponent<Animator>();        
    } 
    public void ShowPopup() => _animator.Play("Down");     
   
}
