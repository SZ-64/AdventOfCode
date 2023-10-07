using Common.Grid;

namespace Day6
{
    public interface IProcessLights
    {
        /// <summary>
        /// Processes the "turn lights on" instruction.
        /// </summary>
        void TurnLightsOn(Dictionary<int, Light> lights, Point p1, Point p2);

        /// <summary>
        /// Processes the "turn lights off" instruction.
        /// </summary>
        void TurnLightsOff(Dictionary<int, Light> lights, Point p1, Point p2);

        /// <summary>
        /// Processes the "toggle" instruction.
        /// </summary>
        void ToggleLights(Dictionary<int, Light> lights, Point p1, Point p2);

        /// <summary>
        /// Adjusts all the lights in the given rectangular range to the specified value.
        /// </summary>
        void SetLights(Dictionary<int, Light> lights, Point p1, Point p2, bool value, bool toggle = false);

        /// <summary>
        /// Parses one instruction by returning the appropriate function to call.
        /// </summary>
        public Action<Dictionary<int, Light>, Point, Point> LightFunction(string func);
    }
}
