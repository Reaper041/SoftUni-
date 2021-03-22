namespace Telephony
{
    public interface ISmartphone
    {
        void CallOtherPhone(string number, string message);

        void Browse(string website);
    }
}