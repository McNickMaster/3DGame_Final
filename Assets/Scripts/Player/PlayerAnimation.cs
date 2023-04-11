using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public GameObject playerModel;
    public Transform orientation;
    public Animator animator;

    public float bob_length = 1;
    public float bob_intensity = 0.1f;
    public float sway_bounds = 3;
    public float sway_length = 1;
    public float sway_shift_intensity = 0.1f;
    private float bob_amount = 0;
    private Vector3 bob_scale = Vector3.zero;

    private float x = 0, init_scale;

    // Start is called before the first frame update
    void Start()
    {
        init_scale = playerModel.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        Bob();
        Sway();

        playerModel.transform.localScale = bob_scale * init_scale;


        if((PlayerMovement.instance.GetComponent<Rigidbody>().velocity.magnitude)> 0.1f)
        {
            animator.SetBool("walking", true);
        } else {
            animator.SetBool("walking", false);
        }
    }


    void Bob()
    {
        float magnitude = PlayerMovement.instance.GetComponent<Rigidbody>().velocity.magnitude;

        if (Mathf.Abs(magnitude) >= 0.1f)
        {
                

            x += Mathf.Abs(magnitude) * Time.deltaTime;

            
            
            // sin curve on a set period that runs through delta pos
            bob_amount = Mathf.Abs(Mathf.Sin(x / bob_length)) * bob_intensity;
        }
        else
        {
            x = 0;
            bob_amount = 0;
            
            
        }

        bob_scale = new Vector3(1 + bob_amount, 1 - bob_amount, 1 + bob_amount);
    }

    void Sway()
    {
        float sway_x = Mathf.Sin(x / sway_length);

        float angle = Mathf.Lerp((sway_bounds * sway_x), playerModel.transform.localRotation.z, 0.5f);
        playerModel.transform.localRotation = Quaternion.AngleAxis(angle, orientation.forward);
        //playerModel.transform.localPosition = new Vector3(sway_shift_intensity * sway_x, 0, 0);
    }
}
