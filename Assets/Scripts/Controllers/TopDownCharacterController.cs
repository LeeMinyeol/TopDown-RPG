using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }



/*    [SerializeField] private float speed = 5f;
*/    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        HandleAttackDelay();

    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
    public void CalllookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }

    private void HandleAttackDelay()
    {
        if(_timeSinceLastAttack <= 0.2f)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }   
        if(IsAttacking && _timeSinceLastAttack > 0.2f)
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent();
        }
    }
}
