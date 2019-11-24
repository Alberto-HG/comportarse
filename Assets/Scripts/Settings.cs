using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings {
    //Singletone que almacena las opciones de la simulacion y una referencia a todas las gallinas para que se puedan comunicar facilmente
    public static int numGallinas = 3;
    public static int tamGallinas = 1;
    public static int numHormigas = 1;
    public static int tamHormigas = 1;
    public static int numPulpos = 1;
    public static int tamPulpos = 1;
    public static int numTrex = 1;
    public static int tamTrex = 1;

    public static Gallina[] gallinas;
}
