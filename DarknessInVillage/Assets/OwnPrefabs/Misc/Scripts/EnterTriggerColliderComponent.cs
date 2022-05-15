using UnityEngine;
using UnityEngine.Events;


namespace UnviversalMechanics
{
    public class EnterTriggerColliderComponent : MonoBehaviour
    {
        [SerializeField] private EnterColEvent _whatToDoWhenEnter;
        [SerializeField] private string _tagOfObjectWeLook;
        [SerializeField] private GameObject _gameObjectToInteract;

        private void OnTriggerEnter2D(Collider2D objectWithTriggerCollision)
        {
            if (_gameObjectToInteract != null)
            {
                _whatToDoWhenEnter?.Invoke(objectWithTriggerCollision.gameObject);
                Debug.Log($"GameObject entered trigger {_gameObjectToInteract}");
            }
            else if (objectWithTriggerCollision.gameObject.CompareTag(_tagOfObjectWeLook))
            {
                _whatToDoWhenEnter?.Invoke(objectWithTriggerCollision.gameObject);
                Debug.Log($"GameObject with TAG {_tagOfObjectWeLook} entered trigger");
            }
        }

    }
}

