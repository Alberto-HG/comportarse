using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoGallinaPerseguir : IEstadoGallina {
    public Transform target;

    public IEstadoGallina Update(Gallina g) {
        if (target == null) {
            return g.eBuscar;
        }

        if (Vector3.Distance(g.transform.position, target.position) > 2) {
            g.nma.destination = target.position;
            return g.ePerseguir;
        } else {
            int numGrupo = 0;
            int gLibres = 0;

            foreach (Gallina og in Settings.gallinas) {
                if (og.ePerseguir.target == target) {
                    numGrupo++;
                }

                if (og.ePerseguir.target == null) {
                    gLibres++;
                }
            }

            if (numGrupo + gLibres > 2) {
                foreach (Gallina og in Settings.gallinas) {
                    if (og.ePerseguir.target == null) {
                        og.ePerseguir.target = target;
                        og.estado = og.ePerseguir;
                    }
                }
                g.eAtacar.target = target;
                target = null;
                return g.eAtacar;
            } else {
                g.eHuir.target = target;
                target = null;
                return g.eHuir;
            }
        }
    }
}
