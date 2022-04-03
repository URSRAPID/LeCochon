using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DesView : MonoBehaviour, IObserver<VALUE>
{
    [SerializeField] private int x;
    [SerializeField] private int y;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _spriteUn;
    [SerializeField] private Sprite _spriteDeux;
    [SerializeField] private Sprite _spriteTrois;
    [SerializeField] private Sprite _spriteQuatre;
    [SerializeField] private Sprite _spriteCinq;
    [SerializeField] private Sprite _spriteSix;

    UnityEvent<int, int> _eventOnClic;

    public void Init(int initX, int initY)
    {
        x = initX;
        y = initY;
    }
 
    public void AddListener(UnityAction<int, int> method)
    {
        if (_eventOnClic == null)
        {
            _eventOnClic = new UnityEvent<int, int>();
        }
        _eventOnClic.AddListener(method);
    }

    private void OnMouseDown()
    {
        _eventOnClic.Invoke(x, y);
    }
 
    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(VALUE value)
    {
        if (value == VALUE.Un)
        {
            _spriteRenderer.sprite = _spriteUn;
        }
        else if(value == VALUE.Deux)
        {
            _spriteRenderer.sprite = _spriteDeux;
        }
        else if (value == VALUE.Trois)
        {
            _spriteRenderer.sprite = _spriteTrois;
        }
        else if (value == VALUE.Quatre)
        {
            _spriteRenderer.sprite = _spriteQuatre;
        }
        else if(value == VALUE.Cinq)
        {
            _spriteRenderer.sprite = _spriteCinq;
        }
        else if(value == VALUE.Six)
        {
            _spriteRenderer.sprite = _spriteSix;
        }
        else
        {
            //
        }
    }
    
    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }
 
}
