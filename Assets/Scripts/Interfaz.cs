using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Interfaz : MonoBehaviour {
    public TextMeshProUGUI numGallinas;
    public TextMeshProUGUI tamGallinas;
    public TextMeshProUGUI numHormigas;
    public TextMeshProUGUI tamHormigas;
    public TextMeshProUGUI numPulpos;
    public TextMeshProUGUI tamPulpos;
    public TextMeshProUGUI numTrex;
    public TextMeshProUGUI tamTrex;

    public void BarraNumGallinas(float value) {
        Settings.numGallinas = (int) value;
        numGallinas.SetText("" + value);
    }

    public void BarraTamGallinas(float value) {
        Settings.tamGallinas = (int) value;
        tamGallinas.SetText("" + value);
    }

    public void BarraNumHormigas(float value) {
        Settings.numHormigas = (int) value;
        numHormigas.SetText("" + value);
    }

    public void BarraTamHormigas(float value) {
        Settings.tamHormigas = (int) value;
        tamHormigas.SetText("" + value);
    }

    public void BarraNumPulpos(float value) {
        Settings.numPulpos = (int) value;
        numPulpos.SetText("" + value);
    }

    public void BarraTamPulpos(float value) {
        Settings.tamPulpos = (int) value;
        tamPulpos.SetText("" + value);
    }

    public void BarraNumTrex(float value) {
        Settings.numTrex = (int) value;
        numTrex.SetText("" + value);
    }

    public void BarraTamTrex(float value) {
        Settings.tamTrex = (int) value;
        tamTrex.SetText("" + value);
    }

    public void Comenzar() {
        SceneManager.LoadScene(1);
    }
}
