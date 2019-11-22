using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHormigaReinaHuir : IEstadoHormigaReina {
    public Transform target;

    public IEstadoHormigaReina Update(HormigaReina h) {
        if (target == null) {
            return h.eMantener;
        }

        if (Vector3.Distance(h.transform.position, target.position) > 1) {
            Vector3 dir = (h.transform.position - target.position).normalized;

            h.nma.destination = h.transform.position + (dir * 2);
            return h.eMantener;
        } else {
            return h.eAtacar;
        }
    }
}
