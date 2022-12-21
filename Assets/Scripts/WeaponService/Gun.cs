using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform SpawnPosition;
    public float BulletSpeed = 10;
    public float ShotPeriod = 0.2f;
    public AudioSource ShotSound;
    public GameObject Flash;
    public int CurrentAmmo = 3;
    public AmmoUI AmmoUI;

    private float _timer;

    public ParticleSystem ShootEffect;



    private void Start()
    {
        Flash.SetActive(false);
    }
    void Update()
    {
        if (CurrentAmmo != 0)
        {
            _timer += Time.deltaTime;
            if (_timer > ShotPeriod)
            {
                if (Input.GetMouseButton(0))
                {
                    _timer = 0;
                    Shoot();
                }
            }
        }
    }

    public virtual void Shoot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, SpawnPosition.position, SpawnPosition.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = SpawnPosition.forward * BulletSpeed;
        ShotSound.Play();
        Flash.SetActive(true);
        Invoke("HideFlash", 0.08f);
        ShootEffect.Play();

    }

    public void HideFlash()
    {
        Flash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int numberOfBullet)
    {

    }

}
