using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHormigaPerseguir : IEstadoHormiga {
    public Transform target;
    public bool colision = false;
    public IEstadoHormiga Update(Hormiga h) {
        //Si ha muerto el objetivo, volver a buscar
        if (target == null) {
            return h.eBuscar;
        }

        //Mientras no estamos cerca mantener el objetivo
        if (!colision) {
            h.nma.destination = target.position;
            return h.ePerseguir;
        } else {
            //Si se alcanza al objetivo se le ataca
            h.eAtacar.target = target;
            colision = false;
            target = null;
            return h.eAtacar;
        }
    }
}
