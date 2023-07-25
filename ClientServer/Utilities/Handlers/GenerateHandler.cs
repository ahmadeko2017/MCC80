namespace ClientServer.Utilities.Handlers;

public class GenerateHandler
{
    public static string NIK(string nik)
    {
        if (nik is null)
        {
            return "111111";
        }
        else
        {
            return (int.Parse(nik) + 1).ToString();
        }
    }
}