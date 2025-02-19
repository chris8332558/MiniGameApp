using UnityEngine;
using System.Collections;

public class EnergySpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private EnergyPool[] energyPools;

    public int spawnAmountMin;
    public int spawnAmountMax;
    public float spawnWindow;
    private bool isSpawnFinished = true;

    private void Update()
    {
        if (isSpawnFinished)
        {
            int spawnAmount = Random.Range(spawnAmountMin, spawnAmountMax);
            StartCoroutine(spawnEnergyRoutine(spawnAmount));
            isSpawnFinished = false;
        }
    }

    IEnumerator spawnEnergyRoutine(int anAmount)
    {
        EnergyPool thePool = PickOnePool();
        for (int i=0; i<anAmount; i++)
        { 
            Energy anEnergy = thePool.GetEnergy();
            anEnergy.transform.position = spawnPoint.position;
            anEnergy.gameObject.SetActive(true);
            yield return new WaitForSeconds(spawnWindow);
		}
        yield return new WaitForSeconds(0.25f);
        isSpawnFinished = true;
	}

    public EnergyPool PickOnePool()
    {
        int idx = Random.Range(0, energyPools.Length);
        return energyPools[idx];
	}

}
