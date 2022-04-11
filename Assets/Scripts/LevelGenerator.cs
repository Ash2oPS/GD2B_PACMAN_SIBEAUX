using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    #region PrivateVariables

    [Header("----------Level")]
    [SerializeField]
    [Range(25, 60)]
    private int _width;

    [SerializeField]
    [Range(25, 60)]
    private int _height;

    [SerializeField]
    private int _numberOfVerticalTeleporters, _numberOfHorizontalTeleporters, _chanceToHaveWall, _pacDotsRate, _superPacDotsRate, _numberOfGhosts;

    private int _ghostCount;

    private List<Vector2Int> _randWallsVectors;

    [Header("----------Getters")]
    [SerializeField]
    private GameObject _camera;

    [SerializeField]
    private GameObject _spawner;

    [SerializeField]
    private Transform _wallsParent;

    [SerializeField]
    private GameManager _gm;

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
        CreateGhosts();
        CreatePacDots();
        CreatePacman();
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
                            _randWallsVectors.Add(new Vector2Int(i, j));
                            go.transform.parent = _wallsParent;
                            _gm._pacDotsNumber++;
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

                        if (Random.Range(0, _superPacDotsRate) == 0)
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
                                    GameObject go = Instantiate(_superPacDot, new Vector3(i, j * -1, 0), Quaternion.identity);
                                    _randWallsVectors.Add(new Vector2Int(i, j));
                                    go.transform.parent = _wallsParent;
                                    _gm._pacDotsNumber++;
                                }
                                mustCreate = false;
                            }
                        }

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

    private void CreateGhosts()
    {
        bool isOnAWall = false;
        if (_ghostCount <= _numberOfGhosts)
        {
            int x = Random.Range(1, _width - 1);
            int y = Random.Range(1, _height - 1);

            for (int i = 0; i < _randWallsVectors.Count; i++)
            {
                if (x == _randWallsVectors[i].x && y == _randWallsVectors[i].y)
                {
                    isOnAWall = true;
                }
            }
            if (!isOnAWall)
            {
                Instantiate(_fantome, new Vector3(x, y * -1, 0), Quaternion.identity);
                _ghostCount++;
            }
            CreateGhosts();
        }
    }

    #endregion Functions
}