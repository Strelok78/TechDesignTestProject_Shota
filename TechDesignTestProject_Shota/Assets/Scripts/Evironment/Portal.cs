using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class Portal : MonoBehaviour
{
    private Animator _animator;
    private static int _sceneIndex = 0;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _animator.Play("portal_disappear");
    }

    public void LoadScene()
    {
        _sceneIndex++;

        if (_sceneIndex > 1)
        {
            _sceneIndex = 0;
        }

        SceneManager.LoadScene(_sceneIndex, LoadSceneMode.Single);
    }
}
