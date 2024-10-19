using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _runAnimationName;
    [SerializeField] private string _runAnimationShootName;
    [SerializeField] private string _idleAnimationName;
    [SerializeField] private string _idleAnimationShootName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (horizontal != 0 || vertical != 0)
        {
            if (Input.GetMouseButton(0))
            {
                _animator.Play(_runAnimationShootName);
            }
            else
            {
                _animator.Play(_runAnimationName);
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                _animator.Play(_idleAnimationShootName);
            }
            else
            {
                _animator.Play(_idleAnimationName);
            }
            
        }
    }
}
