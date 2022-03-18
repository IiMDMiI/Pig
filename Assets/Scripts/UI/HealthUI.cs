using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private List<Image> _hearts;
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _player.OnHeratsAmountChanged += OnHeratsAmountChangedHandler;
        OnHeratsAmountChangedHandler();
    }
    private void OnDisable() => _player.OnHeratsAmountChanged -= OnHeratsAmountChangedHandler;  

    private void OnHeratsAmountChangedHandler()
    {
        for (int i = 0; i < _hearts.Count; i++)
            _hearts[i].color = new Color(1,1,1,0);

        for (int i = 0; i < _player.Hearts; i++)
             _hearts[i].color = new Color(1,1,1,1);
        
       
       
    }






}
