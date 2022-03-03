using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] BuletsPool _bulletsPool;
    [SerializeField] float _bulletSpeed = 15;
    [SerializeField] float _shotPeriod = 1f;
    [SerializeField] AudioSource _shotSound;

    Camera _mainCamera;
    float _timer;

    private void Start()
    {
        _mainCamera = Camera.main;
    }


    void Update()
    {
        _timer += Time.unscaledDeltaTime;
        if (Input.GetMouseButtonDown(0) && _timer > _shotPeriod)
        {
            _timer = 0; 
            Shoot();
        }
    }

    public virtual void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Bullet bullet = _bulletsPool.Pool.GetFreeElement();
        bullet.transform.position = ray.origin;
        bullet.GetComponent<Rigidbody>().velocity = ray.direction * _bulletSpeed;
        _shotSound.Play();
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
