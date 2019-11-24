using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HormigaReina : MonoBehaviour {
    int vida;
    int fuerza;

    IEstadoHormigaReina estado;

    [HideInInspector]
    public EstadoHormigaReinaAtacar eAtacar;
    [HideInInspector]
    public EstadoHormigaReinaHuir eHuir;
    [HideInInspector]
    public EstadoHormigaReinaMantener eMantener;

    [HideInInspector]
    public List<Collider> sonarList;
    [HideInInspector]
    public NavMeshAgent nma;

    Hormiga[] hormigas;
    public GameObject HormigaPrefab;

    void Start() {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * Settings.tamHormigas;
        vida = 100 * Settings.tamHormigas;

        eAtacar = new EstadoHormigaReinaAtacar();
        eHuir = new EstadoHormigaReinaHuir();
        eMantener = new EstadoHormigaReinaMantener();

        estado = eMantener;

        sonarList = new List<Collider>();
        nma = GetComponent<NavMeshAgent>();

        hormigas = new Hormiga[Settings.numHormigas];

        for (int i = 0; i < hormigas.Length; i++) {
            hormigas[i] = Instantiate(HormigaPrefab).GetComponent<Hormiga>();

            hormigas[i].reina = transform;
            hormigas[i].reinaViva = true;
        }
    }

    void Update() {
        estado = estado.Update(this);
    }

    public void GetHit(int daño) {
        vida -= daño;

        if (vida < 0) {
            DestroyImmediate(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!sonarList.Contains(other) && !other.gameObject.CompareTag(gameObject.tag)) {
            sonarList.Add(other);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (sonarList.Contains(other)) {
            sonarList.Remove(other);
        }
    }
}
