using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Portal : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("appear");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _animator.Play("disappear");
    }
}
