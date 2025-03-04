﻿using System.Text.RegularExpressions;

namespace Desktop.Services.Classes;

public static class RegexCollection
{
    private readonly static string EmailPattern = "^[a-zA-Z0-9 -~]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";
    private readonly static string NamePattern = @"^[A-Z][a-z]+$";
    private readonly static string SurnamePattern = @"^[A-Z][a-z]+$";
    private readonly static string PasswordPattern = @"^([0-9]{1,}[ -~]{1,}[a-zA-Z]){8,}$";
    private readonly static string TimePattern = @"(0[1-9]|1[0-9]|2[0-9]|3[0-1])\.(0[1-9]|1[0-2])\.(0\d{3}|1\d{3}|200[0-9]|201[0-9]|202[0-4])";
    private readonly static string ProductNamePattern = @"^[0-9a-zA-Z -~]+$";
    private readonly static string MoneyPattern = @"^\d+(\.\d{2})?$";


    public static Regex EmailRegex = new(EmailPattern);
    public static Regex NameRegex = new(NamePattern);
    public static Regex SurnameRegex = new(SurnamePattern);
    public static Regex PasswordRegex = new(PasswordPattern);
    public static Regex TimeRegex = new(TimePattern);
    public static Regex ProductNameRegex = new(ProductNamePattern);
    public static Regex MoneyRegex = new(MoneyPattern);
}
