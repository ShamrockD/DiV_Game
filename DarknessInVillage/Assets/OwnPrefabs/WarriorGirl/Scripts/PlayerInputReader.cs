using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerComponents
{
    public class PlayerInputReader : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovementScript;
        [SerializeField] private PlayerInteract _playerInteractionScript;
        [SerializeField] private PlayerAttack _playerAttackingScript;

        public void OnMovement(InputAction.CallbackContext contextOfMovement)
        {
            var _direction = contextOfMovement.ReadValue<Vector2>();
            _playerMovementScript.SetDirectionMove(_direction);
        }

        public void OnInteract(InputAction.CallbackContext contextOfInteract)
        {
            if (contextOfInteract.canceled)
            {
                Debug.Log("Canceled");
                _playerInteractionScript.Interact();
            }
        }

        public void OnAttack(InputAction.CallbackContext contextOfAttack)
        {
            if (contextOfAttack.canceled)
            {
                Debug.Log("Pressed button for Attack");
                _playerAttackingScript?.PlayerAttacking();
            }
        }
    }
}

