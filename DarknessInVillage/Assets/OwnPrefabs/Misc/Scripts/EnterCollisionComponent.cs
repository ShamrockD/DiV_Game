using UnityEngine;
using UnityEngine.Events;
using System;

namespace UnviversalMechanics
{
    public class EnterCollisionComponent : MonoBehaviour
    {
        [SerializeField] private string _tagToLook;
        [SerializeField] private EnterColEvent _doAfterEntered;
        [SerializeField] private GameObject _gameObjectToInteract;

        private void OnCollisionEnter2D(Collision2D objectToCollide)
        {

            if (_gameObjectToInteract != null)
            {
                Debug.Log($"Collider2d with TAG {objectToCollide} FOUND");
            }

            else if (objectToCollide.gameObject.CompareTag(_tagToLook))
            {
                _doAfterEntered?.Invoke(objectToCollide.gameObject);
                Debug.Log($"Collider2d with TAG {objectToCollide} FOUND");
            }
        }
    }

    [Serializable]

    public class EnterColEvent : UnityEvent<GameObject>
    {

    }

}

