using Hydro;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;

namespace Host.Pages.Home.Components;

public class PasswordGenerator : HydroComponent
{
    public string LastGeneratedPassword { get; set; } = string.Empty;
    public List<string> AllPasswords { get; set; } = [];
    public string Toast { get; set; } = null;

    [Transient]
    public Guid? NewId { get; set; }

    public PasswordGenerator()
    {
        
    }

    public void Close() => Toast = null;


    public void Generate()
    {
        LastGeneratedPassword = GenerateSecurePassword(50);
        AllPasswords.Add(LastGeneratedPassword);
        Toast = "Password generated: " + LastGeneratedPassword;
    }

    public void Remove()
    {
        if (!AllPasswords.Any())
        {
            return;
        }
        AllPasswords.RemoveAt(AllPasswords.Count - 1);
    }


    private string GenerateSecurePassword(int length)
    {
        const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        var res = new StringBuilder();
        using (var rng = RandomNumberGenerator.Create())
        {
            byte[] uintBuffer = new byte[sizeof(uint)];

            while (length-- > 0)
            {
                rng.GetBytes(uintBuffer);
                uint num = BitConverter.ToUInt32(uintBuffer, 0);
                res.Append(validChars[(int)(num % (uint)validChars.Length)]);
            }
        }
        return res.ToString();
    }
}
