using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveKeyboard : MonoBehaviour
{
    private Animator animator;

    public FMM motor;

    public Transform playerTransform;

    private Quaternion screenMovementSpace;

    private Vector3 screenMovementForward;

    private Vector3 screenMovementRight;

    private string AXIS_X = "Vertical";

    private string AXIS_Y = "Horizontal";

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();

        motor.movementDirection = Vector2.zero;
    }


    void Start()
    {
        screenMovementSpace = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        screenMovementForward = screenMovementSpace * Vector3.forward;
        screenMovementRight = screenMovementSpace * Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        motor.movementDirection = Input.GetAxis(AXIS_X) * screenMovementRight +
                                  Input.GetAxis(AXIS_Y) * screenMovementForward;

        if (Input.GetAxis(AXIS_X) != 0 || Input.GetAxis(AXIS_Y) != 0)
        {
            animator.SetBool(AnimationStates.ANIMATION_RUN,true);
        }
        else
        {
            {
                animator.SetBool(AnimationStates.ANIMATION_RUN,false);
            }
        }

        if (motor.movementDirection.sqrMagnitude > 1)
        {
            motor.movementDirection.Normalize();
        }

    }
}

