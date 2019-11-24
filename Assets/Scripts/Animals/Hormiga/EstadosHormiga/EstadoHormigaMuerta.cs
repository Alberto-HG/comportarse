using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHormigaMuerta : IEstadoHormiga
{
    public IEstadoHormiga Update(Hormiga h) {
        //Si la hormiga esta viva reaparecer en ella. De lo contrario, morir.
        if (h.reinaViva) {
            h.nma.Warp(h.reina.position - h.reina.forward * 2 * Settings.tamHormigas);
            return h.eBuscar;
        } else {
            Object.DestroyImmediate(h.gameObject);
            return h.eMuerta;
        }
    }
}
