using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject _effectHitOnEnemy;
    [SerializeField] GameObject _effectHitOnMiss;
    [SerializeField] int _damage = 1;

    void Start()
    {

    }
    IEnumerator DeactivateBullet()
    {
        yield return new WaitForSecondsRealtime(5f);
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        StartCoroutine("DeactivateBullet");
    }

    private void OnDisable()
    {
        StopCoroutine("DeactivateBullet");
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Health enemy = other.transform.GetComponent<Health>();
    //    if (enemy)
    //    {
    //        Instantiate(_effectHitOnEnemy, transform.position, Quaternion.identity);
    //        enemy.TakeDamage(_damage);
    //    }
    //    else
    //    {
    //        Instantiate(_effectHitOnMiss, transform.position, Quaternion.identity);

    //    }
    //    gameObject.SetActive(false);
    //    StopCoroutine(DeactivateBullet());
    //}

    private void OnCollisionEnter(Collision collision)
    {
        Health enemy = collision.transform.GetComponent<Health>();
        if (enemy)
        {
            Instantiate(_effectHitOnEnemy, transform.position, Quaternion.identity);
            enemy.TakeDamage(_damage);
        }
        else
        {
            Instantiate(_effectHitOnMiss, transform.position, Quaternion.identity);

        }
        gameObject.SetActive(false);
    }
}
