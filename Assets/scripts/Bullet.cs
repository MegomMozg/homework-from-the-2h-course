using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private float _damage;
    private float _speed;
    public GameObject Light;
    private Transform _target;
    private Rigidbody _rb;
    private Vector3 _targetposition;

    public void Initialization(float damage, float lifeTime, float speed, Transform target)
    {
        _rb = GetComponent<Rigidbody>();
        _speed = speed;
        _target = target;
        _targetposition = _target.position;
        _damage = damage;
        Destroy(this.gameObject, lifeTime);
        _rb.AddForce(transform.forward * _speed, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Light.SetActive(true);
        StartCoroutine(cooldawn());
    }
    private IEnumerator cooldawn()
    {
        yield return new WaitForSeconds(0.2f);
        Light.SetActive(false);
    }
}
