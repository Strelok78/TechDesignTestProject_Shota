using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SpriteRenderer))]
public class Wizard : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Transform _runPoint;

    private Animator _animator;
    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;
    private bool isClicked = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isClicked)
            transform.position = Vector2.MoveTowards(transform.position, _runPoint.position, _speed * Time.deltaTime);

        if (transform.position.x == _runPoint.position.x)
            Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        RunAway();
    }

    public void RunAway()
    {
        _audioSource.Play();
        isClicked = true;
        _spriteRenderer.flipX = false;
        _animator.Play("run_wizard");
    }
}
