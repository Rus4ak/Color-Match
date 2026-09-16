using System;
using System.Collections;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private int _duration;

    private int _remainingTime;

    public event Action TimeChanged;
    public event Action TimerEnded;
    public int RemainingTime => _remainingTime;

    private void Start()
    {
        _remainingTime = _duration;

        StartCoroutine(Countdown());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Countdown()
    {
        while (_remainingTime > 0)
        {
            yield return new WaitForSeconds(1);

            _remainingTime--;
            TimeChanged?.Invoke();
        }

        TimerEnded?.Invoke();
    }
}
