using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    ParticleSystem[] system;

    public float scale = 0.0001f;

    void Start()
    {
        system = GetComponentsInChildren<ParticleSystem>();

        for (int i = 0; i < system.Length; i++)
        {
            ParticleSystem.ShapeModule shape = system[i].shape;
            shape.scale *= scale;
        }
    }

}
