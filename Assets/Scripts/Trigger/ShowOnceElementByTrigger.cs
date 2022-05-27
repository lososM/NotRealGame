using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnceElementByTrigger : MonoBehaviour
{
    [SerializeField] DisplayElement _displayElement;
    private bool _hadShow;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_hadShow)
        {
            _displayElement.ShowElement();
            _hadShow = true;
        }
        
    }
}
