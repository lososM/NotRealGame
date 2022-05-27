using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class OutsideLightObj : MonoBehaviour
{
    public UnityEvent HaveLoad;

    private bool _isLoad;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void StartLoad()
    {
        if (_isLoad) return;
        _animator.SetTrigger("StartLoad");
    }
    public void CloseLoad()
    {
        if (_isLoad) return;
        _animator.SetTrigger("CloseLoad");
    }

    public void CompleteLoad()
    {
        _isLoad = true;
        gameObject.layer = LayerHandler.GetDefault();
        transform.position -= Vector3.forward;
        HaveLoad.Invoke();
    }
}
