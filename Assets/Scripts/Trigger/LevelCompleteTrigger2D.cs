using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class LevelCompleteTrigger2D : MonoBehaviour
{
    [SerializeField] SceneLoader _sceneLoader;
    [SerializeField] LevelData _level;
    [SerializeField] LevelData _nextLevel;
    [SerializeField] float _delayLoadLevel;

    public UnityEvent CompleteLevelEvent;


    private bool _active;
    private bool _hadComplete;

    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_hadComplete) return;
        // safe progress
        LevelStatusSaver.SaveCompleteLevel(_level);
        if (_active)
        {
            CompleteLevelEvent.Invoke();
            _hadComplete = true;
            Invoke(nameof(LoadNextLevel), _delayLoadLevel);
        }
    }
    private void LoadNextLevel()
    {
        if (_nextLevel == null) _sceneLoader.LoadLevelsMenu();
        _sceneLoader.LoadScene(_nextLevel.SceneName);
    }
    public void EnterLight()
    {
        _active = true;
        RestartCollider();
    }

    private void RestartCollider()
    {
        _collider.enabled = false;
        _collider.enabled = true;
    }

    public void ExitLight()
    {
        _active = false;
        RestartCollider();
    }
}
