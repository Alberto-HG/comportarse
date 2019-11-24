using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hormiga : MonoBehaviour {

    IEstadoHormiga estado;

    public int fuerza;

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

    [HideInInspector]
    public List<Collider> sonarList;
    [HideInInspector]
    public NavMeshAgent nma;

    [HideInInspector]
    public bool reinaViva;
    [HideInInspector]
    public Transform reina;

    void Start() {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * Settings.tamHormigas;
        fuerza = Settings.tamHormigas * 2;

        eAtacar = new EstadoHormigaAtacar();
        eBuscar = new EstadoHormigaBuscar();
        ePerseguir = new EstadoHormigaPerseguir();
        eRandom = new EstadoHormigaRandom();
        eMuerta = new EstadoHormigaMuerta();

        estado = eBuscar;
        
        sonarList = new List<Collider>();
        nma = GetComponent<NavMeshAgent>();

        nma.Warp(reina.position - reina.forward * 2);
    }
    
    void Update() {
        estado = estado.Update(this);
    }

    public void GetHit() {
        estado = eMuerta;
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
        if (!gameObject.CompareTag(collision.collider.tag) && !collision.collider.isTrigger && estado == ePerseguir) {
            if (collision.collider.transform == ePerseguir.target) {
                ePerseguir.colision = true;
            }
        }
    }
}
