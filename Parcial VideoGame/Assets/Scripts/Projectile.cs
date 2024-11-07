using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public GameObject particleEffectPrefab; // Prefab de part�culas que se generan al moverse

    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            // Aqu� puedes agregar la l�gica para aplicar da�o al enemigo
            Destroy(gameObject);
        }

        // Generar part�culas al moverse
        if (particleEffectPrefab != null)
        {
            Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}
