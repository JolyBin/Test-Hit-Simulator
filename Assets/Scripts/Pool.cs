using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    T _prefab;
    bool _isAutoExpand;
    Transform _container;

    public List<T> _pool;

    public Pool(T prefab, Transform container, int count, bool isAutoExpand)
    {
        _prefab = prefab;
        _container = container;
        _isAutoExpand = isAutoExpand;
        CreatePool(count);
    }

    void CreatePool(int count)
    {
        _pool = new List<T>();
        for (int i = 0; i < count; i++)
        {
            _pool.Add(CreateObject());
        }
    }

    T CreateObject(bool isACtiveByDefault = false)
    {
        var newObject = UnityEngine.Object.Instantiate(_prefab, _container);
        newObject.gameObject.SetActive(isACtiveByDefault);
        return newObject;
    }

    bool HasFreeElement(out T freeElement)
    {
        foreach (var element in _pool)
        {
            if(!element.gameObject.activeInHierarchy)
            {
                element.gameObject.SetActive(true);
                freeElement = element;
                return true;
            }
        }
        freeElement = null;
        return false;
    }

    public T GetFreeElement()
    {
        if(HasFreeElement(out var element))
        {
            return element;
        }
        if(_isAutoExpand)
        {
            return CreateObject(true);
        }
        throw new Exception($"There is no free elemnts in pool of type {typeof(T)}");
    }

}
