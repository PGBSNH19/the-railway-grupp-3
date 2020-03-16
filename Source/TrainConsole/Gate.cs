namespace TrainConsole
{
   public class Gate
    {
        private static bool _isGateOpen = false;


        public static bool IsGateOpen()
        {
            return _isGateOpen;
        }

        public void ToggleGate()
        {
            if (_isGateOpen)
            {
                _isGateOpen = false;
            }
            else
            {
                _isGateOpen = true;               
            }
        }

        

    }
}
