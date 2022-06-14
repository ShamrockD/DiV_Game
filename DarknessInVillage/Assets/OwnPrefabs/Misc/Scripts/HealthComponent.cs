using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float _healthPoints;
    [SerializeField] private float _maxHealth;
    [SerializeField] private HealthBarComponent _updateHealthBarComponent;
    [SerializeField] private TextMeshProUGUI _textBoxToShowHealth;
    [SerializeField] private UnityEvent _onDeacreaseHealthValue;
    [SerializeField] private UnityEvent _onIncreaseHealthValue;
    [SerializeField] private UnityEvent _onDie;


    private void OnBecameVisible()
    {
        if (_textBoxToShowHealth != null)
        {
            _textBoxToShowHealth.text = _healthPoints.ToString();
        }
    }


    public void HealthSetValue(int changingValue)
    {
        bool barAndTextHPComponentCheck = (_updateHealthBarComponent != null && _textBoxToShowHealth != null);

        bool checkIfCanHeal = ((_healthPoints + changingValue) <= _maxHealth);

        if (checkIfCanHeal)
        {
            _healthPoints += changingValue;
        }
        
        if (barAndTextHPComponentCheck)
        {
            HealthBarUpdate();
        }

        if (_textBoxToShowHealth != null && checkIfCanHeal)
        {
            _textBoxToShowHealth.text = _healthPoints.ToString();
        }
        
        if (_healthPoints <= 0 && checkIfCanHeal)
        {
            _onDie?.Invoke();
        }

        if (changingValue > 0 && barAndTextHPComponentCheck && checkIfCanHeal)
        {
            _onIncreaseHealthValue?.Invoke();
        }

        else if (changingValue < 0 && barAndTextHPComponentCheck && checkIfCanHeal)
        {
            _onDeacreaseHealthValue?.Invoke();
        }      
        
    }

    private void HealthBarUpdate()
    {
        float hppercentage = _healthPoints / _maxHealth;
        Debug.Log($"VALUE THAT WE WHANT {hppercentage}");
        float valueHPBar = Mathf.Clamp(hppercentage, 0, 1f);
        Debug.Log($"VALUE THAT WE NEED {valueHPBar}");
        _updateHealthBarComponent.UpdateHealthBar(valueHPBar);
    }
}
