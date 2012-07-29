using System;

// http://oak.ucc.nau.edu/del/stockcalcs/sizer.aspx

namespace StaticPositionSizeCalculator.WP
{
    public class StaticPositionSize
    {
        private decimal _maximumCost;
        private bool _riskIsPercent;
        private decimal _riskAmount;
        private decimal _buySellPrice;
        private PositionType _positionType;

        public enum PositionType
        {
            Long,
            Short
        }

        public StaticPositionSize(decimal maximumCost, bool riskIsPercent, decimal riskAmount, decimal buySellPrice, PositionType positionType)
        {
            _maximumCost = maximumCost;
            _riskIsPercent = riskIsPercent;
            _riskAmount = riskAmount;
            _buySellPrice = buySellPrice;
            _positionType = positionType;

        }

        public decimal CalculateStopPrice()
        {
            if(_riskIsPercent)
            {
                _riskAmount = ConvertRiskPercentToRiskAmount(_riskAmount, _maximumCost);
            }
            switch (_positionType)
            {
                case PositionType.Short:
                    return (_maximumCost + _riskAmount) / CalculateSharesToBuySell();
                // case PositionType.Long:
                default:
                    return (_maximumCost - _riskAmount) / CalculateSharesToBuySell();
            }
        }

        public int CalculateSharesToBuySell()
        {
            return RoundDown(_maximumCost / _buySellPrice);
        }

        private int RoundDown(decimal number)
        {
            double doubleNumber = Convert.ToDouble(number);
            return Convert.ToInt32(Math.Floor(doubleNumber * Math.Pow(10, 0)) / Math.Pow(10, 0));
        }

        private decimal ConvertRiskPercentToRiskAmount(decimal percent, decimal total)
        {
            return total * (percent / 100);
        }
    }
}
