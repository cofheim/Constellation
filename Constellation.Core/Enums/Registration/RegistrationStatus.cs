namespace Constellation.Core.Enums.Registration
{
    public enum RegistrationStatus
    {
        Pending, // запрос на подтверждение регистрации 
        Confirmed, // регистрация подтверждена
        Attended, // произошла попытка регистрации
        Cancelled, // регистрация отменена
    }
}
