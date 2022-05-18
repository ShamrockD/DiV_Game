using UnityEngine;


namespace UnviversalMechanics
{
    public class HealthValueChanger : MonoBehaviour
    {
        [SerializeField] private int _valueToChangeHealth;

        public void ChangeHealthValue(GameObject targetWithHP)
        {
            var HealthPoints = targetWithHP.GetComponent<HealthComponent>();
            if (HealthPoints != null)
            {
                HealthPoints.HealthSetValue(_valueToChangeHealth);
            }
        }
    }
}

