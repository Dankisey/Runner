using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }

        Shuffle();
    }

    private void Shuffle()
    {
        for (int i = _pool.Count - 1; i >= 1; i--)
        {
            int j = Random.Range(0, i + 1);

            var temp = _pool[j];
            _pool[j] = _pool[i];
            _pool[i] = temp;
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }
}