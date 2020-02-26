using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdManager : MonoBehaviour
{
    string gameId = "3479815";
    private string placementId = "BottomBanner";
    bool testMode = true;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(placementId);
    }
}
