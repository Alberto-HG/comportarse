﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase encargada de generar los pulpos al principio de la simulacion
public class SpawnerOctopus : MonoBehaviour {
    public GameObject octopusPrefab;
    public Transform lago;
    void Start() {
        for (int i = 0; i < Settings.numPulpos; i++) {
            Octopus o = Instantiate(octopusPrefab).GetComponent<Octopus>();
            o.transform.parent = transform;
            o.transform.position = transform.position;
            o.waterTerrain = lago;
        }
    }
}