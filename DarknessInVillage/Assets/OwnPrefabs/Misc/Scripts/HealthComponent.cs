using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int _healthPoints;
    [SerializeField] private TextMeshProUGUI _textBoxToShowHealth;
    [SerializeField] private UnityEvent _onDeacreaseHealthValue;
    [SerializeField] private UnityEvent _onIncreaseHealthValue;
    [SerializeField] private UnityEvent _onDie;
    //[SerializeField] private UnityEvent _showHealthNums;

    private void Awake()
    {
        if (_textBoxToShowHealth != null)
        {
            _textBoxToShowHealth.text = _healthPoints.ToString();
        }
    }


    public void HealthSetValue(int changingValue)
    {
        _healthPoints += changingValue;
        if (_textBoxToShowHealth != null)
        {
            _textBoxToShowHealth.text = _healthPoints.ToString();
        }
        
        if (_healthPoints <= 0)
        {
            _onDie?.Invoke();
        }

        if (changingValue > 0)
        {
            _onIncreaseHealthValue?.Invoke();
        }
        else if (changingValue < 0)
        {
            _onDeacreaseHealthValue?.Invoke();
        }      
        
    }
}
