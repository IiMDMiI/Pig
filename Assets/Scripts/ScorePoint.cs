using UnityEngine;

[RequireComponent(typeof(AlphaChanger)), RequireComponent(typeof(AudioSource))]
public class ScorePoint : MonoBehaviour
{
    private AlphaChanger _alphaChanger;    
    private AudioSource _audioSource; 
    private bool _wasActivated;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _alphaChanger = GetComponent<AlphaChanger>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {   
        if(_wasActivated == true)
            return;

        _audioSource.Play();
        _alphaChanger.SetState(AlphaChanger.Animation.Hide);
        Score.Instance.AddScorePoints(1);
        _wasActivated = true;

    }
}
