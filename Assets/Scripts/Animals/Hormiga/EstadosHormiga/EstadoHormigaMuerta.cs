﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHormigaMuerta : IEstadoHormiga
{
    public IEstadoHormiga Update(Hormiga h) {
        if (h.reinaViva) {
            h.nma.Warp(h.reina.position - h.reina.forward * 2);
            return h.eBuscar;
        } else {
            Object.Destroy(h.gameObject);
            return h.eMuerta;
        }
    }
}