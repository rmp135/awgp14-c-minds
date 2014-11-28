
namespace CSharpMinds.Interfaces
{
    public interface IComponent
    {
        GameObject Owner { get; set; }
        string Name { get; set; }
        bool Enabled { get; set; }
        void Initialise();
        void Destroy();
    }
}
