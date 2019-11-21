using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EstadoHormigaPerseguir : IEstadoHormiga {
    public Transform target;
    public IEstadoHormiga Update(Hormiga h) {
        NavMeshAgent nma = h.GetComponent<NavMeshAgent>();

        nma.destination = target.position;

        return h.ePerseguir;
    }
}
