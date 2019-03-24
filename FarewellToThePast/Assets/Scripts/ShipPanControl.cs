using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPanControl : MonoBehaviour
{
    const float DEFAULT_MOVE_SPEED = 10f;
    const float LERP_SPEED = 0.1f;
    const float ROLL_SPEED = 0.1f;

    const float MAX_ROLL = 10f;
    Transform mTransform;
    Vector3 targetLocation;
    float verticalMaxPan;
    float horizontalMaxPan;
    // Start is called before the first frame update
    void Awake()
    {
        mTransform = GetComponent<Transform>();
        targetLocation = mTransform.localPosition;

        // 2.5f to make model stay fully within the boundaries
        verticalMaxPan = Mathf.Abs(
            Camera.main.transform.localPosition.z * 
            Mathf.Tan(
                Camera.main.fieldOfView / 2.5f * Mathf.Deg2Rad
            )
        );
        horizontalMaxPan = Camera.main.aspect * verticalMaxPan;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        // var movementReference = mTransform.localPosition - targetLocation;
        // movementReference *= ROLL_SPEED;
        // mTransform.localRotation = Quaternion.Euler(movementReference.y, movementReference.z, movementReference.x);

        // mTransform.localPosition = Vector3.Lerp(mTransform.localPosition, targetLocation, LERP_SPEED);
    }
    
    // X-Axis functions
    public void LeftPan(float speed = DEFAULT_MOVE_SPEED) {
        targetLocation -= Vector3.right * speed;
        targetLocation.x = Mathf.Max(targetLocation.x, -horizontalMaxPan);
    }

    public void RightPan(float speed = DEFAULT_MOVE_SPEED) {
        targetLocation += Vector3.right * speed;
        targetLocation.x = Mathf.Min(targetLocation.x, horizontalMaxPan);
    }

    public void LeftRoll() {
        var targetRotation = Quaternion.Euler(
            mTransform.localRotation.eulerAngles.x,
            -MAX_ROLL,
            mTransform.localRotation.eulerAngles.z
        );
        mTransform.localRotation = Quaternion.Lerp(
            mTransform.localRotation,
            targetRotation,
            ROLL_SPEED
        );
    }

    public void RightRoll() {
        var targetRotation = Quaternion.Euler(
            mTransform.localRotation.eulerAngles.x,
            MAX_ROLL,
            mTransform.localRotation.eulerAngles.z
        );
        mTransform.localRotation = Quaternion.Lerp(
            mTransform.localRotation,
            targetRotation,
            ROLL_SPEED
        );
    }

    public void FixHorizontalRoll() {
        var targetRotation = Quaternion.Euler(
            mTransform.localRotation.eulerAngles.x,
            0,
            mTransform.localRotation.eulerAngles.z
        );
        mTransform.localRotation = Quaternion.Lerp(
            mTransform.localRotation,
            targetRotation,
            ROLL_SPEED
        );
    }

    // Y-Axis functions
    public void UpPan(float speed = DEFAULT_MOVE_SPEED) {
        targetLocation += Vector3.up * speed;
        targetLocation.y = Mathf.Min(targetLocation.y, verticalMaxPan);
    }

    public void DownPan(float speed = DEFAULT_MOVE_SPEED) {
        targetLocation -= Vector3.up * speed;
        targetLocation.y = Mathf.Max(targetLocation.y, -verticalMaxPan);
    }

    public void UpRoll() {
        var targetRotation = Quaternion.Euler(
            -MAX_ROLL,
            mTransform.localRotation.eulerAngles.y,
            mTransform.localRotation.eulerAngles.z
        );
        mTransform.localRotation = Quaternion.Lerp(
            mTransform.localRotation,
            targetRotation,
            ROLL_SPEED
        );
    }

    public void DownRoll() {
        var targetRotation = Quaternion.Euler(
            MAX_ROLL,
            mTransform.localRotation.eulerAngles.y,
            mTransform.localRotation.eulerAngles.z
        );
        mTransform.localRotation = Quaternion.Lerp(
            mTransform.localRotation,
            targetRotation,
            ROLL_SPEED
        );
    }

    public void FixVerticalRoll() {
        var targetRotation = Quaternion.Euler(
            0,
            mTransform.localRotation.eulerAngles.y,
            mTransform.localRotation.eulerAngles.z
        );
        mTransform.localRotation = Quaternion.Lerp(
            mTransform.localRotation,
            targetRotation,
            ROLL_SPEED
        );
    }
}
