using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Vector2 _offset;
    [SerializeField] private float _rowOffset;
    [SerializeField] private int _width = 17;
    [SerializeField] private int _height = 9;
    

    private void Start()
    {           
        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                if(i % 2 != 0 && j % 2 != 0)
                    continue;
                var node = Instantiate(_prefab, new Vector3(_startPoint.position.x + _offset.x * j + _rowOffset * i, _startPoint.position.y - _offset.y * i, 0), Quaternion.identity);
                                           
            }
        }       
        
    }

   
   
}
