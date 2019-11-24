using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gallina : MonoBehaviour {
    //Estadisticas
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

    //Estado actual
    public IEstadoGallina estado;

    //Referencias a estados
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

    //Vision
    [HideInInspector]
    public List<Collider> visionList;

    //Agente de pathfinding
    [HideInInspector]
    public NavMeshAgent nma;

    void Start() {
        //Inicializamos las estadisticas
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * Settings.tamGallinas;
        vida = 50 * Settings.tamGallinas;
        fuerza = 10 * Settings.tamGallinas;
        velocidad = Settings.tamGallinas;
        berserk = false;
        visionList = new List<Collider>();

        vidaInicial = vida;
        fuerzaInicial = fuerza;
        velocidadInicial = velocidad;

        //Inicializamos los estados
        eAtacar = new EstadoGallinaAtacar();
        eBuscar = new EstadoGallinaBuscar();
        ePerseguir = new EstadoGallinaPerseguir();
        eRandom = new EstadoGallinaRandom();
        eHuir = new EstadoGallinaHuir();
        estado = eBuscar;

        //Inicializamos el agente de pathfinding
        nma = GetComponent<NavMeshAgent>();
        nma.speed = velocidad;
        nma.Warp(transform.position);
    }

    void Update() {
        //Realizamos el update de nuestro estado y cambiamos la referencia al siguiente
        estado = estado.Update(this);
    }

    //Funcion que maneja el daño recibido
    public void GetHit(int daño) {
        vida -= daño;

        if (berserk) {
            vida -= daño;
        }

        if (vida < (float) vidaInicial / 3) {
            berserk = true;
        }

        if (vida < 1) {
            Destroy(gameObject);
        }
    }

    //Funciones que maneja la vision
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

    //Funcion que maneja la colision
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
