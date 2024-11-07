using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil arcoíris
    public Transform firePoint; // Punto desde el que se lanza el proyectil
    public float attackRate = 1f; // Tiempo entre ataques
    private float nextAttackTime = 0f;

    private Transform target;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            target = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && other.transform == target)
        {
            target = null;
        }
    }

    void Update()
    {
        if (target != null && Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + 1f / attackRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().SetTarget(target);
    }
}
