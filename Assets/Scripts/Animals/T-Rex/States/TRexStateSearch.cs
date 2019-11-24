using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexStateSearch : IStatesTRex {

    float force;

    public IStatesTRex Update(TRex t) {

        force = Settings.tamTrex * 7.5f;
        if (t.grouped > 0) {
            force *= 2;
        }
        if (t.enemy.gameObject.CompareTag("Pulpo")) {
            int rand = Random.Range((int)(force * 0.75f), (int)(force * 1.25f));
            if (rand < Settings.tamPulpos * 15) {
                return t.runState;
            } else {
                return t.attackState;
            }
        } else if (t.enemy.gameObject.CompareTag("Hormiga")) {
            Hormiga rival = t.enemy.GetComponent<Hormiga>();
            if (rival == null) {
                int rand = Random.Range((int)(force * 0.75f), (int)(force * 1.25f));
                if (rand < Settings.tamHormigas * 10) {
                    return t.runState;
                } else {
                    return t.attackState;
                }
            } else {
                return t.attackState;
            }
        } else {
            int rand = Random.Range((int)(force * 0.75f), (int)(force * 1.25f));
            if (rand < Settings.tamGallinas * 5) {
                return t.runState;
            } else {
                return t.attackState;
            }
        }
    }
}