using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

namespace Captain.Command
{
    public class SlowWorkerPirateCommand : ScriptableObject, IPirateCommand
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
                workTime = Random.Range(20, 40);
                newLoop = false;
            }
            if (currentTime > workTime) 
            {
                return false;
            }
            if(currentTime - lastTime > 8)
            {
                lastTime = currentTime;
                Vector3 v3 = new Vector3(Random.Range(1,3), 0, 0);
                var product = (GameObject)Instantiate(productPrefab, pirate.transform.localPosition+v3, pirate.transform.localRotation);
            }
            return true;
        }
    }
}
