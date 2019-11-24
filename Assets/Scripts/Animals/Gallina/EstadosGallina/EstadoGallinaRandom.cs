using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoGallinaRandom : IEstadoGallina {
    float time;
    bool isWaiting;

    public EstadoGallinaRandom() {
        time = 0f;
        isWaiting = false;
    }

    public IEstadoGallina Update(Gallina g) {
        if (isWaiting) {
            if (Time.time - time > 2) {
                isWaiting = false;
            }
        } else {
            g.nma.destination = g.transform.position + new Vector3((Random.value - 0.5f) * 4, (Random.value - 0.5f) * 4, (Random.value - 0.5f) * 4);

            time = Time.time;
            isWaiting = true;
        }

        return g.eBuscar;
    }
}
