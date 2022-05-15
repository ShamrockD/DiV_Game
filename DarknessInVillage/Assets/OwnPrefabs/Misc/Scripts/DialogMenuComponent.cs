using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class DialogMenuComponent : MonoBehaviour
{
    [SerializeField] private string[] _textRowsToShow;
    [SerializeField] private float _textCharTypingSpeed;
    [SerializeField] private UnityEvent _doWhenEnds;   
    [SerializeField] private float _timeToClose;

    private IEnumerator _coroutineForTexting;
    private IEnumerator _coroutineForTimer;
    private string _completeTextToShow;
    private int _index = 0;        
    private bool _coroutineisRunning = false;

    public TextMeshProUGUI textComponent;


    public void ShowDialog()
    {
        Debug.Log("Dialog was received");
        _coroutineForTexting = TypingLine(_textRowsToShow);
        _coroutineForTimer = TimerForComplete();
        if (_index == 0)
        {
            textComponent.text = string.Empty;
        }

        if (_index < _textRowsToShow.Length && !_coroutineisRunning)
        {
            StartCoroutine(_coroutineForTexting);
        }
        else if (_coroutineisRunning)
        {
            
            ClearMessageRules();
        }
        else if (_index == _textRowsToShow.Length)
        {
            textComponent.text = _completeTextToShow;
            ClearMessageRules();
            StartCoroutine(_coroutineForTimer);
        }

    }

    private void ClearMessageRules()
    {
        _completeTextToShow = string.Empty;
        _index = 0;
        _coroutineisRunning = false;
        StopAllCoroutines();
    }
        
    IEnumerator TypingLine(string[] fillingText)
    {
        if (!_coroutineisRunning)
        {
            _coroutineisRunning = true;
            foreach (char oneCharacterFromRow in fillingText[_index].ToCharArray())
            {
                textComponent.text += oneCharacterFromRow;
                yield return new WaitForSeconds(_textCharTypingSpeed);
            }
            textComponent.text += "\n";
        }
        _completeTextToShow += fillingText[_index] + "\n";
        _index++;
        _coroutineisRunning = false;
        ShowDialog();

    }

    private IEnumerator TimerForComplete()
    {
        float timer = _timeToClose;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            Debug.Log($"TIMER FOR CLOSING MENU {timer}");
            yield return null;
        }
        _doWhenEnds?.Invoke();
        yield break;
    }
}

