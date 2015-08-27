using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using Game.Controllers;

namespace Game
{
    public class GameContext : MVCSContext
    {
        public GameContext(MonoBehaviour view)
            : base(view)
        {
        }

        public GameContext(MonoBehaviour view, ContextStartupFlags flags)
            : base(view, flags)
        {
        }

        // Unbind the default EventCommandBinder and rebind the SignalCommandBinder
        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }

        // Override Start so that we can fire the StartSignal
        override public IContext Start()
        {
            base.Start();

            var startSignal = injectionBinder.GetInstance<GameStartSignal>();
            startSignal.Dispatch();

            return this;
        }

        protected override void mapBindings()
        {
            //Commands & Signals
            commandBinder.Bind<GameStartSignal>().To<GameStartCommand>();

            //Singleton signals
            //injectionBinder.Bind<PlayerMovedSignal>().ToSingleton();

            //Models
            //injectionBinder.Bind<IPlayer>().To<Player>().ToSingleton();

            //Mediation
            //mediationBinder.Bind<LevelSceneView>().To<LevelSceneMediator>();

            //Services
            //injectionBinder.Bind<ILevelGenerator>().To<SpecificLevelGenerator>();
        }

        protected override void postBindings()
        {
            var context = (contextView as GameObject);
            var camera = context.GetComponentInChildren<UnityEngine.Camera>();
            injectionBinder.Bind<UnityEngine.Camera>().ToValue(camera);

            var configs = context.GetComponentInChildren<GameConfigs>();
            injectionBinder.Bind<GameConfigs>().ToValue(configs);
        }
    }
}

