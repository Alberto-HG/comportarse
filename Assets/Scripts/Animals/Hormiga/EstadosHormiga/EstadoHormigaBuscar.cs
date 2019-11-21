using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHormigaBuscar : IEstadoHormiga {
    public IEstadoHormiga Update(Hormiga h) {
        if (h.sonarList.Capacity > 0) {
            Collider closestEnemy = null;
            foreach (Collider col in h.sonarList) {
                if (closestEnemy == null) {
                    closestEnemy = col;
                } else {
                    if (Vector3.Distance(col.transform.position, h.transform.position) < Vector3.Distance(closestEnemy.transform.position, h.transform.position)) {
                        closestEnemy = col;
                    }
                }
            }

            h.ePerseguir.target = closestEnemy.transform;

            return h.ePerseguir;
        } else {
            return h.eBuscar;
        }
    }
}