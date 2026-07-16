using YG;

public class InterstitialAdsProvider
{
    public void RaiseValue()
    {
        YG2.saves.InterstitialAdsCount++;

        if (YG2.saves.InterstitialAdsCount == 5 && YG2.saves.IsPaymentAds == false)
        {
            YG2.InterstitialAdvShow();
            YG2.saves.InterstitialAdsCount = 0;
        }
    }
}