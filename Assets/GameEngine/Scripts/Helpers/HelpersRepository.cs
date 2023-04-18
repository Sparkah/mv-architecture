using GameEngine.Base;
using GameEngine.Scripts.Base.SaveLoadGame;

namespace GameEngine.Scripts.Helpers
{
    public abstract class HelpersRepository : DataRepository<int>
    {

        protected override string Key { get; }
    }
}
