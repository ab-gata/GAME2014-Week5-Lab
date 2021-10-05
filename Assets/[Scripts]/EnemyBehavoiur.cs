using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavoiur : MonoBehaviour
{
    [Header("Enemy Movement")]
    public Boundaries speedBound;
    public Boundaries boundaries;

    [Header("Bullets")]
    public BulletManager bulletManager;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public int frameDelay;

    public float randomSpeed;
    public float startingPoint;

    // Start is called before the first frame update
    void Start()
    {
        randomSpeed = Random.Range(speedBound.min, speedBound.max);
        startingPoint = Random.Range(boundaries.min, boundaries.max);
        bulletManager = GameObject.FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time, randomSpeed) + startingPoint, transform.position.y);
    }

    private void FixedUpdate()
    {
        if(Time.frameCount % frameDelay == 0) // every 10 frames
        {
            //var tempBullet = Instantiate(bulletPrefab);
            //tempBullet.transform.position = bulletSpawn.position;

            bulletManager.GetBullet(bulletSpawn.position);
        }
    }
}
