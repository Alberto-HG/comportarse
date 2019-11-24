using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoGallinaAtacar : IEstadoGallina {
    public Transform target;
    float time = 0f;

    //Atacar solo si ha pasado 1s desde el anterior ataque
    public IEstadoGallina Update(Gallina g) {
        if (Time.time - time > 1) {
            time = Time.time;

            //Si el objetivo esta muerto volvemos a buscar
            if (target == null) {
                return g.eBuscar;
            }

            //Comprobamos que tipo de enemigo es para hacerle daño correctamente
            if (target.gameObject.CompareTag("Hormiga")) {
                Hormiga h = target.gameObject.GetComponent<Hormiga>();
                if (h == null) {
                    HormigaReina hr = target.gameObject.GetComponent<HormigaReina>();
                    hr.GetHit(g.berserk ? g.fuerza * 3 : g.fuerza);
                } else {
                    h.GetHit();
                }
            }

            if (target.gameObject.CompareTag("Pulpo")) {
                Octopus o = target.gameObject.GetComponent<Octopus>();
                o.GetHit(g.berserk ? g.fuerza * 3 : g.fuerza);
            }

            if (target.gameObject.CompareTag("TRex")) {
                TRex t = target.gameObject.GetComponent<TRex>();
                t.GetHit(g.berserk ? g.fuerza * 3 : g.fuerza);
            }

            //Cada ataque reduce un poco la fuerza de la gallina
            if (g.fuerza > 10) {
                g.fuerza -= 1;
            }

            //Si el ataque acabo con su objetivo, la gallina se lo come para restaurar sus estadisticas
            if (target == null) {
                g.vida = g.vidaInicial;
                g.fuerza = g.fuerzaInicial;
                g.velocidad = g.velocidadInicial;
                g.berserk = false;
            }
        }

        return g.eAtacar;
    }
}
