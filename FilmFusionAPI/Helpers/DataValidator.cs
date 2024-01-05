public class DataValidator : IDataValidator
{
    public void ValidateNotEmpty<T>(IEnumerable<T> items, string operation)
    {
        if (!items.Any())
        {
            throw new InvalidOperationException($"Cannot {operation} with an empty collection.");
        }
    }

    public void ValidateSufficientItems<T>(IEnumerable<T> items, int requiredCount, string operation)
    {
        if (items.Count() < requiredCount)
        {
            throw new InvalidOperationException($"Cannot {operation} with a collection having less than {requiredCount} items.");
        }
    }
}