using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI countdownText;
    private const string NUMBER_POPUP = "NumberPopUp";

    private Animator animator;

    private int previousCountdownNumber;

    private void Awake() {
        animator = GetComponent<Animator>(); 
    }
    private void Start() {
        GameHandler.Instance.OnStateChanged += GameHandler_OnStateChanged;
        Hide();
    }

    private void Update() {
        int countDownNumber = Mathf.CeilToInt(GameHandler.Instance.GetCountdownToStartTimer());
        if (countDownNumber != previousCountdownNumber) {
            SoundManager.Instance.PlayCountdownSound();
            animator.SetTrigger(NUMBER_POPUP);
            previousCountdownNumber = countDownNumber;
        }

        countdownText.text = countDownNumber.ToString();
    }

    private void GameHandler_OnStateChanged(object sender, System.EventArgs e) {
        if (GameHandler.Instance.IsCountdownToStartActive()) {
            Show();
        } else {
            Hide();
        }
    }

    public void Show() {
        gameObject.SetActive(true);
    }
    public void Hide() {
        gameObject.SetActive(false);
    }
}
