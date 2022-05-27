using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetToMouse : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] float _smoothTime;
    [Header("Horizontal")]
    [SerializeField] bool _hadInvertX; //if _maxX<_minX
    [SerializeField] float _maxX;//subtract default position in inspector
    [SerializeField] float _minX;
    [SerializeField] float _maxXMouse;

    [Header("Vertical")]
    [SerializeField] bool _hadInvertY; //if _maxY<_minY
    [SerializeField] float _maxY;//subtract default position in inspector
    [SerializeField] float _minY;
    [SerializeField] float _maxYMouse;

    private float _oneXEyesPerMouse;
    private float _oneYEyesPerMouse;
    private Vector3 _defaultPos;
    private Vector3 _velocity;

    void Start()
    {
        _defaultPos = transform.localPosition;
        _oneXEyesPerMouse = _maxXMouse / _maxX;
        _oneYEyesPerMouse = _maxYMouse / _maxY;
    }

    void Update()
    {
        var mouse = Camera.main.ScreenToWorldPoint(InputGetter.MousePotition) - transform.position;
        var x = mouse.x / _oneXEyesPerMouse;
        if (_hadInvertX)
        {
            x = Mathf.Min(x, _minX);
            x = Mathf.Max(_maxX, x);
        }
        else
        {
            x = Mathf.Min(x, _maxX);
            x = Mathf.Max(_minX, x);
        }

        var y = mouse.y / _oneYEyesPerMouse;
        y = Mathf.Min(y, _maxY);
        y = Mathf.Max(_minY, y);

        transform.localPosition = 
            Vector3.SmoothDamp(transform.localPosition,
            new Vector3(_defaultPos.x + x, _defaultPos.y + y), 
            ref _velocity,
            _smoothTime);
    }
}
