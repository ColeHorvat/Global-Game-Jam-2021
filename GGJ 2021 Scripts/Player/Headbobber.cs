using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headbobber: MonoBehaviour 
 {

    private float timer = 0.0f;
    public float bobbingSpeed = 0.1f;
    public float bobbingAmount = 0.1f;
    private float midpoint = 0.7f;

    public AudioClip[] walking;
    private AudioSource audioSource;

    public float stepTime = 0.2f;
    public float runStepTime = 0.1f;
    float stepTimer;

    bool step = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (PauseMenu.gameIsPaused == true)
        {
            bobbingAmount = 0;
        }

        float waveslice = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 cSharpConversion = transform.localPosition;

        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            timer = 0.0f;
        }
        else
        {
            waveslice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
                step = true;
            }
        }
        if (waveslice != 0)
        {
            float translateChange = waveslice * bobbingAmount;
            float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;
            cSharpConversion.y = midpoint + translateChange;
        }
        else
        {
            cSharpConversion.y = midpoint;
        }

        /*if(horizontal != 0 || vertical != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (stepTimer > runStepTime)
                {
                    audioSource.PlayOneShot(walking[Random.Range(0, walking.Length)]);
                    stepTimer = 0;
                }
            }
            else
            {
                if (stepTimer > stepTime)
                {
                    audioSource.PlayOneShot(walking[Random.Range(0, walking.Length)]);
                    stepTimer = 0;
                }
            }
            stepTimer += Time.deltaTime;
        }else
            stepTimer = 0;*/

        if (step)
        {
            audioSource.PlayOneShot(walking[Random.Range(0, walking.Length)]);
            step = false;
        }

        transform.localPosition = cSharpConversion;
    }



}
