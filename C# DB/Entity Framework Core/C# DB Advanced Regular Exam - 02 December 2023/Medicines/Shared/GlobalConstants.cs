namespace Medicines.GlobalConstants
{
    public static class GlobalConstants
    {
        //Pharmacy

        public const int PharmacyNameMinLength = 2;
        public const int PharmacyNameMaxLength = 50;

        public const int PharmacyPhoneMaxLength = 14;
        public const string PharmacyPhoneNumberRegEx = @"\(\d{3}\) \d{3}-\d{4}";


        //Medicine
        public const int MedicineNameMinLength = 3;
        public const int MedicineNameMaxLength = 150;
        public const double MedicinePriceMinValue = 0.01;
        public const double MedicinePriceMaxValue = 1000;
        public const int MedicineProducerMinLength = 3;
        public const int MedicineProducenMaxLength = 100;

        //Patient

        public const int PatientFullNameMinLength = 5;
        public const int PatientFullNameMaxLength = 100;

    }
}
