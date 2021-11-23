using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class ControlAnimator : MonoBehaviour
{
    public Animator _anim;

    private bool invokeIKHand = false;

    public CapsuleCollider capsuleCollider;

    public Transform head;
    public Transform cube;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider capsuleCollider)
    {
        if (capsuleCollider.tag == "Work_2&3")
        {
            invokeIKHand = true;
        }
    }

    private void OnTriggerExit(Collider capsuleCollider)
    {
        if (capsuleCollider.tag == "Work_2&3")
        {
            invokeIKHand = false;
        }
    }


    private void OnAnimatorIK()
    {

        if (invokeIKHand)
        {
            _anim.SetLookAtWeight(1);
            _anim.SetLookAtPosition(head.position);
        }
        else
        {
            _anim.SetLookAtWeight(0);
        }

        if (invokeIKHand)
        {
            _anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            _anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            _anim.SetIKPosition(AvatarIKGoal.RightHand, cube.position);
            _anim.SetIKRotation(AvatarIKGoal.RightHand, cube.rotation);

            _anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            _anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            _anim.SetIKPosition(AvatarIKGoal.LeftHand, cube.position);
            _anim.SetIKRotation(AvatarIKGoal.LeftHand, cube.rotation);
        }
        else 
        {
            _anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);

            _anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
        }
    }
}
