using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int HealthPoints = 5;
    
    public UnityEvent<Health> OnDieEvent;
    public UnityEvent<Health> OnTakeDamageEvent;

    public void TakeDamage(int value)
    {
        HealthPoints -= value;
        if(HealthPoints <= 0)
        {
            OnDieEvent.Invoke(this);
        }
        else
        {
            OnTakeDamageEvent.Invoke(this);
        }
    }
}
