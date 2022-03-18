using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class OrderInLayerController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private IChangeNodes[] _iChangeNodes;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _iChangeNodes = GetComponents<IChangeNodes>();
        foreach (var i in _iChangeNodes)
            i.OnCurrentNodeChanged += OnCurrentNodeChangedHandler;
    }
    
    private void OnDisable()
    {
        if(_iChangeNodes == null || _iChangeNodes.Length == 0)
            return;
        foreach (var i in _iChangeNodes)
            i.OnCurrentNodeChanged -= OnCurrentNodeChangedHandler;
    }
    private void OnCurrentNodeChangedHandler(Node node)
    {
        _spriteRenderer.sortingOrder = (int)node.Index.y % 2 == 0 ? (int)node.Index.y : (int)node.Index.y + 1;
    }




}
