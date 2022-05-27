using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Box : MonoBehaviour
{
    [SerializeField] ColorSide _side;
    [SerializeField] bool _onlyOneLight;
    
    private Rigidbody2D _rigidbody;
    private bool _active;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (_side == ColorSide.White || _side == ColorSide.Gray)
        {
            gameObject.layer = LayerHandler.GetExist();
        }
        else
        {
            gameObject.layer = LayerHandler.GetNoExist();
        }
    }

    public void EnterLight()
    {
        if (_side == ColorSide.Gray) return;
        if (_side == ColorSide.White)
        {
            gameObject.layer = LayerHandler.GetNoExist();
        }
        else
        {
            gameObject.layer = LayerHandler.GetExist();
        }
    }
    public void ExitLight()
    {
        if (_onlyOneLight || _side == ColorSide.Gray) return;
        if (_side == ColorSide.White)
        {
            gameObject.layer = LayerHandler.GetExist();
        }
        else
        {
            gameObject.layer = LayerHandler.GetNoExist();
        }
    }
}
