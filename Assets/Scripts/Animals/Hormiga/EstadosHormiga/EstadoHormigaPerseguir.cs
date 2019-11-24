using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHormigaPerseguir : IEstadoHormiga {
    public Transform target;
    public bool colision = false;
    public IEstadoHormiga Update(Hormiga h) {
        if (target == null) {
            return h.eBuscar;
        }

        if (!colision) {
            h.nma.destination = target.position;
            return h.ePerseguir;
        } else {
            h.eAtacar.target = target;
            colision = false;
            target = null;
            return h.eAtacar;
        }
    }
}
