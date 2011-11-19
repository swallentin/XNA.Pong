using Microsoft.Xna.Framework;

namespace Game.Base.Helpers
{
    public static class SpriteHelper
    {
        public static Vector2 GetAbsolutePosition(Vector2 relativePosition, GraphicsDeviceManager graphicsDeviceManager)
        {
            return new Vector2(GetAbsoluteWidth(relativePosition.X, graphicsDeviceManager),
                               GetAbsoluteHeight(relativePosition.Y, graphicsDeviceManager));
        }

        public static float GetAbsoluteHeight(float relativHeight, GraphicsDeviceManager graphicsDeviceManager)
        {
            return graphicsDeviceManager.GraphicsDevice.Viewport.Height * relativHeight;
        }

        public static float GetAbsoluteWidth(float relativeWidth, GraphicsDeviceManager graphicsDeviceManager)
        {
            return graphicsDeviceManager.GraphicsDevice.Viewport.Width * relativeWidth;
        }
    }
}
