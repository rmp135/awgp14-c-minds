namespace Common.Interfaces
{
    public interface IRenderDriver
    {
        void DrawSprite(string spriteName, Vector pos, Vector scale, int rotation);

        void DrawSprite(string spriteName, Vector pos, Vector scale);

        void DrawSprite(string spriteName, Vector position);

        void DrawText(string text, Vector pos);

        void DrawLine(Vector start, Vector end);

        void PreRender();

        void PostRender();
    }
}