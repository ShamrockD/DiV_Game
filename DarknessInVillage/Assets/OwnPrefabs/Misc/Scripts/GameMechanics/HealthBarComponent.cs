using UnityEngine;
using UnityEngine.UI;

public class HealthBarComponent : MonoBehaviour
{
    [SerializeField] private Image _healthBarImage;
    [SerializeField] private HealthComponent _healthComponent;
    public void UpdateHealthBar(float ValueOfHPBarFill)
    {
        _healthBarImage.fillAmount = ValueOfHPBarFill;
    }
}
