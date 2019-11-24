using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexStateSearch : IStatesTRex {

    //Atributo de fuerza
    float force;

    public IStatesTRex Update(TRex t) {

        //Calcula la fuerza en función del tamaño y de si hay aliados.
        force = Settings.tamTrex * 7.5f;
        if (t.grouped > 0) {
            force *= 2;
        }

        //Dependiendo del enemigo y de sus características ve si debe atacar o huir.
        if (t.enemy.gameObject.CompareTag("Pulpo")) {
            int rand = Random.Range((int)(force * 0.75f), (int)(force * 1.25f));
            if (rand < Settings.tamPulpos * 10) {
                return t.runState;
            } else {
                return t.attackState;
            }
        } else if (t.enemy.gameObject.CompareTag("Hormiga")) {
            Hormiga rival = t.enemy.GetComponent<Hormiga>();
            if (rival == null) {
                int rand = Random.Range((int)(force * 0.75f), (int)(force * 1.25f));
                if (rand < Settings.tamHormigas * 5) {
                    return t.runState;
                } else {
                    return t.attackState;
                }
            } else {
                return t.attackState;
            }
        } else {
            int rand = Random.Range((int)(force * 0.75f), (int)(force * 1.25f));
            if (rand < Settings.tamGallinas) {
                return t.runState;
            } else {
                return t.attackState;
            }
        }
    }
}