using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform meshTransform;
    public Transform lightTransform;
    public Animator animator;
    public Vector2 movement;
    public float maxVelocity = 100;
    public float speed = 50;
    public float rotationSpeed = 10.0f;
    public float friction;
    private bool paused = true;

    float yAxis, xAxis;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!paused)
        {
            yAxis = Input.GetAxis("Vertical");
            xAxis = Input.GetAxis("Horizontal");
        }

        animator.SetFloat("Horizontal Axis", xAxis);
        Rotate(transform, xAxis * -rotationSpeed);

        lightTransform.Rotate(1.0f, 0.0f, 0.0f);

        meshTransform.localScale = new Vector3(1.0f, Mathf.Max(1.0f, (yAxis * 1.1f)), 1.0f);

    }
    void FixedUpdate()
    {
        moveForward(yAxis);
    }

    void moveForward(float thrust)
    {
        Vector2 direction = new Vector2(xAxis, yAxis);
        Vector2 force = (direction * thrust * speed) * yAxis;
        rb.AddRelativeForce(force);
    }

    void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x, y);

    }

    private void Rotate(Transform t, float amount)
    {
        t.Rotate(0, 0, amount);
    }

    //Event Listner---------------------------------------------------------------------------------
    public List<EventRelay.EventMessageType> eventsHandled = new List<EventRelay.EventMessageType>();

    void OnEnable()
    {
        EventRelay.OnEventAction += HandleEvent;
    }

    void OnDisable()
    {
        EventRelay.OnEventAction -= HandleEvent;
    }

    string HandleEvent(EventRelay.EventMessageType messageType, MonoBehaviour sender)
    {
        if (messageType == EventRelay.EventMessageType.GameStart)
        {
            paused = false;
        }
        if (messageType == EventRelay.EventMessageType.GameOver)
        {
            paused = true;
        }

        if (eventsHandled.Contains(messageType))
        {
            Debug.Log(this.name + " handled event: " + messageType + " from sender: " + sender);
            return this.ToString();
        }
        else
        {
            return this.ToString();
        }
    }
    //------------------------------------------------------------------------------------------------
}