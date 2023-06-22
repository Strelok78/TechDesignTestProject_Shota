using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Knight : MonoBehaviour
{
    [SerializeField] GameObject _portal;
    [SerializeField] float _speed;

    private Animator _animator;
    private bool _portalIsOpen;

    private void Start()
    {
        _animator = GetComponent<Animator>();
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

    public void MoveToTeleport()
    {
        _portalIsOpen = true;
        _animator.Play("run");
    }
}