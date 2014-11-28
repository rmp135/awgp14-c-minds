using Common;
namespace Common.Interfaces
{
    /// <summary>
    /// Allows components to be updated.
    /// </summary>
    public interface IUpdatable
    {
        void Update(GameTime gameTime);
    }
}