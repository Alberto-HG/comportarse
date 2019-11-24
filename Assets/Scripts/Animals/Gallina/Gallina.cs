using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gallina : MonoBehaviour
{
    IEstadoGallina estado;

    [HideInInspector]
    public EstadoGallinaAtacar eAtacar;
    [HideInInspector]
    public EstadoGallinaBuscar eBuscar;
    [HideInInspector]
    public EstadoGallinaPerseguir ePerseguir;
    [HideInInspector]
    public EstadoGallinaRandom eRandom;

    [HideInInspector]
    public List<Collider> visionList;
    [HideInInspector]
    public NavMeshAgent nma;

    void Start() {
        eAtacar = new EstadoGallinaAtacar();
        eBuscar = new EstadoGallinaBuscar();
        ePerseguir = new EstadoGallinaPerseguir();
        eRandom = new EstadoGallinaRandom();

        estado = eBuscar;

        visionList = new List<Collider>();
        nma = GetComponent<NavMeshAgent>();
    }

    void Update() {
        estado = estado.Update(this);
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
}
