using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Goblin : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        _audioSource.Play();
        _animator.Play("death_goblin");
    }

    public void Dead()
    {
        GameObject.Destroy(gameObject);
    }
}
