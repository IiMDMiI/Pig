using UnityEngine;
public abstract class State : MonoBehaviour
{   
    protected Enemy _enemy;
    public abstract void Enter();
    public abstract void UpdateState(); 
    public abstract void Exit();        
    protected void Initialize() {_enemy = GetComponent<Enemy>();}
}
