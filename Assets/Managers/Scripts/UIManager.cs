using UnityEngine;
using Cinemachine;
using System.Collections;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private GameObject _gameCanvas;
    [SerializeField] private GameObject _buttonParrot;
    [SerializeField] private GameObject _buttonPenguin;

    [SerializeField] private float _menuLensSize = 8f;
    [SerializeField] private float _gameLensSize = 5f;
    [SerializeField] private float _transitionDuration = 1.6f;

    protected override void Awake()
    {
        base.Awake();

        _virtualCamera.m_Lens.OrthographicSize = _menuLensSize;
    }

    private IEnumerator ZoomIn(float duration)
    {
        for (float t = 0f; t < 1f; t += Time.deltaTime / duration)
        {
            _virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(_virtualCamera.m_Lens.OrthographicSize, _gameLensSize, t);
            yield return null;
        }

        _virtualCamera.m_Lens.OrthographicSize = _gameLensSize;
        yield return null;
    }

    public void StartGame()
    {
        _menuCanvas.SetActive(false);
        _gameCanvas.SetActive(true);

        StartCoroutine(ZoomIn(_transitionDuration));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EnableButtonParrot()
    {
        _buttonParrot.SetActive(true);
    }

    public void EnableButtonPinguin()
    {
        _buttonPenguin.SetActive(true);
    }

    public void SwitchCharacter(CharacterType type)
    {
        CharacterSwitchManager.Instance.SwitchCharacter(type);
    }
}
