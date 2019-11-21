using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHormigaAtacar : IEstadoHormiga {
    public IEstadoHormiga Update(Hormiga h) {
        return h.eAtacar;
    }
}
