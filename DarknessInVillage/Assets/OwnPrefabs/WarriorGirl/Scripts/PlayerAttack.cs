using UnityEngine;
using UnityEngine.Events;

namespace PlayerComponents
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField ]private UnityEvent _onAttack;
        private Animator _playerAnimator;

        private static readonly int _isLightAttacking = Animator.StringToHash("wgLightAttacking");
        
        public void PlayerAttacking()
        {
            _playerAnimator = GetComponent<Animator>();
            _playerAnimator.SetTrigger(_isLightAttacking);
            _onAttack?.Invoke();
        }

        
    }
}


