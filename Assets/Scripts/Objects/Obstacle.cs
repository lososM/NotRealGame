using UnityEngine;

public class Obstacle : MonoBehaviour, ICoveredOutsideLight
{
    [SerializeField] bool _shouldWillHide;
    [SerializeField] GameObject _obstacle;
    [SerializeField] GameObject _shadow;
    private void Start()
    {
        if (!_shouldWillHide)
        {
            _obstacle.SetActive(false);
            _shadow.SetActive(true);
        }
        else
        {
            _obstacle.SetActive(true);
            _shadow.SetActive(false);
        }
    }
    public void Cover()
    {
        if (_shouldWillHide)
        {
            _obstacle.SetActive(false);
            _shadow.SetActive(true);
        }
        else
        {
            _obstacle.SetActive(true);
            _shadow.SetActive(false);
        }
    }
}
