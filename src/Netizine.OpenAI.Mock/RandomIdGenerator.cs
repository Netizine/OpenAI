using System;
using System.Text;

namespace OpenAI.Mock;
public static class RandomIdGenerator
{
    public static string GenerateRandomId(string idPrefix)
    {
        //Basically just trying to generate a string that matched OpenAI's id
        var uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        var numbers = "0123456789";
        var random = new Random();

        StringBuilder finalString = new StringBuilder();
        finalString.Append(lowercaseChars[random.Next(lowercaseChars.Length)]);
        finalString.Append(lowercaseChars[random.Next(lowercaseChars.Length)]);
        finalString.Append(lowercaseChars[random.Next(lowercaseChars.Length)]);
        finalString.Append(lowercaseChars[random.Next(lowercaseChars.Length)]);
        finalString.Append(lowercaseChars[random.Next(lowercaseChars.Length)]);
        finalString.Append(uppercaseChars[random.Next(uppercaseChars.Length)]);
        finalString.Append(lowercaseChars[random.Next(lowercaseChars.Length)]);
        finalString.Append(uppercaseChars[random.Next(uppercaseChars.Length)]);
        finalString.Append(uppercaseChars[random.Next(uppercaseChars.Length)]);
        finalString.Append(numbers[random.Next(numbers.Length)]);
        finalString.Append(lowercaseChars[random.Next(lowercaseChars.Length)]);
        finalString.Append(uppercaseChars[random.Next(uppercaseChars.Length)]);
        finalString.Append(uppercaseChars[random.Next(uppercaseChars.Length)]);
        finalString.Append(lowercaseChars[random.Next(lowercaseChars.Length)]);
        finalString.Append(uppercaseChars[random.Next(uppercaseChars.Length)]);
        finalString.Append(uppercaseChars[random.Next(uppercaseChars.Length)]);
        finalString.Append(uppercaseChars[random.Next(uppercaseChars.Length)]);
        finalString.Append(numbers[random.Next(numbers.Length)]);
        finalString.Append(lowercaseChars[random.Next(lowercaseChars.Length)]);
        finalString.Append(uppercaseChars[random.Next(uppercaseChars.Length)]);
        finalString.Append(lowercaseChars[random.Next(lowercaseChars.Length)]);
        finalString.Append(uppercaseChars[random.Next(uppercaseChars.Length)]);
        finalString.Append(lowercaseChars[random.Next(lowercaseChars.Length)]);
        finalString.Append(numbers[random.Next(numbers.Length)]);

        return idPrefix + finalString.ToString();
    }
}
