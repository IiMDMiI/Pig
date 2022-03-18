using UnityEngine;

public class DestractionTimer : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 1;    
    private void Update()
    {
        _lifeTime -= Time.deltaTime;
        if(_lifeTime <= 0)
            Destroy(gameObject);
    }
}
