using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region PrivateVariables

    public int _pacDotsNumber;

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

    public void ScareGhost()
    {
        for (int i = 0; i < FindObjectsOfType<Fantome>().Length; i++)
        {
            FindObjectsOfType<Fantome>()[i].SetScared(true);
        }
    }

    #endregion Functions
}