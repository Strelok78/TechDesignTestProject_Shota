using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SpriteRenderer))]
public class Wizard : MonoBehaviour
{
    [SerializeField] float _speed;

    private Animator _animator;
    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;
    private bool _knightTeleports = false;
    private float _runDirection;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _runDirection = transform.forward.x;
    }

    private void Update()
    {
        if (_knightTeleports)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(_runDirection, transform.position.y), _speed * Time.deltaTime);
    }

    public void RunAway()
    {
        _animator.Play("run_wizard");
        _knightTeleports = true;
        _spriteRenderer.flipX = false;
        _audioSource.Play();
    }
}
