using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    private Slider slider;
    private Button button;
    private TextMeshProUGUI text;

    public bool isAsync;

    private AsyncOperation loadOperation;
    
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        button = GetComponent<Button>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        
        button.onClick.AddListener(OnClick);
        slider.onValueChanged.AddListener(OnChange);
        
        text.gameObject.SetActive(false);
        button.enabled = false;

        if (isAsync)
        {
            loadOperation = SceneManager.LoadSceneAsync("Menu");
            loadOperation.allowSceneActivation = false;
        }
    }

    
    void Update()
    {
        if (isAsync)
        {
            if (slider.value < 1)
            {
                slider.value = Mathf.Clamp01(loadOperation.progress / 0.9f);
            }
            else
            {
                text.gameObject.SetActive(true);
                button.enabled = true;
            }
        }
        else
        {
            StartCoroutine(LoadBar());
        }
    }

    private void OnClick()
    {
        if (isAsync)
        {
            loadOperation.allowSceneActivation = true;
            DOTween.Clear();
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void OnChange(float value)
    {
        if (slider.value < 0.95f)
        slider.handleRect.DORotate(new Vector3(0, 0, -360), 2, RotateMode.FastBeyond360).SetEase(Ease.Linear);
    }

    private IEnumerator LoadBar()
    {
        slider.DOValue(1, 2f);
        yield return new WaitForSeconds(3f);
        text.gameObject.SetActive(true);
        button.enabled = true;
    }
    
}
