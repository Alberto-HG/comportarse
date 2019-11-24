using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoGallinaHuir : IEstadoGallina {
    public Transform target;
    float time = 0f;

    public IEstadoGallina Update(Gallina g) {
        if (target == null) {
            return g.eBuscar;
        }

        float distance = Vector3.Distance(g.transform.position, target.position);

        if (distance > 10) {
            target = null;
            return g.eBuscar;
        }

        if (g.fuerza > 1 && Time.time - time > 1f) {
            g.fuerza -= 1;
        }

        if (g.velocidad > 0.5f && Time.time - time > 1f) {
            g.velocidad -= 0.5f;
            time = Time.time;
        }

        if (distance > 1) {
            Vector3 dir = (g.transform.position - target.position).normalized;

            g.nma.destination = g.transform.position + (dir * 2);
            return g.eHuir;
        } else {
            g.eAtacar.target = target;
            target = null;
            return g.eAtacar;
        }
    }
}
