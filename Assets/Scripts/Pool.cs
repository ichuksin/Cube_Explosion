using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Dynamite _prefab;

    private Queue<Dynamite> _dynamits = new Queue<Dynamite>();

    public Dynamite GetObject()
    {
        Dynamite dynamite;
        if (_dynamits.Count == 0)
        {
            dynamite = Instantiate(_prefab);
        }
        else
        {
            dynamite = _dynamits.Dequeue();
        }
        return dynamite;
    }

    public void Release(Dynamite dynamite)
    {
        _dynamits.Enqueue(dynamite);
    }
}
