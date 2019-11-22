using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHormigaPerseguir : IEstadoHormiga {
    public Transform target;
    public IEstadoHormiga Update(Hormiga h) {
        if (target == null) {
            return h.eBuscar;
        }

        if (Vector3.Distance(h.transform.position, target.position) > 1) {
            h.nma.destination = target.position;
            return h.ePerseguir;
        } else {
            target = null;
            return h.eAtacar;
        }
    }
}
