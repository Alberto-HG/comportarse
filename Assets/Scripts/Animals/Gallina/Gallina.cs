using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gallina : MonoBehaviour {
    public int vida;
    public int fuerza;
    public float velocidad;
    public bool berserk;

    [HideInInspector]
    public int vidaInicial;
    [HideInInspector]
    public int fuerzaInicial;
    [HideInInspector]
    public float velocidadInicial;

    public IEstadoGallina estado;

    [HideInInspector]
    public EstadoGallinaAtacar eAtacar;
    [HideInInspector]
    public EstadoGallinaBuscar eBuscar;
    [HideInInspector]
    public EstadoGallinaPerseguir ePerseguir;
    [HideInInspector]
    public EstadoGallinaRandom eRandom;
    [HideInInspector]
    public EstadoGallinaHuir eHuir;

    [HideInInspector]
    public List<Collider> visionList;
    [HideInInspector]
    public NavMeshAgent nma;

    void Start() {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * Settings.tamGallinas;
        vida = 50 * Settings.tamGallinas;
        fuerza = 10 * Settings.tamGallinas;
        velocidad = 0.5f * Settings.tamGallinas;
        berserk = false;

        vidaInicial = vida;
        fuerzaInicial = fuerza;
        velocidadInicial = velocidad;

        eAtacar = new EstadoGallinaAtacar();
        eBuscar = new EstadoGallinaBuscar();
        ePerseguir = new EstadoGallinaPerseguir();
        eRandom = new EstadoGallinaRandom();
        eHuir = new EstadoGallinaHuir();

        estado = eBuscar;

        visionList = new List<Collider>();
        nma = GetComponent<NavMeshAgent>();
        nma.speed = velocidad;
        nma.Warp(transform.position);
    }

    void Update() {
        estado = estado.Update(this);
    }

    public void GetHit(int daño) {
        vida -= daño;

        if (berserk) {
            vida -= daño;
        }

        if (vida < (float) vidaInicial / 3) {
            berserk = true;
        }

        if (vida < 0) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!visionList.Contains(other) && !other.gameObject.CompareTag(gameObject.tag)) {
            visionList.Add(other);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (visionList.Contains(other)) {
            visionList.Remove(other);
        }
    }

    private void OnCollisionStay(Collision collision) {
        if (!gameObject.CompareTag(collision.collider.tag) && !collision.collider.isTrigger && estado == ePerseguir) {
            if (collision.collider.transform == ePerseguir.target) {
                ePerseguir.colision = true;
            }
        }

        if (!gameObject.CompareTag(collision.collider.tag) && !collision.collider.isTrigger && estado == eHuir) {
            if (collision.collider.transform == eHuir.target) {
                ePerseguir.colision = true;
            }
        }
    }
}
