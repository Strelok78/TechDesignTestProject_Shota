using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Patrol : MonoBehaviour
{
    [SerializeField] Transform _path;
    [SerializeField] float speed;

    private SpriteRenderer _spriteRenderer;
    private Transform[] _points;
    private int _current_point_index;
    private bool _isPatroling = true;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        if(_isPatroling)
        {
            Transform target_point = _points[_current_point_index];

            transform.position = Vector2.MoveTowards(transform.position, target_point.position, speed * Time.deltaTime);

            if (transform.position == target_point.position)
            {
                _current_point_index++;
                _spriteRenderer.flipX = false;

                if (_current_point_index >= _points.Length)
                {
                    _current_point_index = 0;
                    _spriteRenderer.flipX = true;
                }
            }
        }
    }

    public void StopMovement()
    {
        _isPatroling = false;
        _spriteRenderer.flipX = true;
    }
}