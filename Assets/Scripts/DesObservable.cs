using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesObservable : IObservable<VALUE>
{
    private List<IObserver<VALUE>> _observers;
    private VALUE _value;

    public DesObservable(VALUE initValue)
    {
        _value = initValue;
        _observers = new List<IObserver<VALUE>>();
    }

    public IDisposable Subscribe(IObserver<VALUE> observer)
    {
        //On regarde dans la liste si il y a pas d'observeurs, si c'est le cas on en rajoute
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
        return null;
    }

    public void Set(VALUE newValue)
    {
        //On change la valeur
        _value = newValue;

        //On notifie les observeurs
        foreach (IObserver<VALUE> obs in _observers)
        {
            obs.OnNext(_value);
        }
    }

    

    public bool IsValue(VALUE value)
    {
        return _value == value;
    }
    internal VALUE GetValue()
    {
        return _value;
    }

     
}
