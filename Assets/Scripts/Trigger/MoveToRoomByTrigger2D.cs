using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRoomByTrigger2D : MonoBehaviour
{
    [SerializeField] string _room;
    [SerializeField] RoomRelocater _roomRelocator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _roomRelocator.MoveToRoom(_room);   
    }
}
