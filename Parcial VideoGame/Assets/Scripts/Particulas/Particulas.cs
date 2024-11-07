using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralParticleController : MonoBehaviour
{
    public Transform target; // Centro al que las part�culas se dirigen
    private ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.particleCount];
        int count = particleSystem.GetParticles(particles);

        for (int i = 0; i < count; i++)
        {
            float angle = Time.time * 5f; // Controla la velocidad de rotaci�n
            Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * 0.1f; // Espiral en 2D
            particles[i].position += offset; // Mueve la part�cula en espiral

            // Mueve las part�culas hacia el centro
            Vector3 direction = (target.position - particles[i].position).normalized;
            particles[i].velocity = direction * 0.5f; // Ajusta la velocidad de acercamiento
        }

        particleSystem.SetParticles(particles, count);
    }
}