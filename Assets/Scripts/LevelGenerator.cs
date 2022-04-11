using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    #region PrivateVariables

    [Header("----------Level")]
    [SerializeField]
    private int _width;

    [SerializeField]
    private int _height, _numberOfVerticalTeleporters, _numberOfHorizontalTeleporters, _chanceToHaveWall, _pacDotsRate;

    private List<Vector2Int> _randWallsVectors;

    [Header("----------Getters")]
    [SerializeField]
    private GameObject _camera;

    [SerializeField]
    private GameObject _spawner;

    [SerializeField]
    private Transform _wallsParent;

    [Header("----------Prefabs")]
    [SerializeField]
    private GameObject _pacman;

    [SerializeField]
    private GameObject _wall;

    [SerializeField]
    private GameObject _ground;

    [SerializeField]
    private GameObject _pacDot;

    [SerializeField]
    private GameObject _superPacDot;

    [SerializeField]
    private GameObject _fantome;

    #endregion PrivateVariables

    #region GettersAndSetters

    //public Type MaVariable { get => _maVariable; set => _maVariable = value; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    private void Start()
    {
        CreateLevel();
        CreatePacman();
        CreatePacDots();
    }

    private void Update()
    {
    }

    #endregion InheritedFunctions

    #region Functions

    private void CreateLevel()
    {
        CreateBorderWalls();
        CreateRandomWalls();
    }

    private void CreateBorderWalls()
    {
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                if (j == 0 || j == _height - 1)
                {
                    GameObject go = Instantiate(_wall, new Vector3(i, j * -1, 0), Quaternion.identity);
                    go.transform.parent = _wallsParent;
                }
                else if (i == 0 || i == _width - 1)
                {
                    GameObject go = Instantiate(_wall, new Vector3(i, j * -1, 0), Quaternion.identity);
                    go.transform.parent = _wallsParent;
                }
            }
        }
    }

    private void CreateRandomWalls()
    {
        _randWallsVectors = new List<Vector2Int>();

        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                int rand = Random.Range(0, _chanceToHaveWall);

                if (rand == _chanceToHaveWall - 1 && j != 0 && j != _height - 1 && i != 0 && i != _width - 1)
                {
                    GameObject go = Instantiate(_wall, new Vector3(i, j * -1, 0), Quaternion.identity);
                    go.transform.parent = _wallsParent;
                    _randWallsVectors.Add(new Vector2Int(i, j));
                }
                else
                {
                    GameObject go = Instantiate(_ground, new Vector3(i, j * -1, 0), Quaternion.identity);
                    go.transform.parent = _wallsParent;
                }
            }
        }
    }

    private void CreatePacDots()
    {
        int count = 0;
        bool mustCreate = false;
        bool isOnAWall = false;
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                if (mustCreate)
                {
                    for (int k = 0; k < _randWallsVectors.Count; k++)
                    {
                        if (i == _randWallsVectors[k].x && j == _randWallsVectors[k].y)
                        {
                            isOnAWall = true;
                        }
                    }
                    if (!isOnAWall)
                    {
                        if (j != 0 && j != _height - 1 && i != 0 && i != _width - 1)
                        {
                            GameObject go = Instantiate(_pacDot, new Vector3(i, j * -1, 0), Quaternion.identity);
                            go.transform.parent = _wallsParent;
                        }
                        mustCreate = false;
                    }
                }
                else
                {
                    count++;
                    if (count >= _pacDotsRate)
                    {
                        count = 0;
                        mustCreate = true;
                    }
                }
                isOnAWall = false;
            }
        }
    }

    private void CreatePacman()
    {
        GameObject _pacmanObject = Instantiate(_pacman, new Vector3(10, -19, 0), Quaternion.identity);
        _camera.transform.parent = _pacmanObject.transform;
    }

    #endregion Functions
}