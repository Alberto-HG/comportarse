using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHormigaReinaMantener : IEstadoHormigaReina {
    public IEstadoHormigaReina Update(HormigaReina h) {
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

        if (closestEnemy != null) {
            h.eHuir.target = closestEnemy.transform;
            return h.eHuir;
        } else {
            return h.eMantener;
        }
    }
}
