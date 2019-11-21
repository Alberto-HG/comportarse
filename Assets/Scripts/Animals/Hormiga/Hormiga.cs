using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hormiga : MonoBehaviour {

    IEstadoHormiga estado;

    [HideInInspector]
    public EstadoHormigaAtacar eAtacar;
    [HideInInspector]
    public EstadoHormigaBuscar eBuscar;
    [HideInInspector]
    public EstadoHormigaPerseguir ePerseguir;
    [HideInInspector]
    public EstadoHormigaRandom eRandom;

    [HideInInspector]
    public List<Collider> sonarList;
    [HideInInspector]
    public NavMeshAgent nma;

    void Start() {
        eAtacar = new EstadoHormigaAtacar();
        eBuscar = new EstadoHormigaBuscar();
        ePerseguir = new EstadoHormigaPerseguir();
        eRandom = new EstadoHormigaRandom();

        estado = eBuscar;
        
        sonarList = new List<Collider>();
        nma = GetComponent<NavMeshAgent>();
    }
    
    void Update() {
        estado = estado.Update(this);
    }

    private void OnTriggerEnter(Collider other) {
        if (!sonarList.Contains(other) && !other.gameObject.CompareTag(gameObject.tag)) {
            Debug.Log("hey");
            sonarList.Add(other);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (sonarList.Contains(other)) {
            sonarList.Remove(other);
        }
    }
}
