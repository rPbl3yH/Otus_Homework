using TMPro;

public class StartCounterListener : IStartCounterListener
{
    private IStartCounterFinishListener _finishListener;
    private TMP_Text _countText;

    public StartCounterListener(IStartCounterFinishListener finishListener, TMP_Text countText) {
        _countText = countText;
        _finishListener = finishListener;
    }

    void IStartCounterListener.OnCounterChanged(int count) {
        _countText.gameObject.SetActive(count != 0);
        _countText.text = count.ToString();

        if (count == 0) {
            _finishListener.OnStartCountFinished();
        }
    }
}
