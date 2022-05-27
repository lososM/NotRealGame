using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using System;

public class RoomRelocater : MonoBehaviour
{
    [SerializeField] float _moveDuration;
    [SerializeField] Transform _roomsParent;
    public UnityEvent RelocateEvent;
    private Transform _cameraPoint;
    private bool _isMoving;
    private Vector3 velocity;
    public void MoveToRoom(string roomName)
    {
        var cameraPoint = _roomsParent.Find(roomName).Find("CameraPoint");
        _cameraPoint = cameraPoint;
        transform.DOMoveX(_cameraPoint.position.x, _moveDuration);
        transform.DOMoveY(_cameraPoint.position.y, _moveDuration);
        Invoke(nameof(CompleteRelocate), _moveDuration);
    }

    private void CompleteRelocate()
    {
        RelocateEvent.Invoke();

    }
}
