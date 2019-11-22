using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDeMierdaParaProbarCosas : MonoBehaviour {

    public float health = 10;
    public float healthRegen;
    public float force;
    public bool eatable;

    void Start() {
        force = Random.Range(10, 51);
        if (Random.Range(0, 2) < 1) {
            eatable = true;
            healthRegen = Random.Range(10, 31);
        } else {
            eatable = false;
        }
    }
}