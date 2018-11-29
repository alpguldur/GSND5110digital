using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemyAI : MonoBehaviour {

    public float speed;
    public Transform target;
    public float chaseRange;

    //Audio
    public AudioClip playerDamageSoundEffect;
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {
        // Get the distance to the target and check to see if it close enough to chase
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < chaseRange)
        {
            //start chasing the target - turn and move towards the target
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);

            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            source.Play();
        }
    }
}
