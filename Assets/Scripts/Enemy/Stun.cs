using UnityEngine;
public class Stun : State
{
    [SerializeField] private float _exitTime;
    
    private float _remainingTime;
    private void Awake() => Initialize();
    public override void Enter() {_remainingTime = _exitTime;}

    public override void Exit() {}

    public override void UpdateState()
    {
        _remainingTime -= Time.deltaTime;
        if(_remainingTime <= 0)        
            _enemy.ChangeState(typeof(Patrolling));
        
       
    }
}
