using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform firePoint; // Punto desde el que se dispara el proyectil
    public float attackRate = 1f; // Tiempo entre ataques
    private float nextAttackTime = 0f;

    private Transform target; // Objetivo actual de la torre

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            target = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Verifica si el objeto que sale del rango es el objetivo actual
        if (other.CompareTag("Enemy") && other.transform == target)
        {
            target = null; // Restablece el objetivo
            Debug.Log("El enemigo ha salido del rango.");
        }
    }

    void Update()
    {
        // Verifica si hay un objetivo en rango y si es tiempo de atacar
        if (target != null && Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + 1f / attackRate;
            Shoot();
        }
    }

    void Shoot()
    {
        // Instancia el proyectil y dirige al objetivo
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().SetTarget(target);
    }
}
