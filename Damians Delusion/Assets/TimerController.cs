using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;


public class TimerController : MonoBehaviour
{
    public float initialTimeAvailable = 2;
    public PostProcessVolume volume;
    public playerMovement mov;
    public cameraLook cam;
    public GameObject gameOverUI;

    private float timeLeft;
    private bool activeTimer;
    private bool dying = false;
    private Quaternion originalRotation;
    private Vignette vig;

    Vector3 initPos;


    [FMODUnity.EventRef]
    public string stepSoundEvent = "event:/Player/Tile_Room_Footsteps/TileStep4";
    FMOD.Studio.EventInstance step;

    void Start()
    {
        activeTimer = true;
        timeLeft = initialTimeAvailable;
        volume.profile.TryGetSettings(out vig);
        if (gameOverUI == null) Debug.LogError("game over ui object is missing in timer controller");
        gameOverUI.SetActive(false);

        step = FMODUnity.RuntimeManager.CreateInstance(stepSoundEvent);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(step, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    void Update()
    {
        if (!activeTimer) return;
        timeLeft -= Time.deltaTime;

        if (dying)
        {
            UpdateCamFalling();
            if (timeLeft <= -1) StartCoroutine(DeadStepSounds());
            return;
        }
        UpdateVignette();

        if (timeLeft <= 0) StartDying();
    }

    public void AddTime(float time)
    {
        timeLeft += time;
        if (timeLeft > initialTimeAvailable) initialTimeAvailable = timeLeft;
    }

    public void PauseTimer()
    {
        activeTimer = false;
    }

     public void StartTimer()
    {
        activeTimer = true;
    }

    private void UpdateVignette()
    {
        float result = Mathf.InverseLerp(initialTimeAvailable, 0f, timeLeft);
        float nextValue = Mathf.Lerp(0.45f, 1.0f, result);
        vig.intensity.value = nextValue;
    }

    private void UpdateCamFalling()
    {
        float result = Mathf.InverseLerp(0f, -1f, timeLeft);
        float yPos = ExpoInterp(initPos.y, 1f, result);
        float zRot = ExpoInterp(0f, 100f, result);
        Debug.Log("" + result + " " + yPos + " " + zRot);
        cam.transform.position = new Vector3(cam.transform.position.x, yPos, cam.transform.position.z);
        Quaternion zQuat = Quaternion.AngleAxis(zRot, Vector3.forward);
        cam.transform.localRotation = originalRotation * zQuat; 
    }

    private void StartDying()
    {
        mov.enabled = false;
        cam.enabled = false;

        dying = true;
        originalRotation = cam.transform.localRotation;
        initPos = cam.transform.position;
    }

    private IEnumerator DeadStepSounds()
    {
        activeTimer = false;
        yield return new WaitForSeconds(0.5f);

        step.start();

        yield return new WaitForSeconds(0.6f);

        step.start();

        yield return new WaitForSeconds(0.6f);

        step.start();

        yield return new WaitForSeconds(0.6f);

        step.start();

        gameOverUI.SetActive(true);
        // enable mouse
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        yield return new WaitForSeconds(0.6f);

        step.start();

        yield return new WaitForSeconds(0.6f);

        step.start();

        yield return new WaitForSeconds(0.6f);

        step.start();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    private float ExpoInterp(float start, float end, float value)
    {
        end -= start;
        return end * Mathf.Pow(2f, 5 * (value - 1)) + start;
    }
}
