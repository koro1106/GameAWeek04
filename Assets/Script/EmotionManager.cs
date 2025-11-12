using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System.Text.RegularExpressions;

public class EmotionManager : MonoBehaviour
{
    public Slider anger, sadness, motivation, sleepiness, hunger;
    public TextMeshProUGUI timerText;
    public GameObject resultPanel;
    public GameObject resultButton;
    public GameObject titleButton;
    public GameObject text; // 感情のテキスト
    public TextMeshProUGUI resultText;

    public float chaosRate = 0.001f; // スライダーの乱れる大きさ
    public float collapseValue = 1.2f;
    public float playTime = 15f;

    private Slider[] sliders;
    private bool isPlaying = true;

    void Start()
    {
        sliders = new Slider[] { anger, sadness, motivation, sleepiness, hunger };
        foreach (var s in sliders)
        {
            s.value = 0.5f;
            s.onValueChanged.AddListener((_) => CheckCollapse());
        }
        StartCoroutine(AutoChaos());
    }

    IEnumerator AutoChaos()
    {
        float time = playTime;
        while (isPlaying)
        {
            time -= Time.deltaTime;
            timerText.text = "残り時間: " + time.ToString("F1"); // 0.1秒単位で表示

            // スライダーが自然に乱れる
            foreach (var s in sliders)
            {
                s.value = Mathf.Clamp01(s.value + Random.Range(-chaosRate, chaosRate));
            }

            CheckCollapse();

            if (time <= 0f)
            {
                GameClear();
                yield break;
            }

            yield return null;
        }
    }

    void CheckCollapse()
    {
        float avg = 0f;
        foreach (var s in sliders) avg += s.value;
        avg /= sliders.Length;

        float variance = 0f;
        foreach (var s in sliders)
            variance += Mathf.Abs(s.value - avg);

        if (variance > collapseValue) GameOver();
    }

    void GameOver()
    {
        if (!isPlaying) return;
        isPlaying = false;
        resultPanel.SetActive(true);
        resultButton.SetActive(true);
        titleButton.SetActive(true);
        text.SetActive(false);
        resultText.text = "崩壊しました";
    }

    void GameClear()
    {
        isPlaying = false;
        resultPanel.SetActive(true);
        resultButton.SetActive(true);
        titleButton.SetActive(true);
        text.SetActive(false);
        resultText.text = "バランス維持成功";
    }
}
