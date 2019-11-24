using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
