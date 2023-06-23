using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Knight : MonoBehaviour
{
    [SerializeField] private GameObject _portal;
    [SerializeField] private Animator _animator;
    [SerializeField] float _speed;

    private SpriteRenderer _spriteRenderer;
    private bool _portalIsOpen;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _portalIsOpen = false;
    }

    private void Update()
    {
        if (_portalIsOpen)
            transform.position = Vector2.MoveTowards(transform.position, _portal.transform.position, _speed * Time.deltaTime);
    }

    public void ButtonClick()
    {
       MoveToTeleport();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }

    private void MoveToTeleport()
    {
        if(_portal.transform.position.x < transform.position.x)
            _spriteRenderer.flipX = true;

        _portalIsOpen = true;
        _animator.Play("run_knight");
    }
}