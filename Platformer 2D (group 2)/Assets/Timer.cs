using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timerDuration;
    [SerializeField] private Button timerButton;
    private int _resourceCount;
    private float _currentTime;
    private bool _isTimerOn;
    void Start()
    {
        //_currentTime = timerDuration;
        timerButton.onClick.AddListener(TurnOnTimer);
    }

    void Update()
    {
        UpdateTimer();
    }

    private void TurnOnTimer()
    {
        _isTimerOn = true;
    }

    private void UpdateTimer()
    {
        if (_isTimerOn)
        {
            if (_currentTime <= 0)
            {
                _currentTime = timerDuration;
                _resourceCount++;
                _isTimerOn = false;
                Debug.Log(_resourceCount);
            }
            else
            {
                _currentTime -= Time.deltaTime;
            }
        }
    }
}
