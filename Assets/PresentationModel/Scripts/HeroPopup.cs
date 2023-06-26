using UnityEngine;
using UnityEngine.UI;

public sealed class HeroPopup : MonoBehaviour
{
    [SerializeField] private HeroPopupStatsAdapter _statsAdapter;
    [SerializeField] private HeroPopupProgressView _progressView;
    [SerializeField] private HeroPopupUserView _userView;
    [SerializeField] private Button _closeButton;

    public void Show(IUserInfoPresentationModel userInfoPresentationModel,
        IHeroStatsPresentationModel heroStatsPresentationModel,
        IProgressPresentationModel progressPresentationModel)
    {
        gameObject.SetActive(true);
        //TODO: 
        _closeButton.onClick.AddListener(Hide);

        _statsAdapter.Show(heroStatsPresentationModel);
        _progressView.Show(progressPresentationModel);
        _userView.Show(userInfoPresentationModel);
    }

    public void Hide()
    {
        _statsAdapter.Hide();
        _progressView.Hide();
        _userView.Hide();
        gameObject.SetActive(false);
    }
}