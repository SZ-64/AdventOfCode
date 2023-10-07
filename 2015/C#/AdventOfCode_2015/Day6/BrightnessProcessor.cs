using Common.Grid;

namespace Day6
{
    public class BrightnessProcessor : IProcessLights
    {
        /// <summary>
        /// Increases the brightness of the lights in the specified rectangular range by 1.
        /// </summary>
        public void TurnLightsOn(Dictionary<int, Light> lights, Point p1, Point p2) => SetLights(lights, p1, p2, true);

        /// <summary>
        /// Decreases the brightness of the lights in the specified rectangular range by 1.
        /// Brightness cannot go below zero.
        /// </summary>
        public void TurnLightsOff(Dictionary<int, Light> lights, Point p1, Point p2) => SetLights(lights, p1, p2, false);

        /// <summary>
        /// Increases the brightness of the lights in the specified rectangular range by 2.
        /// </summary>
        public void ToggleLights(Dictionary<int, Light> lights, Point p1, Point p2) => SetLights(lights, p1, p2, false, true);

        /// <summary>
        /// Updates the brightness for all the lights in the given rectangular range.
        /// Brightness cannot fall below zero.
        /// </summary>
        public void SetLights(Dictionary<int, Light> lights, Point p1, Point p2, bool value, bool toggle = false)
        {
            for (int i = p1.X; i <= p2.X; i++)
            {
                for (int j = p1.Y; j <= p2.Y; j++)
                {
                    lights[i + j * GridSettings.MAX_WIDTH].Brightness += toggle ? 2 : value ? 1 : -1;

                    if (lights[i + j * GridSettings.MAX_WIDTH].Brightness < 0)
                        lights[i + j * GridSettings.MAX_WIDTH].Brightness = 0;
                }
            }
        }

        /// <inheritdoc/>
        public Action<Dictionary<int, Light>, Point, Point> LightFunction(string func)
        {
            switch (func)
            {
                case "on":
                    return TurnLightsOn;
                case "off":
                    return TurnLightsOff;
                default:
                    return ToggleLights;
            }
        }
    }
}
