using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace StatePattern
{
    public class GameController : MonoBehaviour
    {
        public GameObject tRexObj;
        public GameObject antObj;
        public GameObject chickenObj;
        public GameObject octopusObj;

        //A list that will hold all enemies
        //List<TRex> tRexes = new List<TRex>();
        //List<Octopus> octopuses = new List<Octopus>();
        //List<Ant> ants = new List<Ant>();
        //List<Chicken> chickens = new List<Chicken>();

        void Start()
        {
            //Add the enemies we have
            //tRexes.Add(new TRex(tRexObj.transform));
            //octopuses.Add(new Octupus(octopusObj.transform));
            //ants.Add(new Ant(antObj.transform));
            //chickens.Add(new Chicken(chickenObj.transform));
        }

        void Update()
        {
            //Update all enemies to see if they should change state and move/attack player
            //for (int i = 0; i < enemies.Count; i++)
            //{
            //    enemies[i].UpdateEnemy(playerObj.transform);
            //}
        }
    }
}
