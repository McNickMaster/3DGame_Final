using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public GameObject CameraGroup;

    public Vector3 init_offset = Vector3.zero;

    public float bob_length = 1;
    public float bob_intensity = 0.1f;
    private Vector3 bob_offset = Vector3.zero, sway_offset = Vector3.zero;

    private float x = 0;
    private bool left_sway = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Bob();


        CameraGroup.transform.localPosition = init_offset + bob_offset + sway_offset;
    }


    void Bob()
    {
        float magnitude = PlayerMovement.instance.GetComponent<Rigidbody>().velocity.magnitude;

        if (Mathf.Abs(magnitude) >= 0.1f)
        {
                

            x += Mathf.Abs(magnitude) * Time.deltaTime;

            
            
            // sin curve on a set period that runs through delta pos
            bob_offset = new Vector3(0,  Mathf.Abs(Mathf.Sin(x / bob_length)), 0) * bob_intensity;
        }
        else
        {
            x = 0;
            bob_offset = Vector3.zero;
        }
    }

    void Sway()
    {
        sway_offset = new Vector3(0.3f, 0, 0);
        sway_offset *= left_sway ? 1:-1;

        left_sway = !left_sway;
    }


    public Vector3 GetTranslationOffset()
    {
        return bob_offset;
    }
}

