namespace Logic_Layer.Hasher
{
    public interface IPasswordHasher
    {
        string Key { get; set; }

        string CheckPassword(string password, string salt);
        string GenerateRandomCryptographicKey(int keyLength);
        string HashWithSalt(string password);
    }
}