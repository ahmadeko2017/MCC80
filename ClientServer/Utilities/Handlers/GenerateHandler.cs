﻿namespace ClientServer.Utilities.Handlers;

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

    public static int OTP(int length)
    {
        const string chars = "0123456789"; // Characters to be used in the OTP
        Random random = new Random();
        var generatedOTP = new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        return int.Parse(generatedOTP);
    }
}