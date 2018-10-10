using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyParticleParent : MonoBehaviour
{ // used when there is parent object holding multiple parts of particle
  // attach this to any particle child

    private ParticleSystem ps;
    
    public void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        if (ps)
        {
            if (!ps.IsAlive())
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
        }

    }
}
