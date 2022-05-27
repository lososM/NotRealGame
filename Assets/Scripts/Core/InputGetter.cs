using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputGetter : MonoBehaviour
{
    public static event Action ToggleLight = delegate { };
    public static event Action JumpEvent = delegate { };
    public static event Action<float> Horizontal = delegate { };
    public UnityEvent Restart;
    public UnityEvent Pause;

    public static Vector3 MousePotition { get; private set; }
    private bool _active;

    private void Awake()
    {
        _active = true;
    }
    void Update()
    {
        if (_active)
        {
            Horizontal.Invoke(Input.GetAxis("Horizontal"));
            MousePotition = Input.mousePosition;
            if (Input.GetKeyDown(KeyCode.Space)) JumpEvent.Invoke();
            if (Input.GetKeyDown(KeyCode.Mouse0)) ToggleLight.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.R)) Restart.Invoke();
        if (Input.GetKeyDown(KeyCode.Escape)) Pause.Invoke();
    }
    public void SetActive(bool status)
    {
        _active = status;
        Horizontal.Invoke(0);
    }
    public void OnDestroy()
    {
        ToggleLight = delegate { };
        JumpEvent = delegate { };
        Horizontal = delegate { };
    }
}
