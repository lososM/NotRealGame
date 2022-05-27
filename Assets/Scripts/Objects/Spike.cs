using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Spike : MonoBehaviour
{
    [SerializeField] ColorSide _side;

    private Collider2D _collider;
    private bool _active;
    void Start()
    {
        _collider = GetComponent<Collider2D>();
        if (_side == ColorSide.White || _side == ColorSide.Gray)
        {
            _active = true;
        }
        else 
        {
            _active = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_active) return;
    
        var childComponents = collision.GetComponentsInChildren<IDamageble>();
        if (childComponents != null)
            foreach (var damageble in childComponents)
            {
                damageble.Damage();
            }
    }
    public void EnterLight()
    {
        if (_side == ColorSide.Gray) return;
        if(_side == ColorSide.White)
        {
            _active = false;
        }else
        {
            _active = true;
        }
        RestartCollider();
    }
    public void ExitLight()
    {
        if (_side == ColorSide.Gray) return;
        if (_side == ColorSide.Black)
        {
            _active = false;
        }
        else
        {
            _active = true;
        }
        RestartCollider();
    }
    private void RestartCollider()
    {
        _collider.enabled = false;
        _collider.enabled = true;
    }
}

