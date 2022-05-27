using System;
using UnityEngine;

public class DetectEnterTrigger2D : MonoBehaviour
{
    public event Action<Collider2D> HaveContact = delegate { };
    public event Action<Collider2D> LoseContact = delegate { };

    public event Action<Collider2D> HaveObject = delegate { };
    public event Action<Collider2D> LoseObject = delegate { };

    private int _countContacts;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HaveObject.Invoke(collision);
        if (_countContacts == 0) HaveContact.Invoke(collision);
        _countContacts++;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        LoseObject.Invoke(collision);
        _countContacts--;
        if (_countContacts == 0) LoseContact.Invoke(collision);
    }
}
