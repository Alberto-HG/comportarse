using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHormigaReinaAtacar : IEstadoHormigaReina {
    public IEstadoHormigaReina Update(HormigaReina h) {
        return h.eAtacar;
    }
}
