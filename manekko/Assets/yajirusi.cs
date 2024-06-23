using UnityEngine;

public class Yajirusi : MonoBehaviour
{
    private Quaternion initialRotation;

    void Start()
    {
        // 初期の回転状態を保存
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            // オブジェクトを初期状態にリセットしてから右に90度回転させる
            ResetRotation();
            transform.Rotate(0, -90, 0);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            // オブジェクトを初期状態にリセットしてから左に180度回転させる
            ResetRotation();
            transform.Rotate(0, 180, 0);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            // オブジェクトを初期状態にリセットしてから左に90度回転させる
            ResetRotation();
            transform.Rotate(0, 90, 0);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            // オブジェクトを初期状態にリセットする
            ResetRotation();
        }
    }

    void ResetRotation()
    {
        // オブジェクトの回転を初期状態にリセット
        transform.rotation = initialRotation;
    }
}
