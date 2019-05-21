namespace Logic_Layer.PassWordGenerator
{
    public interface IPasswordGenerator
    {
        string GeneratePassword(bool includelower, bool includeupper, bool includenumeric, bool includespecial, bool includespaces, int length);
    }
}