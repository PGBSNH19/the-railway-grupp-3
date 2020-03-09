namespace TrainConsole
{
   public class Gate
    {
        private bool _isGateOpen = false;


        public bool IsGateOpen()
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
