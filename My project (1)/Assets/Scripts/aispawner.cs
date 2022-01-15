using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aispawner : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("prefab à spawn")]
    public Transform prefabAI;
    [Tooltip("point de spawn des ia")]
    public Transform spawnPoint;

    public Transform player;

    void Start()
    {

    }

    Transform SpawnAI()
    {
        Transform ai = GameObject.Instantiate<Transform>(prefabAI);
        ai.position = spawnPoint.position;
        ai.rotation = spawnPoint.rotation;
        ai.GetComponent<mouvement>().player = player;
        return ai;
    }
    void AddPichenette(Transform ai, Vector3 pichenette)
    {
        Rigidbody rb = ai.GetComponent<Rigidbody>();
        rb.AddForce(pichenette, ForceMode.Impulse);
    }
    private float time = 0;
    public float timeMax = 3;

    private Vector3 lastPichenette;
    // Update is called once per frame
    void Update()
    {

        time = time + Time.deltaTime;
        if (time >= timeMax)
        {

            Transform ai = SpawnAI();
            Vector3 pichenette = spawnPoint.forward * 5;
            pichenette.x += Random.Range(-0.2f, 2.0f);
            pichenette.y += Random.Range(-0.2f, 2.0f);
            time = 0;
            AddPichenette(ai, pichenette);
            lastPichenette = pichenette;

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(spawnPoint.position, spawnPoint.position + lastPichenette);
    }
}