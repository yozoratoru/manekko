using UnityEngine;

public class PoseChecker : MonoBehaviour
{
    public GameObject correctPoseIndicator;
    private bool isCorrectPose = false;
    public PlayerController playerController; // プレイヤーのコントローラー

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow"))
        {
            Arrow arrow = collision.GetComponent<Arrow>();
            if (arrow != null && arrow.direction == GetPlayerPoseDirection())
            {
                isCorrectPose = true;
                correctPoseIndicator.SetActive(true);
                Destroy(collision.gameObject);
            }
        }
    }

    private string GetPlayerPoseDirection()
    {
        return playerController.currentPose; // プレイヤーの現在のポーズを取得
    }

    private void Update()
    {
        if (isCorrectPose)
        {
            // 正しいポーズを取った後の処理
            isCorrectPose = false;
            correctPoseIndicator.SetActive(false);
        }
    }
}
