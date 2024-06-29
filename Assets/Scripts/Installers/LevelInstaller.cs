using Zenject;
using UnityEngine;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private LevelManager m_levelMamager;
    [SerializeField] private CountdownTimer m_countdownTimer;
    [SerializeField] private BaseGrid m_baseGrid;
    [SerializeField] private HealthUIManager m_healthUIManager;


    public override void InstallBindings()
    {
        Container.BindInstance(m_levelMamager).AsSingle().NonLazy();
        Container.BindInstance(m_countdownTimer).AsSingle().NonLazy();
        Container.BindInstance(m_baseGrid).AsSingle().NonLazy();
        Container.Bind<HealthUIManager>().FromInstance(m_healthUIManager).AsSingle();

    }
}   