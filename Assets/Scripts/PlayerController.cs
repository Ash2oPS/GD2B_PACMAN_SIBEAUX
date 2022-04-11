using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region PrivateVariables

    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    private Rigidbody2D _rb;

    private Vector2Int _direction, _nextMove;

    #endregion PrivateVariables

    #region GettersAndSetters

    public float MoveSpeed { get => _moveSpeed; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    private void Start()
    {
        _direction = Vector2Int.right;
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(_direction.x, _direction.y, 0) * _moveSpeed * Time.deltaTime;
    }

    #endregion InheritedFunctions

    #region Functions

    public void SetNextMove(Vector2Int pouet)
    {
        _nextMove = pouet;
    }

    private void ChangeDirection()
    {
        if (_nextMove != Vector2Int.zero)
        {
            _direction = _nextMove;
            _nextMove = Vector2Int.zero;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
    }

    #endregion Functions
}