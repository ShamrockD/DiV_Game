using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int _healthPoints;
    [SerializeField] private UnityEvent _onDeacreaseHealthValue;
    [SerializeField] private UnityEvent _onIncreaseHealthValue;
    [SerializeField] private UnityEvent _onDie;

    public void HealthSetValue(int changingValue)
    {
        _healthPoints += changingValue;
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
