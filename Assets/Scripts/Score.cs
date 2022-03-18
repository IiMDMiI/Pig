using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Score : MonoBehaviour
{   
    public static Score Instance;
    private TextMeshProUGUI _scoreText;
    private int _scorePoints;
    private int _maxAmount = 121;
    private void Start() 
    {
        Instance = this;
        _scoreText = GetComponent<TextMeshProUGUI>();
    }
    public void AddScorePoints(int points)
    {
        _scorePoints += points;
        _scoreText.text = _scorePoints.ToString();
        if(_scorePoints == _maxAmount)
        {
            var enemies = FindObjectsOfType<Enemy>();
            foreach (var enemy in enemies)
                Destroy(enemy.gameObject);
            Popup.Instance.ShowPopup();           
        }
    }
}
