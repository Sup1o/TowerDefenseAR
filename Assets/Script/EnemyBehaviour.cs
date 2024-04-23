using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform Target;
    public GameObject[] DestroyEffect;
    public float speed = 0.01f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {
            transform.LookAt(Target);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Dead();
        }
    }

    public void Dead()
    {
        // Ensure that DestroyEffect only contains ParticleSystem objects
        var _effect = DestroyEffect[Random.Range(0, DestroyEffect.Length)];
        Instantiate(_effect, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }
}
