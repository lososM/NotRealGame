using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    [SerializeField] bool _haveFlashlight;
    [SerializeField] bool _active;
    [SerializeField] List<Flashlight2D> _flashlight2Ds;
    void Start()
    {
        UpdateStatus();
        InputGetter.ToggleLight += ToggleLight;
    }
   
    public void ToggleLight()
    {
        if (_haveFlashlight)
        {
            _active = !_active;
            UpdateStatus();
        }
    }
    private void UpdateStatus()
    {
        foreach (var item in _flashlight2Ds)
        {
            item.SetStatus(_active);
        }
    }
    public void TakeFlashlight()
    {
        _haveFlashlight = true;
        _active = true;
        UpdateStatus();
    }
}
