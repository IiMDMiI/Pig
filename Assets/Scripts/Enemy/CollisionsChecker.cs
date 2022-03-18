using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CollisionsChecker : MonoBehaviour
{    
    private void OnTriggerEnter2D(Collider2D other)
    {   
        Player player = other.GetComponent<Player>();
        if(player != null)
            player.GetDamage();       
    }
}
