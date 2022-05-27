using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoseLevel : MonoBehaviour, IDamageble
{
    [SerializeField] float _delayRestart;
    [SerializeField] Emotions _playerEmotions;
    [SerializeField] InputGetter _inputGetter;
    [SerializeField] SceneLoader _sceneLoader;
    public void Damage()
    {
        _playerEmotions.SetSad();
        _inputGetter.SetActive(false);
        Invoke(nameof(RestartLevel), _delayRestart);
    }
    public void RestartLevel() {
        _sceneLoader.RestartScene();
    }
}
