using Common.Grid;

namespace Day6
{
    public class LightProcessor : IProcessLights
    {
        /// <summary>
        /// Turns all the lights in the given range to ON.
        /// Lights that are already ON will remain ON.
        /// </summary>
        public void TurnLightsOn(Dictionary<int, Light> lights, Point p1, Point p2) => SetLights(lights, p1, p2, true);

        /// <summary>
        /// Turns all the lights in the given range to OFF.
        /// Lights that are already OFF will remain OFF.
        /// </summary>
        public void TurnLightsOff(Dictionary<int, Light> lights, Point p1, Point p2) => SetLights(lights, p1, p2, false);

        /// <summary>
        /// Toggles all the lights in the given range to the opposite of its current state.
        /// </summary>
        public void ToggleLights(Dictionary<int, Light> lights, Point p1, Point p2) => SetLights(lights, p1, p2, false, true);

        /// <summary>
        /// Adjusts all the lights in the given rectangular range to the specified value.
        /// If the value is true, the lights will be set to ON. Otherwise, they will be set to OFF.
        /// If toggle is set to true, value is ignored and the light is set to its opposite.
        /// </summary>
        public void SetLights(Dictionary<int, Light> lights, Point p1, Point p2, bool value, bool toggle = false)
        {
            for (int i = p1.X; i <= p2.X; i++)
            {
                for (int j = p1.Y; j <= p2.Y; j++)
                {
                    if (toggle)
                        lights[i + j * GridSettings.MAX_WIDTH].IsOn = !lights[i + j * GridSettings.MAX_WIDTH].IsOn;
                    else
                        lights[i + j * GridSettings.MAX_WIDTH].IsOn = value;
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
