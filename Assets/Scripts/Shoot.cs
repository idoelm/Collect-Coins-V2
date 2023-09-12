using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    GameObject currentBulletPrefab;
    int indexOfBullet = 0;
    bool rocketActive = false;
    public Transform shootingPoint;
    Rigidbody2D rb;
    [SerializeField] Player player;
    public AudioSource power;
    public InputAction shootAction;
    public InputAction replaceWeapon;

    public GameObject rocketMessage;
    public float displayDuration = 10f;
    private bool isImageDisplayed = false;
    private float timer = 0.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentBulletPrefab = bulletPrefab1;
        bulletPrefab2.SetActive(false);
        rocketMessage.SetActive(false);
    }
    private void ReplaceWeapon()
    {
        if (indexOfBullet == 0)
        {
            Debug.Log("Rocket");
            currentBulletPrefab = bulletPrefab2;
            indexOfBullet = 1;
        }
        else if (indexOfBullet == 1)
        {
            Debug.Log("Bullet");
            currentBulletPrefab = bulletPrefab1;
            indexOfBullet = 0;
        }
    }
    private void OnEnable()
    {
        shootAction.Enable();
        replaceWeapon.Enable();
    }
    void OnDisable()
    {
        shootAction.Disable();
        replaceWeapon.Disable();
    }
    void Update()
    {
        if(rocketActive)
        {
            if (replaceWeapon.triggered)
            {
                ReplaceWeapon();
            }
        }
        if (shootAction.triggered)
        {
            ShootBullet();
        }

        if (isImageDisplayed)
        {
            rocketMessage.SetActive (true);
            StartCoroutine(DestroyObjectAfterTime());
        }
    }
    public void ShootBullet()
    {
        Instantiate(currentBulletPrefab, shootingPoint.position, shootingPoint.rotation);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("AddRocket"))
        {
            Debug.Log("AddRocket");
            bulletPrefab2.SetActive(true);
            rocketActive = true;
            Destroy(collision.gameObject);
            player.audioBackground.volume = 0f;
            power.volume = 8f;
            power.Play();
            Invoke("UpVolumeAudioBackground", 16);
            isImageDisplayed = true;
            //currentBulletPrefab = bulletPrefab2;
        }
    }
    private void UpVolumeAudioBackground()
    {
        player.UpVolumeAudioBackground();
    }
    IEnumerator DestroyObjectAfterTime()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(6);
        Destroy(rocketMessage);
        Time.timeScale = 1;
    }
}
