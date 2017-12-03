using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

using SciFiWest.Objects;

namespace SciFiWest.Containers
{
    class Zone
    {
        // Zone Properties
        public int x { get; set; }
        public int y { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        // Drawing Layers
        private Base zoneBase;
        private List<Object> layer2 = new List<Object>(); // Background lvl 1 // Can't collide
        private List<Object> layer3 = new List<Object>(); // Background lvl 2 // Can collide
        private List<Object> layer4 = new List<Object>(); // Foreground lvl 1 // Can collide
        private List<Object> layer5 = new List<Object>(); // Foreground lvl 2 // Can't collide

        public Zone(int ID)
        {
            x = -600;
            y = -800;
            height = 1200;
            width = 1200;
            zoneBase = new Base(x, y, width, height);
            // Fill zone with external stuff - gonna manually fill this for the moment
            // MUST ALWAYS ADD THE ZONEs X & Y to internal objects X & Y 
            // Road 1
            layer5.Add(new Road((-20 + x), (150 + y), 300, 100));
            layer5.Add(new Road((280 + x), (150 + y), 300, 100));
            layer5.Add(new Road((580 + x), (150 + y), 300, 100));
            layer5.Add(new Road((880 + x), (150 + y), 300, 100));
            layer5.Add(new Road((1180 + x), (150 + y), 300, 100));
            // Road 2
            layer5.Add(new Road((-20 + x), (270 + y), 300, 100));
            layer5.Add(new Road((280 + x), (270 + y), 300, 100));
            layer5.Add(new Road((580 + x), (270 + y), 300, 100));
            layer5.Add(new Road((880 + x), (270 + y), 300, 100));
            layer5.Add(new Road((1180 + x), (270 + y), 300, 100));
        }

        public void drawBackground(SpriteBatch spriteBatch)
        {
            zoneBase.draw(spriteBatch);
            foreach (Object obj in layer2)
            {
                obj.draw(spriteBatch);
            }
            foreach (Object obj in layer3)
            {
                obj.draw(spriteBatch);
            }
        }

        public void drawForeground(SpriteBatch spriteBatch)
        {
            foreach (Object obj in layer4)
            {
                obj.draw(spriteBatch);
            }
            foreach (Object obj in layer5)
            {
                obj.draw(spriteBatch);
            }
        }
    }
}
