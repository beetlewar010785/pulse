using PulseTD.Core.Path;
using PulseTD.Core.Spline;
using Zenject;

namespace PulseTD.Game
{
    public class GameInstaller : MonoInstaller
    {
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            var mapGrid = new MapGrid(20, 20);
            Container.BindInstance(mapGrid).AsSingle();
            Container.Bind<ILogicalMap>().FromInstance(mapGrid).AsSingle();
            Container.Bind<IPathFinder>().To<AStarPathFinder>().AsSingle();
            Container.Bind<ICellToWorldPathConverter>().To<CellCenterCellToWorldPathConverter>().AsSingle().WithArguments(Settings.CellSize);
            Container.Bind<IWaypointsToSplineConverter>().To<CatmullRomWaypointsToSplineConverter>().AsSingle().WithArguments(Settings.CatmullRomSamplesPerSegment);
            Container.Bind<Follower>().AsSingle();
        }
    }
}
