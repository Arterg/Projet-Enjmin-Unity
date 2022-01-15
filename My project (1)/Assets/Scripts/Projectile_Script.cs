using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Script : MonoBehaviour
{
    private void OnTriggerEnter(Collider Other)
    { if (Other.gameObject.GetComponent<mouvement>() != null)
        { Destroy(Other.gameObject); }
        
        Destroy(gameObject);

        
    }
}
