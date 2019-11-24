using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHormigaReinaAtacar : IEstadoHormigaReina {
    public Transform target;
    float time = 0f;

    public IEstadoHormigaReina Update(HormigaReina h) {
        if (Time.time - time > 1) {
            time = Time.time;

            if (target == null) {
                return h.eMantener;
            }

            if (target.gameObject.CompareTag("Gallina")) {
                Gallina g = target.gameObject.GetComponent<Gallina>();
                g.GetHit(h.fuerza);
            }

            if (target.gameObject.CompareTag("Pulpo")) {
                Octopus o = target.gameObject.GetComponent<Octopus>();
                o.GetHit(h.fuerza);
            }

            if (target.gameObject.CompareTag("TRex")) {
                TRex t = target.gameObject.GetComponent<TRex>();
                t.GetHit(h.fuerza);
            }
        }

        return h.eAtacar;
    }
}
