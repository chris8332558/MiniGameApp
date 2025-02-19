using UnityEngine;
using System.Collections.Generic;

public class EnergyPool : MonoBehaviour
{
    [SerializeField] private Energy energyPrefab;
    [SerializeField] private int initSize;
    [SerializeField] private Transform parent;

    private Stack<Energy> pool = new();

    private void Start()
    {
        SetupPool();
    }

    private void SetupPool()
    {
        Energy instance = null;
        for (int i = 0; i < initSize; i++)
        {
            instance = Instantiate(energyPrefab, parent);
            instance.energyPool = this;
            instance.gameObject.SetActive(false);
            pool.Push(instance);
		}
	}

    public Energy GetEnergy()
    {
        Energy instance = null;
        if (pool.Count == 0)
        {
            instance = Instantiate(energyPrefab);
            instance.energyPool = this;
            instance.gameObject.SetActive(false);
            return instance;
        }

        instance = pool.Pop();
        return instance;
	}

    public void PushEnergy(Energy anEnergy)
    {
        pool.Push(anEnergy);
	}

}
