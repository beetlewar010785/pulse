using PulseTD.Core.Map;
using PulseTD.Core.Path;
using UnityEngine;
using Zenject;

namespace PulseTD.Game
{
    public class GameInstaller : MonoInstaller
    {
        public GameObject creepPrefab = null!;

        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            var mapGrid = new MapGrid(Settings.MapWidth, Settings.MapHeight, Settings.CellSize);
            Container.BindInstance(mapGrid).AsSingle();

            Container.Bind<ILogicalMap>().FromInstance(mapGrid).AsSingle();
            Container.Bind<IWorldToCellConverter>().FromInstance(mapGrid).AsSingle();
            Container.Bind<IPathFinder>().To<AStarPathFinder>().AsSingle();
            Container.Bind<IWorldPathBuilder>().To<CellCenterWorldPathBuilder>().AsSingle()
                .WithArguments(Settings.CellSize);
            Container.Bind<ISplineBuilder>().To<CatmullRomSplineBuilder>().AsSingle()
                .WithArguments(Settings.CatmullRomSamplesPerSegment);

            Container.Bind<PathFollower>().AsTransient();

            Container.BindFactory<Creep, Creep.Factory>()
                .FromComponentInNewPrefab(creepPrefab);
        }
    }
}