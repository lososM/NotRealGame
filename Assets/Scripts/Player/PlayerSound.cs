using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSound : MonoBehaviour, IDamageble
{
    [SerializeField] AudioClip _jumpClip;
    [SerializeField] AudioClip _failClip;
    [SerializeField] AudioClip _toggleLightClip;
    private AudioSource _audioSource;

    public void Damage()
    {
        _audioSource.PlayOneShot(_failClip);
    }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        InputGetter.JumpEvent += () => { _audioSource.PlayOneShot(_jumpClip); };//bug: if player click many times
        InputGetter.ToggleLight += () => { _audioSource.PlayOneShot(_toggleLightClip); };//bug: if player havn't flashlight
        
    }
}
