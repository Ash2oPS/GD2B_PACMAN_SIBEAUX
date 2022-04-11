using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region PrivateVariables

    //private Type _maVariable;

    #endregion PrivateVariables

    #region GettersAndSetters

    //public Type MaVariable { get => _maVariable; set => _maVariable = value; }

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

    public bool CheckCollision()
    {
        bool hasCollided = false;

        /*Collider2D col = Physics2D.OverlapCircle()

        if (Physics2D.OverlapCircle)*/

        return hasCollided;
    }

    #endregion Functions
}