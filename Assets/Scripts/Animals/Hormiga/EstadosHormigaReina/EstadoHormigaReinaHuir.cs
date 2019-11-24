using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHormigaReinaHuir : IEstadoHormigaReina {
    public Transform target;
    public bool colision = false;

    public IEstadoHormigaReina Update(HormigaReina h) {
        //Si ha muerto el objetivo, dejar de huir
        if (target == null) {
            return h.eMantener;
        }

        //Mientras no estamos cerca mantener el objetivo
        if (!colision) {
            Vector3 dir = (h.transform.position - target.position).normalized;

            h.nma.destination = h.transform.position + (dir * 2);
            return h.eMantener;
        } else {
            //Si te alcanza el objetivo se le ataca
            colision = false;
            return h.eAtacar;
        }
    }
}
