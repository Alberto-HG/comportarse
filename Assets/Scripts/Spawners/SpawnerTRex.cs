using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase encargada de generar los Trex al principio de la simulacion
public class SpawnerTRex : MonoBehaviour {
    public GameObject trexPrefab;

    void Start() {
        for (int i = 0; i < Settings.numTrex; i++) {
            TRex t = Instantiate(trexPrefab).GetComponent<TRex>();
            t.transform.parent = transform;
            t.transform.position = transform.position;
        }
    }
}
