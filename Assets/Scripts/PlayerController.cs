using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region PrivateVariables

    [SerializeField]
    private float _moveSpeed;

    private Vector2Int _nextMove;

    #endregion PrivateVariables

    #region GettersAndSetters

    public float MoveSpeed { get => _moveSpeed; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    private void Start()
    {
    }

    private void Update()
    {
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
            _nextMove = Vector2Int.zero;
        }
    }

    #endregion Functions
}