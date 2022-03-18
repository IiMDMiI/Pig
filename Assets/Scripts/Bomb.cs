using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private int _attackDistance;
    [SerializeField] private ParticleSystem _explosionPrefab;
    
    private Node _currentNode;
    public void SetCurrentNode(Node node)
    {
        _currentNode = node;
    }
    private void Update()
    {
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0)
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            var enemies = FindObjectsOfType<Enemy>();
            foreach (var enemy in enemies)
            {
               if(enemy.CurrentNode.Index.x == _currentNode.Index.x)
               {
                   if(Mathf.Abs(enemy.CurrentNode.Index.y - _currentNode.Index.y) <= _attackDistance)
                        enemy.ChangeState(typeof(Stun));
               }  
               if(enemy.CurrentNode.Index.y == _currentNode.Index.y)
               {
                   if(Mathf.Abs(enemy.CurrentNode.Index.x - _currentNode.Index.x) <= _attackDistance)
                        enemy.ChangeState(typeof(Stun));
               }  
            }
            Vibrator.Vibrate(500);
            Destroy(gameObject);
        }

    }


}
