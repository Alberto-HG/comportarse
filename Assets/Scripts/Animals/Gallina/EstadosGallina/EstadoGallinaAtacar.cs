using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoGallinaAtacar : IEstadoGallina {
    public Transform target;
    public IEstadoGallina Update(Gallina g) {

        if (target == null) {
            return g.eBuscar;
        }

        if (target.gameObject.CompareTag("Hormiga")) {
            Hormiga h = target.gameObject.GetComponent<Hormiga>();
            if (h == null) {
                HormigaReina hr = target.gameObject.GetComponent<HormigaReina>();
                hr.GetHit(g.berserk ? g.fuerza * 3 : g.fuerza);
            } else {
                h.GetHit();
            }

            if (g.fuerza > 1) {
                g.fuerza -= 1;
            }
        }

        /*if (target.gameObject.CompareTag("Pulpo")) {
            Octopus o = target.gameObject.GetComponent<Octopus>();
            o.getHit();
        }

        if (target.gameObject.CompareTag("TRex")) {
            TRex t = target.gameObject.GetComponent<TRex>();
            t.getHit();
        }*/

        if (target == null) {
            g.vida = g.vidaInicial;
            g.fuerza = g.fuerzaInicial;
            g.velocidad = g.velocidadInicial;
            g.berserk = false;
        }

        return g.eAtacar;
    }
}
