using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    #region PrivateVariables

    private float _baseX;

    #endregion PrivateVariables

    #region GettersAndSetters

    //public Type MaVariable { get => _maVariable; set => _maVariable = value; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    private void Start()
    {
        _baseX = transform.position.x;
    }

    private void Update()
    {
        float rot = (transform.position.x - _baseX) / -3;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rot));
    }

    #endregion InheritedFunctions

    #region Functions

    // NEW FUNCTIONS

    #endregion Functions
}