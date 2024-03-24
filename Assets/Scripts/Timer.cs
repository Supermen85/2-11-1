using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _delay = 0.5f;

    private float _count = 0f;
    private bool _isPaused = true;

    private void Start()
    {
        _text.text = "0";
        StartCoroutine(Countdown());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ChangeStatus();
    }

    private void ChangeStatus()
    {
        if (_isPaused)
            _isPaused = false;
        else
            _isPaused = true;

    }

    private IEnumerator Countdown()
    {
        var wait = new WaitForSeconds(_delay);

        bool isRunning = true;
        
        while (isRunning)
        {
            if (_isPaused == false)
            {
                _text.text = _count.ToString();
                _count += 0.5f;
            }

            yield return wait;
        }
    }
}