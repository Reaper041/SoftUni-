namespace TravelAgency.Shared
{
    public static class GlobalConstants
    {
        //Customer

        public const int CustomerFullNameMinLength = 4;
        public const int CustomenFullNameMaxLength = 60;
        public const int CustomerEmailMinLength = 6;
        public const int CustomerEmailMaxLength = 50;

        public const string CustomerPhoneRegEx = @"^\+\d{12}$";

        //Guide

        public const int GuideFullNameMinLength = 4;
        public const int GuideFullNameMaxLength = 60;

        //TourPackage

        public const int PackageNameMinLength = 2;
        public const int PackageNameMaxLength = 40;
        public const int TourPackageDescriptionMaxLength = 200;
    }
}
