using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHormigaAtacar : IEstadoHormiga {
    public Transform target;
    public IEstadoHormiga Update(Hormiga h) {
        if (target.gameObject.CompareTag("Gallina")) {
            Gallina g = target.gameObject.GetComponent<Gallina>();
            g.GetHit(h.fuerza);
        }

        /*if (target.gameObject.CompareTag("Pulpo")) {
            Octopus o = target.gameObject.GetComponent<Octopus>();
            o.getHit(h.fuerza);
        }

        if (target.gameObject.CompareTag("TRex")) {
            TRex t = target.gameObject.GetComponent<TRex>();
            t.getHit(h.fuerza);
        }*/

        return h.eMuerta;
    }
}
