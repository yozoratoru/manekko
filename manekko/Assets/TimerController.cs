using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TimerController : MonoBehaviour
{
    public AudioClip beepSound; // ビープ音を再生するためのサウンドクリップ
    public Text timerText; // UIのText要素への参照
    public Yajirusi yajirusi; // Yajirusiスクリプトへの参照

    private AudioSource audioSource; // オーディオソースコンポーネント
    private bool timerRunning = false; // タイマーが動作中かどうかを管理するフラグ
    private float startTime; // タイマー開始時間を記録
    private KeyCode[] startKeys = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D }; // タイマー開始に使用するキーの配列
    private KeyCode[] stopKeys = { KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L }; // タイマー停止に使用するキーの配列
    private KeyCode currentStartKey; // 現在タイマーを開始したキー
    private Quaternion initialRotation; // 初期回転状態を保存するための変数
    private bool isWLocked = false; // Wキーのロック状態
    private bool isALocked = false; // Aキーのロック状態
    private bool isSLocked = false; // Sキーのロック状態
    private bool isDLocked = false; // Dキーのロック状態
    void Start()
    {
        // AudioSourceコンポーネントを取得
        audioSource = GetComponent<AudioSource>();
        
        // タイマーの初期表示を「ready」に設定
        timerText.text = "ready";
    }

    void Update()
    {
        if (isWLocked )
        {
            return;
        }
        if (isALocked )
        {
            return;
        }
        if (isSLocked )
        {
            return;
        }
        if (isDLocked )
        {
            return;
        }
        // タイマーを開始する
        foreach (KeyCode startKey in startKeys)
        {
            // startKeysに含まれるキーが押されたらタイマーを開始
            if (Input.GetKeyDown(startKey))
            {
                // タイマーがまだ動いていない場合のみ開始
                if (!timerRunning)
                {
                    audioSource.PlayOneShot(beepSound); // ビープ音を再生
                    startTime = Time.time; // 現在の時間を記録
                    timerRunning = true; // タイマーが動作中であることを設定
                    currentStartKey = startKey; // 開始キーを記録
                    Debug.Log($"Timer started with {startKey} key"); // デバッグログに開始キーを表示
                }
            }
        }

        // タイマーを停止する（対応するキーでのみ停止可能）
        foreach (KeyCode stopKey in stopKeys)
        {
            // stopKeysに含まれるキーが押され、タイマーが動作中で、かつ対応する開始キーの場合のみ停止
            if (Input.GetKeyDown(stopKey))
            {
                if (timerRunning && stopKey == GetStopKey(currentStartKey))
                {
                    float elapsedTime = Time.time - startTime; // 経過時間を計算
                    timerRunning = false; // タイマーを停止
                    isWLocked = true;  // Wキーをロック
                    isALocked = true;  // Aキーをロック
                    isSLocked = true;  // Sキーをロック
                    isDLocked = true;  // Dキーをロック
                    Debug.Log($"Timer stopped at {elapsedTime:F2} seconds with {stopKey} key"); // デバッグログに停止時の経過時間を表示
                    
                    yajirusi.LockKeys();
                    // 3秒後にシーンをリセットするコルーチンを開始
                    StartCoroutine(ResetSceneAfterDelay(3f));
                }
                else
                {
                    // 正しくないキーが押された場合、ペナルティとして1秒加算
                    startTime -= 1f; // 経過時間を1秒戻す（つまり1秒ペナルティ）
                    Debug.Log($"Penalty: 1 second added for pressing wrong key: {stopKey}");
                }
            }
        }

        // タイマーが動作中の場合、UIに現在の経過時間を表示する
        if (timerRunning)
        {
            float currentTime = Time.time - startTime; // 経過時間を計算
            timerText.text = currentTime.ToString("F2"); // 経過時間を表示
        }
    }

    // 開始キーに対応する停止キーを取得するヘルパーメソッド
    private KeyCode GetStopKey(KeyCode startKey)
    {
        switch (startKey)
        {
            case KeyCode.W:
                return KeyCode.I;
            case KeyCode.A:
                return KeyCode.J;
            case KeyCode.S:
                return KeyCode.K;
            case KeyCode.D:
                return KeyCode.L;
            default:
                return KeyCode.None;
        }
    }

    // 一定時間後にシーンをリセットするためのコルーチン
    private IEnumerator ResetSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 指定した時間待機
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // シーンをリセット
    }
}
