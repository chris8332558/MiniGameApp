using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] float mSpeed;
    public EnergyPool energyPool;
    public float score;

    private void OnDestroy()
    {
        ReturnToPool();   
    }

    private void Start()
    {
    }

    private void Update()
    {
        transform.position += mSpeed * Time.deltaTime * Vector3.down;
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
        energyPool.PushEnergy(this);
	}
}
