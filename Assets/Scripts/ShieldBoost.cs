using UnityEngine;

public class ShieldBoost : MonoBehaviour
{
    public float shieldDuration = 3f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.ActivateShield(shieldDuration);
            Destroy(gameObject);
        }
    }
}
