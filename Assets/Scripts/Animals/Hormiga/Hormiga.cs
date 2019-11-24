using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hormiga : MonoBehaviour {
    //Estadisticas
    public int fuerza;

    //Estado actual
    IEstadoHormiga estado;

    //Referencias a estados
    [HideInInspector]
    public EstadoHormigaAtacar eAtacar;
    [HideInInspector]
    public EstadoHormigaBuscar eBuscar;
    [HideInInspector]
    public EstadoHormigaPerseguir ePerseguir;
    [HideInInspector]
    public EstadoHormigaRandom eRandom;
    [HideInInspector]
    public EstadoHormigaMuerta eMuerta;

    //Vision
    [HideInInspector]
    public List<Collider> sonarList;

    //Agente de pathfinding
    [HideInInspector]
    public NavMeshAgent nma;

    //Referencias de la reina
    [HideInInspector]
    public bool reinaViva;
    [HideInInspector]
    public Transform reina;

    void Start() {
        //Inicializamos tamaño y estadisticas
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * Settings.tamHormigas;
        fuerza = Settings.tamHormigas * 2;
        sonarList = new List<Collider>();

        //Inicializamos los estados
        eAtacar = new EstadoHormigaAtacar();
        eBuscar = new EstadoHormigaBuscar();
        ePerseguir = new EstadoHormigaPerseguir();
        eRandom = new EstadoHormigaRandom();
        eMuerta = new EstadoHormigaMuerta();
        estado = eBuscar;
        
        //Inicializamos el agente de pathfinding
        nma = GetComponent<NavMeshAgent>();
        nma.Warp(reina.position - reina.forward * 2);
    }
    
    void Update() {
        //Realizamos el update de nuestro estado y cambiamos la referencia al siguiente
        estado = estado.Update(this);
    }

    //Funcion que maneja el daño recibido
    public void GetHit() {
        estado = eMuerta;
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
        if (!gameObject.CompareTag(collision.collider.tag) && !collision.collider.isTrigger && estado == ePerseguir) {
            if (collision.collider.transform == ePerseguir.target) {
                ePerseguir.colision = true;
            }
        }
    }
}
