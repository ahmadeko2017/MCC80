﻿using ClientServer.Utilities.Enums;

namespace ClientServer.DTOs.Accounts;

public class RegisterDto
{
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderLevel Gender { get; set; }
    public DateTime HiringDate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Major { get; set; }
    public string Degree { get; set; }
    public float GPA { get; set; }
    public string UniversityCode { get; set; }
    public string UniversityName { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}