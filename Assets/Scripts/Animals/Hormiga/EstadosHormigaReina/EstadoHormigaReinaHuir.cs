using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHormigaReinaHuir : IEstadoHormigaReina {
    public Transform target;
    public bool colision = false;

    public IEstadoHormigaReina Update(HormigaReina h) {
        if (target == null) {
            return h.eMantener;
        }

        if (!colision) {
            Vector3 dir = (h.transform.position - target.position).normalized;

            h.nma.destination = h.transform.position + (dir * 2);
            return h.eMantener;
        } else {
            colision = false;
            return h.eAtacar;
        }
    }
}
