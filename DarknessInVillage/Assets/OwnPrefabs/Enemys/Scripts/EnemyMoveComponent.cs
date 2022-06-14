using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveComponent : MonoBehaviour
{
    [SerializeField] private GameObject _targetPlayer;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool _isPatrolling;
    [SerializeField] private bool _isFollowingPlayer;
    [SerializeField] private bool _isPlayerInSight;
    [SerializeField] private float _attackDistance;
    [SerializeField] private GameObject[] _patrollingPoints;
    private Transform _targetPlayerPosition;
    private Transform _targetPatrolPointPosition;


    private void Start()
    {
        _targetPlayerPosition = _targetPlayer.GetComponent<Transform>();
    }

    private void Update()
    {

        if (Vector2.Distance(transform.position, _targetPlayerPosition.position) >= _attackDistance && _isPlayerInSight)
        {
            _isPatrolling = false;
            _isFollowingPlayer = true;
            transform.position = Vector2.MoveTowards(transform.position, _targetPlayerPosition.position, _moveSpeed * Time.deltaTime);
            Debug.Log("Following Player");

        }
        else if (Vector2.Distance(transform.position, _targetPlayerPosition.position) <= _attackDistance && _isPlayerInSight)
        {
            _isPatrolling = false;
            _isFollowingPlayer = false;
            Debug.Log("Player in distance for attacking");


        }
        else if (!_isPlayerInSight && _patrollingPoints.Length != 0)
        {
            _isPatrolling = true;
            transform.position = Vector2.MoveTowards(transform.position, _patrollingPoints[0].transform.position, _moveSpeed * Time.deltaTime);
        }
    }
}
