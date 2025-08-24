using System.ComponentModel.DataAnnotations;

namespace AccountSystem.Attributes;

public class AgeRangeAttribute : ValidationAttribute
{
    private readonly int _minAge;
    private readonly int _maxAge;

    public AgeRangeAttribute(int minAge, int maxAge)
    {
        _minAge = minAge;
        _maxAge = maxAge;
        ErrorMessage = $"Age must be between {_minAge} and {_maxAge} years.";
    }

    public override bool IsValid(object? value)
    {
        if (value is DateTime birthDate)
        {
            var today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age))
            {
                age--;
            }

            return age >= _minAge && age <= _maxAge;
        }
        return false;
    }
}
