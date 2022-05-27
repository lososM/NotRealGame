using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emotions : MonoBehaviour
{
    [SerializeField] SpriteRenderer _eyes;
    [SerializeField] Emotion _emotion;

    [Header("Sprites")]
    [SerializeField] Sprite _idle;
    [SerializeField] Sprite _wonder;
    [SerializeField] Sprite _sad;
    void Start()
    {
        
    }

    void Update()
    {
        SetEmotion(_emotion);
    }

    public void SetEmotion(Emotion emotion)
    {
        _emotion = emotion;

        switch (_emotion)
        {
            case Emotion.Idle:
                _eyes.sprite = _idle;
                break;
            case Emotion.Wonder:
                _eyes.sprite = _wonder;
                break;
            case Emotion.Sad:
                _eyes.sprite = _sad;
                break;
            default:
                _eyes.sprite = _idle;
                break;
        }
    }
    public void SetIdle()
    {
        SetEmotion(Emotion.Idle);
    }
    public void SetWonder()
    {
        SetEmotion(Emotion.Wonder);
    }
    public void SetSad()
    {
        SetEmotion(Emotion.Sad);
    }

}
public enum Emotion
{
    Idle,
    Wonder,
    Sad
}