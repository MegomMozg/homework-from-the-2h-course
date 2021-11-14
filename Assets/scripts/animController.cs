using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animController : MonoBehaviour
{
    public Rigidbody rb_AR;
    public bool invokeIK = false;
    public CapsuleCollider capsuleCollider;
    public Transform head;
    public Animator _anim;
    private void Awake()
    {
        rb_AR = GetComponentInChildren<Rigidbody>();
    }
    void Start()
    {
        

    }
    private void Update()
    {
        
        rb_AR.isKinematic = true;
        
    }

    // Update is called once per frame
    void OnAnimatorIK()
    {
        if (invokeIK)
        {
            _anim.SetLookAtWeight(1);
            _anim.SetLookAtPosition(head.position);
        }
        else
        {
            _anim.SetLookAtWeight(0);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Ragdoll_on();
        }
    }
    void Ragdoll_on()
    {
        rb_AR.isKinematic = false;
        _anim.enabled = false;
    }
}
