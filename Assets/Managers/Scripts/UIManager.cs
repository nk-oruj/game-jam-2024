using UnityEngine;
using Cinemachine;
using System.Collections;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private GameObject _gameCanvas;

    [SerializeField] private float _menuLensSize = 8f;
    [SerializeField] private float _gameLensSize = 5f;

    protected override void Awake()
    {
        base.Awake();

        _menuCanvas.SetActive(true);
        _gameCanvas.SetActive(false);

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

        StartCoroutine(ZoomIn(.8f));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SwitchCharacter(CharacterType type)
    {
        CharacterSwitchManager.Instance.SwitchCharacter(type);
    }
}
