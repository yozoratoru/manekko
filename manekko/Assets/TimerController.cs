using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public AudioClip beepSound; // Beep sound to play
    public Text timerText; // Reference to the UI Text element

    private AudioSource audioSource;
    private bool timerRunning = false;
    private float startTime;
    private KeyCode[] startKeys = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    private KeyCode[] stopKeys = { KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L };
    private KeyCode currentStartKey;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timerText.text = "0.00"; // Initialize the timer text
    }

    void Update()
    {
        // Start the timer
        foreach (KeyCode startKey in startKeys)
        {
            if (Input.GetKeyDown(startKey))
            {
                if (!timerRunning)
                {
                    audioSource.PlayOneShot(beepSound);
                    startTime = Time.time;
                    timerRunning = true;
                    currentStartKey = startKey;
                    Debug.Log($"Timer started with {startKey} key");
                }
            }
        }

        // Stop the timer corresponding to the start key
        foreach (KeyCode stopKey in stopKeys)
        {
            if (Input.GetKeyDown(stopKey) && timerRunning && stopKey == GetStopKey(currentStartKey))
            {
                float elapsedTime = Time.time - startTime;
                timerRunning = false;
                Debug.Log($"Timer stopped at {elapsedTime:F2} seconds with {stopKey} key");
            }
        }

        // Update the timer display
        if (timerRunning)
        {
            float currentTime = Time.time - startTime;
            timerText.text = currentTime.ToString("F2");
        }
    }

    // Helper method to get the corresponding stop key for a given start key
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
}