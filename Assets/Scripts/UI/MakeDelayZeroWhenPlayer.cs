using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDelayZeroWhenPlayer : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] DetectEnterTrigger2D _detect;
    [SerializeField] MovingPlatform _movingPlatform;
    void Start()
    {
        _detect.HaveObject += DetectPlayer;
    }

    private void DetectPlayer(Collider2D obj)
    {
        if (_player == obj.transform) ChangeDelayToZero();
    }

    private void ChangeDelayToZero()
    {
        _movingPlatform.ResetToZeroDelay();
        _detect.HaveObject -= DetectPlayer;
    }

}
