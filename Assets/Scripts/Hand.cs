using System.Collections;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [Header("Hand Settings")]
    [SerializeField] float moveDuration = 2.0f;
    [SerializeField] float draggedObjectScale = 1.18182f;
    [SerializeField] Vector3 handOffsetToRobot = new Vector3(-0.5f, 0.5f, 0);
    [SerializeField] float waitTimeBeforeMovingUp = 0.8f;
    public GameObject Robot;
    public GameObject ShadowRobot;

    private bool isMovingDown = true;
    private bool transitionHandled = false;
    private bool firstHandMove = true;
    private float timeElapsed = 0f;
    private Vector3 startHandPosition;
    private Vector3 initialHandPosition;
    private Vector3 initialRobotPosition;
    private Vector3 robotShadowPosition;

    private SpriteRenderer handSpriteRenderer;

    void Start()
    {
        startHandPosition = transform.position;
        initialHandPosition = transform.position;
        initialRobotPosition = Robot.transform.position;
        robotShadowPosition = ShadowRobot.transform.position;
        handSpriteRenderer = GetComponent<SpriteRenderer>();  
    }

    void Update()
    {
        moveHand();
    }

    private void moveHand()
    {
        if (timeElapsed < moveDuration)
        {
            UpdateHandPosition(initialRobotPosition, robotShadowPosition, true);
        }
        else if (!transitionHandled)
        {
            StartCoroutine(handleTransition());
            transitionHandled = true;
        }
    }

    public void UpdateHandPosition(Vector3 targetObjectPosition, Vector3 targetShadowPosition, bool isFirst)
    {
        if (!isFirst)
        {
            timeElapsed = 0;
            isMovingDown = true;
            transitionHandled = false;
            handSpriteRenderer.enabled = true;
            initialRobotPosition = targetObjectPosition;
            robotShadowPosition = targetShadowPosition;
        }

        timeElapsed += Time.deltaTime;
        if (isMovingDown)
        {
            transform.position = Vector3.Lerp(initialHandPosition, targetObjectPosition + handOffsetToRobot, timeElapsed / moveDuration);
        }
        else
        {
            transform.position = Vector3.Lerp(initialHandPosition, targetShadowPosition + handOffsetToRobot, timeElapsed / moveDuration);
            if (firstHandMove)
            {
                Robot.transform.position = Vector3.Lerp(initialRobotPosition, ShadowRobot.transform.position, timeElapsed / moveDuration);
            }
        }
    }

    private IEnumerator handleTransition()
    {
        yield return new WaitForSeconds(waitTimeBeforeMovingUp);

        if (isMovingDown)
        {
            if (firstHandMove)
            {
                Robot.transform.localScale *= draggedObjectScale;
            }
            initialHandPosition = transform.position;
            isMovingDown = false;
            timeElapsed = 0f;
            transitionHandled = false;
        }
        else
        {
            if (firstHandMove)
            {
                Robot.transform.position = initialRobotPosition;
                firstHandMove = false;
            }
            handSpriteRenderer.enabled = false;
            initialHandPosition = startHandPosition;
        }
    }
}
