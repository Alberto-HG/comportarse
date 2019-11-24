using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHormigaAtacar : IEstadoHormiga {
    public Transform target;
    public IEstadoHormiga Update(Hormiga h) {
        if (target == null) {
            return h.eMuerta;
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

        return h.eMuerta;
    }
}
