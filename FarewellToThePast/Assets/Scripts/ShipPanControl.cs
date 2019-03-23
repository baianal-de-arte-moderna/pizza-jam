using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPanControl : MonoBehaviour
{
    const float LERP_SPEED = 0.1f;
    const float ROLL_SPEED = 10f;
    Transform mTransform;
    Vector3 targetLocation;
    float verticalMaxPan;
    float horizontalMaxPan;
    // Start is called before the first frame update
    void Start()
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
        var movementReference = mTransform.localPosition - targetLocation;
        movementReference *= ROLL_SPEED;
        mTransform.rotation = Quaternion.Euler(movementReference.y, movementReference.z, movementReference.x);

        mTransform.localPosition = Vector3.Lerp(mTransform.localPosition, targetLocation, LERP_SPEED);
    }
    
    // X-Axis functions
    public void LeftPan(float speed) {
        targetLocation -= Vector3.right * speed;
        targetLocation.x = Mathf.Max(targetLocation.x, -horizontalMaxPan);
    }

    public void RightPan(float speed) {
        targetLocation += Vector3.right * speed;
        targetLocation.x = Mathf.Min(targetLocation.x, horizontalMaxPan);
    }

    public void LeftRoll(float speed) {
        mTransform.Rotate(Vector3.forward * -speed);
    }

    public void RightRoll(float speed) {
        mTransform.Rotate(Vector3.forward * speed);
    }

    // Y-Axis functions
    public void UpPan(float speed) {
        targetLocation += Vector3.up * speed;
        targetLocation.y = Mathf.Min(targetLocation.y, verticalMaxPan);
    }

    public void DownPan(float speed) {
        targetLocation -= Vector3.up * speed;
        targetLocation.y = Mathf.Max(targetLocation.y, -verticalMaxPan);
    }

    public void UpRoll(float speed) {
        mTransform.Rotate(Vector3.right * -speed);
    }

    public void DownRoll(float speed) {
        mTransform.Rotate(Vector3.right * speed);
    }
}
