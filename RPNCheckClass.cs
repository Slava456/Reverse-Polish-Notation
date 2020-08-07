namespace RPNLib
{
    public class RPNCheckClass
    {
        private RPNCountClass _countClass;
        
        public RPNCheckClass(RPNCountClass countClass)
        {
            _countClass = countClass;
        }

        public double CheckInput(out string messWithError)
        {
            string errorSymbol = string.Empty;
            bool res = true;
            for (int i = 0; i < _countClass._input.Length; i++)
            {
                if (!_countClass.isDelimeter(_countClass._input[i]) && !_countClass.isOperator(_countClass._input[i])
                    && !_countClass.isOpenBreaker(_countClass._input[i]) && !_countClass.isClosedBreaker(_countClass._input[i])
                    && !char.IsDigit(_countClass._input[i]))
                {
                    res = false;
                    errorSymbol += _countClass._input[i];
                    errorSymbol += " ";
                }
            }
            if (!res)
            {
                messWithError = "Выражение содержит ошибки: " + errorSymbol;
                return 0;
            }
            else
            {
                messWithError = string.Empty;
                return _countClass.Calculate();
            }
        }
    }
}
