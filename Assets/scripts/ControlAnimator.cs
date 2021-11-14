using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class ControlAnimator : MonoBehaviour
{
    public Animator _anim;
    public bool invokeIKHead = false;
    public bool invokeIKHand = false;
    public Transform head;
    public Transform cube;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnAnimatorIK()
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
