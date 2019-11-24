using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HormigaReina : MonoBehaviour {
    public int vida;
    public int fuerza;

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

    [HideInInspector]
    public Hormiga[] hormigas;

    void Start() {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * Settings.tamHormigas;
        vida = 100 * Settings.tamHormigas;

        eAtacar = new EstadoHormigaReinaAtacar();
        eHuir = new EstadoHormigaReinaHuir();
        eMantener = new EstadoHormigaReinaMantener();

        estado = eMantener;

        sonarList = new List<Collider>();
        nma = GetComponent<NavMeshAgent>();
        nma.Warp(transform.position);
    }

    void Update() {
        estado = estado.Update(this);
    }

    public void GetHit(int daño) {
        vida -= daño;

        if (vida < 1) {
            foreach (Hormiga h in hormigas) {
                h.reinaViva = false;
            }
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

    private void OnCollisionStay(Collision collision) {
        if (!gameObject.CompareTag(collision.collider.tag) && !collision.collider.isTrigger && estado == eHuir) {
            if (collision.collider.transform == eHuir.target) {
                eHuir.colision = true;
            }
        }
    }
}
