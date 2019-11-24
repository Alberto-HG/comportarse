using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoGallinaPerseguir : IEstadoGallina {
    public Transform target;

    public IEstadoGallina Update(Gallina g) {
        if (target == null) {
            return g.eBuscar;
        }

        if (Vector3.Distance(g.transform.position, target.position) > 1) {
            g.nma.destination = target.position;
            return g.ePerseguir;
        } else {
            target = null;
            return g.eAtacar;
        }
    }
}
