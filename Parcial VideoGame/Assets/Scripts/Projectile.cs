using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f; // Velocidad del proyectil
    private Transform target; // Objetivo del proyectil

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); // Destruye el proyectil si no hay objetivo
            return;
        }

        // Mueve el proyectil hacia el objetivo
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Ajusta la rotación del proyectil para seguir al objetivo en cada frame
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle += 180f; // Ajusta este valor si tu sprite apunta en otra dirección
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Verifica si el proyectil ha llegado al objetivo
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            // Aquí puedes agregar la lógica de daño al enemigo
            Destroy(gameObject); // Destruye el proyectil al llegar al objetivo
        }
    }
}
