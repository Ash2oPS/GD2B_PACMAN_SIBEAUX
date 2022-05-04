using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Fantome : Character
{
    #region PrivateVariables

    [Header("----------Getters")]
    [SerializeField]
    private SpriteRenderer _sr;

    [SerializeField]
    private Light2D _light;

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
        _light.color = _currentColor;
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
            StopAllCoroutines();
            _sr.sprite = _scaredSprite;
            _sr.color = _scaredColor;
            _light.color = _scaredColor;
            StartCoroutine(Scared());
        }
        else
        {
            _sr.sprite = _currentSprite;
            _sr.color = _currentColor;
            _light.color = _currentColor;
        }
    }

    private IEnumerator Scared()
    {
        yield return new WaitForSeconds(4);
        _sr.sprite = _currentSprite;
        _sr.color = _currentColor;
        _light.color = _currentColor;
        yield return new WaitForSeconds(0.5f);
        _sr.sprite = _scaredSprite;
        _sr.color = _scaredColor;
        _light.color = _scaredColor;
        yield return new WaitForSeconds(0.5f);
        _sr.sprite = _currentSprite;
        _sr.color = _currentColor;
        _light.color = _currentColor;
        yield return new WaitForSeconds(0.5f);
        _sr.sprite = _scaredSprite;
        _sr.color = _scaredColor;
        _light.color = _scaredColor;
        yield return new WaitForSeconds(0.5f);
        _sr.sprite = _currentSprite;
        _sr.color = _currentColor;
        _light.color = _currentColor;
        yield return new WaitForSeconds(0.5f);
        _sr.sprite = _scaredSprite;
        _sr.color = _scaredColor;
        _light.color = _scaredColor;
        yield return new WaitForSeconds(0.25f);
        _sr.sprite = _currentSprite;
        _sr.color = _currentColor;
        _light.color = _currentColor;
        yield return new WaitForSeconds(0.25f);
        _sr.sprite = _scaredSprite;
        _sr.color = _scaredColor;
        _light.color = _scaredColor;
        yield return new WaitForSeconds(0.25f);
        _sr.sprite = _currentSprite;
        _sr.color = _currentColor;
        _light.color = _currentColor;
        yield return new WaitForSeconds(0.25f);
        _sr.sprite = _scaredSprite;
        _sr.color = _scaredColor;
        _light.color = _scaredColor;
        yield return new WaitForSeconds(0.25f);
        SetScared(false);
    }

    #endregion Functions
}