using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private const string LEVELS_MENU = "LevelsMenu";
    [SerializeField] BlackScreen _blackScreen;
    private void Start()
    {
    }
    public void LoadScene(string sceneName)
    {
        _blackScreen.HadBlack += () => SceneManager.LoadScene(sceneName);
        _blackScreen.Show();
    }
    public void RestartScene()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadMainMenu()
    {
    }
    public void LoadLevelsMenu()
    {
        LoadScene(LEVELS_MENU);
    }
}
