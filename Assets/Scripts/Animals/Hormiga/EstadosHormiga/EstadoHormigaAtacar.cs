using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHormigaAtacar : IEstadoHormiga {
    public Transform target;

    //Atacar solo si ha pasado 1s desde el anterior ataque
    public IEstadoHormiga Update(Hormiga h) {
        //Si el objetivo esta muerto vamos al estado de muerte, ya que la hormiga ya ha comenzado su ataque suicida aunque no haga daño a ningun enemigo
        if (target == null) {
            return h.eMuerta;
        }

        //Comprobamos que tipo de enemigo es para hacerle daño correctamente
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
