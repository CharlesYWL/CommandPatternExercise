using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

namespace Captain.Command
{
    public class NormalWorkerPirateCommand : ScriptableObject, IPirateCommand
    {
        private float currentTime = 0;
        private float lastTime = 0; 
        private float workTime = 0;
        private bool newLoop = true;


        public bool Execute(GameObject pirate, Object productPrefab)
        {
            //This function returns false when no work is done. 
            //After you implement work according to the specification and
            //generate instances of productPrefab, this function should return true.
            // get the time
            currentTime += Time.deltaTime; 
            //one loop means one duration, activate once per execute
            if (newLoop) 
            {
                currentTime = 0;
                lastTime = 0;
                workTime = Random.Range(10.0f, 20.0f);
                newLoop = false;
            }
            //now worktime expired
            if (currentTime > workTime) 
            {
                return false;
            }
            //per 8 sec
            if(currentTime - lastTime > 4)
            {
                lastTime = currentTime;
                //make random position
                Vector3 v3 = new Vector3(Random.Range(1.0f,3.0f), 0, 0);
                var product = (GameObject)Instantiate(productPrefab, pirate.transform.localPosition+v3, pirate.transform.localRotation);
            }
            return true;
        }
    }
}
