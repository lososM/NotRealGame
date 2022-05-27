using DG.Tweening;
using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFocus : MonoBehaviour
{
    public event Action StartFocusEvent = delegate { };
    public event Action CompleteFocusEvent = delegate { };
    [SerializeField] float _focusSize;
    [SerializeField] float _focusDuration;
    [SerializeField] float _overDuration;

    private Camera _camera;
    private Vector3 _lastPosition;
    private float _lastSize;
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    public void Focus(Transform target)
    {
        _lastPosition = transform.position;
        _lastSize = _camera.orthographicSize;

        transform.DOMoveX(target.position.x, _focusDuration);
        transform.DOMoveY(target.position.y, _focusDuration);
        _camera.DOOrthoSize(_focusSize, _focusDuration);

        Invoke(nameof(OverFocus), _focusDuration);

        StartFocusEvent.Invoke();
    }

    private void OverFocus()
    {
        transform.DOMoveX(_lastPosition.x, _overDuration);
        transform.DOMoveY(_lastPosition.y, _overDuration);
        _camera.DOOrthoSize(_lastSize, _overDuration);
        Invoke(nameof(CompleteFocus), _overDuration);
    }
    private void CompleteFocus()
    {
        CompleteFocusEvent.Invoke();
    }
}
