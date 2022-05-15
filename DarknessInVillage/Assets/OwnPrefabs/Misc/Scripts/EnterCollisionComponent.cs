using UnityEngine;
using UnityEngine.Events;
using System;

namespace UnviversalMechanics
{
    public class EnterCollisionComponent : MonoBehaviour
    {
        [SerializeField] private string _tagToLook;
        [SerializeField] private EnterColEvent _doAfterEntered;

        private void OnCollisionEnter2D(Collision2D objectToCollide)
        {
            if (objectToCollide.gameObject.CompareTag(_tagToLook))
            {
                _doAfterEntered?.Invoke(objectToCollide.gameObject);
            }
        }
    }

    [Serializable]

    public class EnterColEvent : UnityEvent<GameObject>
    {

    }

}

