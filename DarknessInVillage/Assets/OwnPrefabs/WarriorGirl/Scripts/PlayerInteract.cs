using UnityEngine;


namespace PlayerComponents
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] private LayerMask _interActionCheck;
        [SerializeField] private float _interactRadius;

        private Collider2D[] _interactResult = new Collider2D[1];

        public void Interact()
        {
            var size = Physics2D.OverlapCircleNonAlloc(
                transform.position,
                _interactRadius,
                _interactResult,
                _interActionCheck);

            for (int i = 0; i < size; i++)
            {
                var interActable = _interactResult[i].GetComponent<InteractableComponent>();
                if (interActable != null)
                {
                    interActable.Interact();
                }
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, _interactRadius);
        }
    }
}

