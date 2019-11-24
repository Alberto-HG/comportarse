using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGallinas : MonoBehaviour {
    public GameObject gallinaPrefab;
    void Start() {
        Settings.gallinas = new Gallina[Settings.numGallinas];

        for (int i = 0; i < Settings.numGallinas; i++) {
            Settings.gallinas[i] = Instantiate(gallinaPrefab).GetComponent<Gallina>();
            Settings.gallinas[i].transform.parent = transform;
            Settings.gallinas[i].transform.position = transform.position;
        }
    }
}
