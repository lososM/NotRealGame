using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BlackScreen : MonoBehaviour
{
    public event Action HadBlack = delegate { };

    private Animator _animator;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("Hide");
    }
    public void Show()
    {
        _animator.SetTrigger("Show");
    }
    public void CompleteBlack()
    {
        HadBlack.Invoke();
        HadBlack = delegate { };
    }
}
