using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameLogic : MonoBehaviour
{
    [SerializeField] InputGetter _inputGetter;
    [SerializeField] PauseMenu _pauseMenu;
    private bool _isPause;

    //bad name
    public void PauseGame()
    {
        _isPause = !_isPause;
        UpdateStatus();
    }
   private void UpdateStatus()
    {
        if (_isPause)
        {
            _inputGetter.SetActive(false);
            _pauseMenu.Show();
        }
        else
        {
            _inputGetter.SetActive(true);
            _pauseMenu.Hide();
        }
    }
}
