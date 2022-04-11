using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantome : MonoBehaviour
{
    #region PrivateVariables

    [Header("----------Getters")]
    [SerializeField]
    private SpriteRenderer _sr;

    [Header("----------Stats")]
    [SerializeField]
    private bool _isScared;

    [Header("----------Sprite Modifications")]
    [SerializeField]
    private List<Sprite> _possibleSprites;

    [SerializeField]
    private Sprite _scaredSprite;

    [SerializeField]
    private Color _scaredColor;

    private Sprite _currentSprite;
    private Color _currentColor;

    #endregion PrivateVariables

    #region GettersAndSetters

    public bool IsScared { get => _isScared; set => _isScared = value; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    private void Start()
    {
        _currentSprite = RandomSprite();
        _currentColor = RandomColor();

        _sr.sprite = _currentSprite;
        _sr.color = _currentColor;
    }

    private void Update()
    {
    }

    #endregion InheritedFunctions

    #region Functions

    private Color RandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        Color col = new Vector4(r, g, b, 1);

        return col;
    }

    private Sprite RandomSprite()
    {
        int rand = Random.Range(0, _possibleSprites.Count);

        Sprite spr = _possibleSprites[rand];

        return spr;
    }

    public void SetScared(bool value)
    {
        _isScared = value;
        if (value)
        {
            _sr.sprite = _scaredSprite;
            _sr.color = _scaredColor;
        }
        else
        {
            _sr.sprite = _currentSprite;
            _sr.color = _currentColor;
        }
    }

    #endregion Functions
}