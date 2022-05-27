using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] SceneLoader _sceneLoader;
    public void Load(LevelData level)
    {
        _sceneLoader.LoadScene(level.SceneName);
    }
}
