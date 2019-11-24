using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase encargada de generar las hormigas al principio de la simulacion
public class SpawnerHormigas : MonoBehaviour {
    public GameObject hormigaPrefab;
    public GameObject hormigaReinaPrefab;
    void Start() {
        HormigaReina hr = Instantiate(hormigaReinaPrefab).GetComponent<HormigaReina>();
        hr.transform.parent = transform;
        hr.transform.position = transform.position;

        Hormiga[] hormigas = new Hormiga[Settings.numHormigas];

        for (int i = 0; i < hormigas.Length; i++) {
            hormigas[i] = Instantiate(hormigaPrefab).GetComponent<Hormiga>();
            hormigas[i].transform.parent = transform;
            hormigas[i].transform.position = transform.position;

            hormigas[i].reina = hr.transform;
            hormigas[i].reinaViva = true;
        }

        hr.hormigas = hormigas;
    }
}
