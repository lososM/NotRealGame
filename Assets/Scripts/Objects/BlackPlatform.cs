using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//remake to platfarm that can switch to black/white
[RequireComponent(typeof(Animator))]
public class BlackPlatform : MonoBehaviour
{
    private Animator _animator;
    private Collider2D _collider;

    private bool _active;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
    }

    public void EnterLight()
    {
        if (!_active){
            _active = true;
            _animator.SetTrigger("Show");
            _collider.isTrigger = false;//not sure that it need
            tag = TagHandler.DEFAULT;
            gameObject.layer = LayerHandler.GetExist();
        }
    }
    public void ExitLight()
    {
        if (_active)
        {
            _active = false;
            _animator.SetTrigger("Hide");
            _collider.isTrigger = true;
            tag = TagHandler.TRANSPARENT;
            gameObject.layer = LayerHandler.GetNoExist();
        }
    }
}
