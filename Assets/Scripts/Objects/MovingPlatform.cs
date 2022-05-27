using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] Animator _animPoint;
    [SerializeField] DetectEnterTrigger2D _detectTrigger;
    [SerializeField] LineRenderer _way;

    [SerializeField] float _duration = 5;
    [SerializeField] float _delayReturn = 0;
    private bool _active;
    private bool _shouldMove;

    private int _curPoint;
    private bool _goindBack;
    void Start()
    {
        _detectTrigger.HaveContact += MoveForward;
        _detectTrigger.LoseContact += MoveBack;

        _detectTrigger.HaveObject += AttachObject;
        _detectTrigger.LoseObject += DisattachObject;

        _detectTrigger.gameObject.SetActive(false);
    }

    private void AttachObject(Collider2D obj)
    {
        obj.transform.parent = transform;
    }
    private void DisattachObject(Collider2D obj)
    {
        obj.transform.parent = null;

    }
    private void MoveForward(Collider2D obj)
    {
        transform.DOKill();
        CancelInvoke();
        _goindBack = false;
        if (_curPoint < _way.positionCount - 1)
        {
            _curPoint++;
          
            Invoke(nameof(MoveNextForward), _duration);
        }
        transform.DOMove(GetPosition(), _duration);
        _animPoint.SetTrigger("Show");
    }

    private void MoveNextForward()
    {
        transform.DOKill();
        CancelInvoke();
        _goindBack = false;
        if (_curPoint < _way.positionCount - 1)
        {
            _curPoint++;

            Invoke(nameof(MoveNextForward), _duration);
        }
        GetPosition();

        transform.DOMove(GetPosition(), _duration);

    }

    private Vector3 GetPosition()
    {
        var vec = _way.GetPosition(_curPoint);
        vec.z = transform.position.z;
        return vec;
    }

    private void MoveBack(Collider2D obj)
    {
        Invoke(nameof(MoveNextBack), _delayReturn);
        _animPoint.SetTrigger("Hide");
    }

    private void MoveNextBack()
    {
        transform.DOKill();
        CancelInvoke();
        _goindBack = true;
        if (_curPoint > 0)
        {
            _curPoint--;
            Invoke(nameof(MoveNextBack), _duration);
        }
        transform.DOMove(GetPosition(), _duration);
    }

    public void EnterLight()
    {
        if (!_active)
        {
            _active = true;
            _animator.SetTrigger("Show");
            tag = TagHandler.DEFAULT;
            gameObject.layer = LayerHandler.GetExist();
            _detectTrigger.gameObject.SetActive(true);
        }
    }
    public void ExitLight()
    {
        if (_active)
        {
            _active = false;
            _animator.SetTrigger("Hide");
            tag = TagHandler.TRANSPARENT;
            gameObject.layer = LayerHandler.GetNoExist();
            if(!_goindBack)
                Invoke(nameof(MoveNextBack), _delayReturn);
            _detectTrigger.gameObject.SetActive(false);
        }
    }
    public void ResetToZeroDelay()
    {
        _delayReturn = 0;
    }
}
