using System.Text.RegularExpressions;

namespace Domain.ValueObjects;

public partial record PhoneNumber
{
    // private const int DefaultLenght = 9;
    private const string Pattern = @"^(?:-*\d-*){8}$";
    public string Value { get; init; }
    private PhoneNumber(string value) => Value = value;
    
    [GeneratedRegex(Pattern)]
    private static partial Regex PhoneNumberRegex();

    public static PhoneNumber? Create(string value)
    {
        if(string.IsNullOrEmpty(value) || !PhoneNumberRegex().IsMatch(value))
            return null;

        return new PhoneNumber(value);
    }
}
