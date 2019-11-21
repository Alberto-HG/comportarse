using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHormigaPerseguir : IEstadoHormiga {
    public Transform target;
    public IEstadoHormiga Update(Hormiga h) {
        if (Vector3.Distance(h.transform.position, target.position) > 1) {
            Debug.Log(Vector3.Distance(h.transform.position, target.position));
            h.nma.destination = target.position;
            return h.ePerseguir;
        } else {
            return h.eAtacar;
        }
    }
}
