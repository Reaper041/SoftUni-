﻿namespace DeskMarket.Common
{
    public static class ValidationConstants
    {
        public const int ProductNameMinLength = 2;
        public const int ProductNameMaxLength = 60;
        public const int DescriptionMinLength = 10;
        public const int DescriptionMaxLength = 250;
        public const string PriceMinValue = "1.00";
        public const string PriceMaxValue = "3000.00";
        public const string DateTimeFormat = "dd-MM-yyyy";
        public const int CategoryNameMinLength = 3;
        public const int CategoryNameMaxLength = 20;

    }
}
