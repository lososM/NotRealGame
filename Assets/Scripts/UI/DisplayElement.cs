using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DisplayElement : MonoBehaviour
{
    [SerializeField] bool _showByDelay;
    [SerializeField] float _delayShow;

    [SerializeField] bool _hideAfter;
    [SerializeField] float _delayHide;

    private Animator _animator;
    private float _time;

    private Action _timeAction;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("Hide");
        if (_showByDelay)
        {
            _timeAction = ShowElement;
            _time = _delayShow;
        }
    }

    void Update()
    {
        if (_time < 0)
        {
            _time = 0;
            if (_timeAction != null) _timeAction.Invoke();
        }
        else if(_time > 0)
        {
            _time -= Time.deltaTime;
        }
    }
    public void ShowElement()
    {
        _animator.SetTrigger("Show");

        if (_hideAfter)
        {
            _time = _delayHide;
            _timeAction = HideElement;
        }
    }

    public void HideElement()
    {
        _animator.SetTrigger("Hide");
    }
}
