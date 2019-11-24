using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HormigaReina : MonoBehaviour {
    //Estadisticas
    public int vida;
    public int fuerza;

    //Estado actual
    IEstadoHormigaReina estado;

    //Referencias a estados
    [HideInInspector]
    public EstadoHormigaReinaAtacar eAtacar;
    [HideInInspector]
    public EstadoHormigaReinaHuir eHuir;
    [HideInInspector]
    public EstadoHormigaReinaMantener eMantener;

    //Vision
    [HideInInspector]
    public List<Collider> sonarList;

    //Agente de pathfinding
    [HideInInspector]
    public NavMeshAgent nma;

    //Referencia a hormigas
    [HideInInspector]
    public Hormiga[] hormigas;

    void Start() {
        //Inicializamos tamaño y estadisticas
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * Settings.tamHormigas;
        vida = 100 * Settings.tamHormigas;
        sonarList = new List<Collider>();

        //Inicializamos los estados
        eAtacar = new EstadoHormigaReinaAtacar();
        eHuir = new EstadoHormigaReinaHuir();
        eMantener = new EstadoHormigaReinaMantener();
        estado = eMantener;

        //Inicializamos el agente de pathfinding
        nma = GetComponent<NavMeshAgent>();
        nma.Warp(transform.position);
    }

    void Update() {
        //Realizamos el update de nuestro estado y cambiamos la referencia al siguiente
        estado = estado.Update(this);
    }

    //Funcion que maneja el daño recibido
    public void GetHit(int daño) {
        vida -= daño;

        if (vida < 1) {
            foreach (Hormiga h in hormigas) {
                h.reinaViva = false;
            }
            DestroyImmediate(gameObject);
        }
    }

    //Funciones que maneja la vision
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

    //Funcion que maneja la colision
    private void OnCollisionStay(Collision collision) {
        if (!gameObject.CompareTag(collision.collider.tag) && !collision.collider.isTrigger && estado == eHuir) {
            if (collision.collider.transform == eHuir.target) {
                eHuir.colision = true;
            }
        }
    }
}
