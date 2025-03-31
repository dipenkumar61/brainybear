using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneAutomation : MonoBehaviour
{
    public static SceneAutomation Instance;

    // Put scenes in the EXACT order you want them visited.
    public string[] automatedScenes;

    // Times to wait
    [SerializeField] private float menuWaitTime = 5f;        // Wait time for Menu scenes
    [SerializeField] private float otherWaitTime = 4f;       // Wait time for other scenes
    [SerializeField] private float inactivityThreshold = 8f; // Time without interaction before automation activates

    // We track our position in the array. -1 means "not set yet."
    private int currentIndex = -1;

    private Coroutine autoCoroutine;
    private Coroutine inactivityCoroutine;
    private bool automationEnabled = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Update()
    {
        // If user interacts, reset the inactivity timer
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            ResetInactivityTimer();
        }
    }

    /// <summary>
    /// Called automatically by Unity when a new scene is loaded.
    /// </summary>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Cancel any existing coroutines
        if (autoCoroutine != null)
        {
            StopCoroutine(autoCoroutine);
            autoCoroutine = null;
        }

        if (inactivityCoroutine != null)
        {
            StopCoroutine(inactivityCoroutine);
            inactivityCoroutine = null;
        }

        // Try to find this scene name in automatedScenes, starting from currentIndex+1
        int newIndex = FindSceneIndex(scene.name, currentIndex + 1);

        // If not found, wrap around to the beginning of the array
        if (newIndex == -1)
        {
            newIndex = FindSceneIndex(scene.name, 0);
        }

        // If we found it, update currentIndex and start monitoring for inactivity
        if (newIndex != -1)
        {
            // Debugging (optional):
            Debug.Log($"OnSceneLoaded: Found '{scene.name}' at index {newIndex} (prev index: {currentIndex})");
            currentIndex = newIndex;

            // Re-enable automation when a new scene loads
            automationEnabled = true;

            // Start the inactivity timer
            inactivityCoroutine = StartCoroutine(MonitorInactivity());
        }
        else
        {
            // Scene not in automated list (or not found).
            Debug.Log($"OnSceneLoaded: Scene '{scene.name}' not found in automation list. Doing nothing.");
        }
    }

    /// <summary>
    /// Reset the inactivity timer by stopping and restarting the coroutine
    /// </summary>
    private void ResetInactivityTimer()
    {
        // If automation has been disabled for this scene, don't restart the timer
        if (!automationEnabled)
            return;

        // Cancel the current automation if it's running
        if (autoCoroutine != null)
        {
            StopCoroutine(autoCoroutine);
            autoCoroutine = null;
        }

        // Restart the inactivity timer
        if (inactivityCoroutine != null)
        {
            StopCoroutine(inactivityCoroutine);
        }
        inactivityCoroutine = StartCoroutine(MonitorInactivity());
    }

    /// <summary>
    /// Monitor for user inactivity. If user is inactive for inactivityThreshold,
    /// start the automation process.
    /// </summary>
    private IEnumerator MonitorInactivity()
    {
        // Wait for the inactivity threshold
        yield return new WaitForSeconds(inactivityThreshold);

        // If we got here, user was inactive for the threshold duration
        // Start the auto-advance process
        if (automationEnabled)
        {
            autoCoroutine = StartCoroutine(AutoAdvance());
        }
    }

    /// <summary>
    /// Searches for the given sceneName in automatedScenes, starting at index 'start'.
    /// Returns the index if found, or -1 if not found.
    /// </summary>
    private int FindSceneIndex(string sceneName, int start)
    {
        for (int i = start; i < automatedScenes.Length; i++)
        {
            if (automatedScenes[i] == sceneName)
                return i;
        }
        return -1;
    }

    /// <summary>
    /// Wait for menuWaitTime or otherWaitTime, then move on to the next scene in the array.
    /// </summary>
    private IEnumerator AutoAdvance()
    {
        // Determine how long to wait in this scene
        string currentSceneName = automatedScenes[currentIndex];
        float waitTime = (currentSceneName == "Menu") ? menuWaitTime : otherWaitTime;

        // Wait for the specified time
        yield return new WaitForSeconds(waitTime);

        // Now move on to the next scene in the array (if any)
        int nextIndex = currentIndex + 1;
        if (nextIndex < automatedScenes.Length)
        {
            Debug.Log($"AutoAdvance: Loading next scene '{automatedScenes[nextIndex]}' (index {nextIndex})");
            SceneManager.LoadScene(automatedScenes[nextIndex]);
        }
        else
        {
            Debug.Log("AutoAdvance: Reached end of automatedScenes. No more auto-loading.");
        }
    }

    /// <summary>
    /// Call this to completely disable the automation for the current scene
    /// </summary>
    public void DisableAutomation()
    {
        automationEnabled = false;

        if (inactivityCoroutine != null)
        {
            StopCoroutine(inactivityCoroutine);
            inactivityCoroutine = null;
        }

        if (autoCoroutine != null)
        {
            StopCoroutine(autoCoroutine);
            autoCoroutine = null;
        }
    }
}