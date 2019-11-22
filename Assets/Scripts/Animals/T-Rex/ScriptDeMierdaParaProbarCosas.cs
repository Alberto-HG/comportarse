using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDeMierdaParaProbarCosas : MonoBehaviour {


    public int groupSize;
    public float health;
    public float healthRegen;
    public float size;
    public float force;
    public bool eatable;

    void Start() {
        groupSize = 1;
        health = 10;
        size = 15;
        force = Random.Range(1, 3) * size;
        if (Random.Range(0, 2) < 1) {
            eatable = true;
            healthRegen = Random.Range(10, 31);
        } else {
            eatable = false;
        }
    }
}