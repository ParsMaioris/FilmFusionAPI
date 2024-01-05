public interface IDataValidator
{
    void ValidateNotEmpty<T>(IEnumerable<T> items, string operation);

    void ValidateSufficientItems<T>(IEnumerable<T> items, int requiredCount, string operation);
}