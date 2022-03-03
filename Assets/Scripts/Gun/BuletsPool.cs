using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuletsPool : MonoBehaviour
{
    [SerializeField] int _poolCount = 5;
    [SerializeField] bool _isAutoExpand = true;
    [SerializeField] Bullet _bulletPrefab;

    public Pool<Bullet> Pool;

    private void Start()
    {
        Pool = new Pool<Bullet>(_bulletPrefab, transform, _poolCount, _isAutoExpand);
    }
}
