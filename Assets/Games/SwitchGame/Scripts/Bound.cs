using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class Bound : MonoBehaviour
{
    public ScoreManager scoreManager;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Energy>(out Energy anEnergy))
        {
            scoreManager.AddScore(anEnergy.score);
            anEnergy.ReturnToPool();
		}
    }
}
