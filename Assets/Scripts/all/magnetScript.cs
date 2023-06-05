using DigitalRuby.LightningBolt;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;






public class magnetScript : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip soundToPlay;
    public float magnetPower;
    public GameObject lightning;
    public List<GameObject> metallicObjects;
    public Vector2 pullDirection;
    private bool isClicked;
    public globals globals;
    private void Start()
    {
        isClicked = false;
        lightning.SetActive(false);

        audioPlayer.clip = soundToPlay;
        audioPlayer.Stop();

        

    }

    private void Update()
    {
        if (isClicked)
        {
           metallicObjects.Clear();
            foreach (GameObject gameobject in GameObject.FindGameObjectsWithTag("metallic"))
            {
                metallicObjects.Add(gameobject);
            }
            foreach (GameObject go in metallicObjects)
            {
                Rigidbody2D ball = go.GetComponent<Rigidbody2D>();

                float distance = Vector3.Distance(ball.position, transform.position) - 1f;
                var script = lightning.GetComponent<LightningBoltScript>();
                if (distance < 3f)
                {
                    script.ChaosFactor = 0.15f;
                }
                float forceToAdd = magnetPower / (distance * distance);
                ball.AddForce(pullDirection * forceToAdd);
            }
        }
    }


    public void OnMouseDown()
    {
        isClicked = !isClicked;
        lightning.SetActive(isClicked);
        if (isClicked)
        {
            globals.NumberOfMagnetsClicked += 1;
            if (!audioPlayer.isPlaying)
            {
                audioPlayer.Play();
            }
        }
        else
        {
            globals.NumberOfMagnetsClicked -= 1;
            if (! (globals.NumberOfMagnetsClicked > 0))
            {
                audioPlayer.Stop();
            }
        }

    }


}

