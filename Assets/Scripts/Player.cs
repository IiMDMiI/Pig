using System;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Bomb _prefab;
    [SerializeField] private float _time;
    [SerializeField] private float _remainingTime;
    private int _hearts = 3;
    private InputController _inputController;
    public event Action OnHeratsAmountChanged;
    public int Hearts
    {
        get => _hearts;
        private set
        {
            _hearts = value;
            OnHeratsAmountChanged?.Invoke();
        }
    }

    public Node CurrentNode { get => (_grid.NodesList.OrderBy(n => Vector3.Distance(transform.position, n.transform.position)).ToList())[0]; }
    public Grid Grid => _grid;
    private Grid _grid;
    private Vector3 _startPosition;

    private void Start()
    {
        _grid = FindObjectOfType<Grid>();
        _inputController = FindObjectOfType<InputController>();
        _startPosition = transform.position;
    }
    private void Update() => _remainingTime -= Time.deltaTime;
    public void PlaceBomb()
    {
        if (_remainingTime > 0)
            return;
        _remainingTime = _time;
        var bomb = Instantiate(_prefab, CurrentNode.transform.position, Quaternion.identity);
        bomb.SetCurrentNode(CurrentNode);
    }

    public void GetDamage(int damage = 1)
    {
        Hearts -= damage;
        if (Hearts <= 0)
        {
            var enemies = FindObjectsOfType<Enemy>();
            foreach (var enemy in enemies)
                Destroy(enemy.gameObject);
            _inputController.enabled = false;
            gameObject.SetActive(false);
            Popup.Instance.ShowPopup();
        }

        else
        {
            var enemies = FindObjectsOfType<Enemy>();
            foreach (var enemy in enemies)
                enemy.Reset();

            transform.position = _startPosition;

        }
    }


}
