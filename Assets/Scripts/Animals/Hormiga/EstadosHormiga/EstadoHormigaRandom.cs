using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHormigaRandom : IEstadoHormiga {
    public IEstadoHormiga Update(Hormiga h) {

        int rand = Random.Range(0, 10);

        if (rand > 7) {
            h.nma.destination = h.transform.position + new Vector3((Random.value - 0.5f) * 4, (Random.value - 0.5f) * 4, (Random.value - 0.5f) * 4);
        }

        return h.eBuscar;
    }
}
