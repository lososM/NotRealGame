using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeFlashlightTrigger2D : MonoBehaviour
{
    public UnityEvent StartTakeEvent;
    public UnityEvent HadTakeEvent;
    [SerializeField] CameraFocus _cameraFocus;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartTakeEvent.Invoke();
        _cameraFocus.Focus(transform);
        _cameraFocus.CompleteFocusEvent += CompleteTaking;
    }
    public void CompleteTaking()
    {
        HadTakeEvent.Invoke();
        gameObject.SetActive(false);
    }
}
