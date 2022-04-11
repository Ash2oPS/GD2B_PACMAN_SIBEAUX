using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    #region PrivateVariables

    [SerializeField]
    protected float _moveSpeed;

    [SerializeField]
    protected Rigidbody2D _rb;

    protected Vector2Int _direction, _nextMove;

    #endregion PrivateVariables

    #region GettersAndSetters

    public float MoveSpeed { get => _moveSpeed; }

    #endregion GettersAndSetters

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(_direction.x, _direction.y, 0) * _moveSpeed * Time.deltaTime;
    }

    protected void SetNextMove(Vector2Int pouet)
    {
        _nextMove = pouet;
    }

    protected void ChangeDirection()
    {
        if (_nextMove != Vector2Int.zero)
        {
            _direction = _nextMove;
            _nextMove = Vector2Int.zero;
        }
    }
}