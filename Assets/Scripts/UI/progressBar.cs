using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class progressBar : MonoBehaviour
{
    [SerializeField] private ProgressCounter progressCounter;
    [SerializeField] private CanvasGroup cg;
    private float durationTime;
    private Image image;
    private bool IsShow;
    private void Awake()
    {
        image = GetComponent<Image>();
        progressCounter.handleUpdateProgress += CuttingCounter_handleUpdateProgress;
        image.fillAmount = 0;
        Hide();
        durationTime = 0.5f;
    }

    private void Start()
    {
      //  DOTween.Init();
    }

    private void CuttingCounter_handleUpdateProgress(object sender, UpdateProgress e)
    {
        image.fillAmount = e.progress;
        if (e.progress > 0 && e.progress < 1)
        {
            if (!isShow())
            {
                Show();
            }
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        image.color = progressCounter.foodColor;
        IsShow = true;
        
        StartCoroutine(AnimeIEnumerator.StartIEnumerator(durationTime, (float t) =>
         {
             cg.alpha = t;
             if (t >= 1)
             {
                 
             }
         }));

    }

    private bool isShow()
    {
        return IsShow;
    }

    private void Hide()
    {
        IsShow = false;
        StartCoroutine(AnimeIEnumerator.StartIEnumerator(durationTime, (float t) =>
        {
            cg.alpha = 1 - t;
            if (t >= 1)
            {
            
            }
        }));
    }
}
