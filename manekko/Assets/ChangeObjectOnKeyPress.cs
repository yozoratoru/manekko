using UnityEngine;

public class ChangeObjectOnKeyPress : MonoBehaviour
{
    private Quaternion initialRotation; // 初期回転状態を保存するための変数
    private bool isWLocked = false; // Wキーのロック状態
    private bool isALocked = false; // Aキーのロック状態
    private bool isSLocked = false; // Sキーのロック状態
    private bool isDLocked = false; // Dキーのロック状態
    private bool isButtonLocked = false; // ボタンのロック状態

    void Start()
    {
        // 初期回転状態を保存
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // ボタンがロックされていない場合にのみキー入力を処理
        if (!isButtonLocked)
        {
            // Wキーが押され、かつロックされていない場合
            if (Input.GetKeyDown(KeyCode.W) && !isWLocked)
            {
                // 回転をリセットし、オブジェクトを-90度回転させる
                ResetRotation();
                transform.Rotate(0, -90, 0);
                LockKeys();  // Wキーが押された後にすべてのキーをロック
            }
            // Aキーが押され、かつロックされていない場合
            else if (Input.GetKeyDown(KeyCode.A) && !isALocked)
            {
                // 回転をリセットし、オブジェクトを180度回転させる
                ResetRotation();
                transform.Rotate(0, 180, 0);
                LockKeys();  // Aキーが押された後にすべてのキーをロック
            }
            // Sキーが押され、かつロックされていない場合
            else if (Input.GetKeyDown(KeyCode.S) && !isSLocked)
            {
                // 回転をリセットし、オブジェクトを90度回転させる
                ResetRotation();
                transform.Rotate(0, 90, 0);
                LockKeys();  // Sキーが押された後にすべてのキーをロック
            }
            // Dキーが押され、かつロックされていない場合
            else if (Input.GetKeyDown(KeyCode.D) && !isDLocked)
            {
                // 回転をリセットし、オブジェクトを0度の状態にする
                ResetRotation();
                transform.Rotate(0, 0, 0);
                LockKeys();  // Dキーが押された後にすべてのキーをロック
            }
        }
    }

    void ResetRotation()
    {
        // オブジェクトの回転を初期状態にリセット
        transform.rotation = initialRotation;
    }

    void LockKeys()
    {
        // いずれかのキーが押された後にすべてのキーをロック
        isWLocked = true;
        isALocked = true;
        isSLocked = true;
        isDLocked = true;
        isButtonLocked = true; // ボタンをロックする
    }

    // この関数は、ボタンや他のイベントから呼び出されてすべてのキーをロック解除する
    public void UnlockKeys()
    {
        // すべてのキーのロックを解除
        isWLocked = false;
        isALocked = false;
        isSLocked = false;
        isDLocked = false;
        isButtonLocked = false; // ボタンのロックを解除
    }

    // ボタンクリック時にキーのロック解除をトリガーする例
    public void OnButtonClicked()
    {
        // ボタンがクリックされたときにすべてのキーのロックを解除
        UnlockKeys();
        PlayerPrefs.SetFloat("ButtonClicked", 1); // ボタンがクリックされたことを保存
        PlayerPrefs.Save(); // PlayerPrefsを保存
    }
}
