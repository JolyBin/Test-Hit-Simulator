using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Waypoint : MonoBehaviour
{
    [SerializeField] UnityEvent _onAllEnemyDieEvent;
    [SerializeField] List<Health> _enemyArray;


    private void Start()
    {
        foreach (Health enemy in _enemyArray)
        {
            enemy.OnDieEvent.AddListener(DieEnemy);
        }
    }

    private void DieEnemy(Health enemy)
    {
        _enemyArray.Remove(enemy);
        if(_enemyArray.Count <= 0)
        {
            _onAllEnemyDieEvent.Invoke();
        }
    }

}
