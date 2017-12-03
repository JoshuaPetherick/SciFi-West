using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SciFiWest.Functionality
{
    public static class TextureManager
    {
        // UI - [ui]

        // Characters - [char]
        public static Texture2D charPlayerTexture { get; set; }
        // Zones - [zone]
        public static Texture2D zoneBaseTexture { get; set; }
        public static Texture2D zoneRoadTexture { get; set; }
        public static Texture2D zoneDoorTexture { get; set; }
        // Combat - [combat]
        public static Texture2D combatBanditTexture { get; set; }
        // Miscellaneous - [misc]

        public static void Load(ContentManager content)
        {
            charPlayerTexture = content.Load<Texture2D>("bot");
            zoneBaseTexture = content.Load<Texture2D>("base");
            zoneRoadTexture = content.Load<Texture2D>("road");
        }
    }
}
