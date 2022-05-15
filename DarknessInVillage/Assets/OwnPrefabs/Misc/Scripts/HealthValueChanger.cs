using UnityEngine;
using UnityEngine.Events;


namespace UnviversalMechanics
{
    public class HealthValueChanger : MonoBehaviour
    {
        [SerializeField] private int _valueToChangeHealth;

        public void ChangeHealthValue(GameObject targetWithHP)
        {
            //var HealthPoints = gameObject.GetComponent<HealthComponent>();
            var HealthPoints = targetWithHP.GetComponent<HealthComponent>();
            if (HealthPoints != null)
            {
                HealthPoints.HealthSetValue(_valueToChangeHealth);
            }
        }
    }
}

