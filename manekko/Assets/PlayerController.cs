using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    public string currentPose; // 現在のポーズ

    private void Update()
    {
        if (Input.GetKeyDown(upKey))
        {
            currentPose = "Up";
            Debug.Log("Up");
        }
        else if (Input.GetKeyDown(downKey))
        {
            currentPose = "Down";
            Debug.Log("Down");
        }
        else if (Input.GetKeyDown(leftKey))
        {
            currentPose = "Left";
            Debug.Log("Left");
        }
        else if (Input.GetKeyDown(rightKey))
        {
            currentPose = "Right";
            Debug.Log("Right");
        }
    }
}
