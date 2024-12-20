namespace SeedWork.Domain.ExceptionValidation;

public static class Check
{
    public static void IsNotNull<TException>(Object? obj) where TException : Exception
    {
        if (obj is null)
        {
            var ex = Activator.CreateInstance(typeof(TException), obj) as Exception;
            throw ex ?? new NullReferenceException($"Object should not be null");
        }
    }

    public static void IsNotNull<TException>(object? obj, string message) where TException : Exception
    {
        if (obj is null)
        {
            var ex = Activator.CreateInstance(typeof(TException), message) as Exception;
            throw ex ?? new NullReferenceException(message);
        }
    }

    public static void That<TException>(bool condition, string message = "") where TException : Exception
    {
        if (!condition)
        {
            var ex = Activator.CreateInstance(typeof(TException), message) as Exception;
            throw ex ?? new NullReferenceException(message);
        }
    }

    public static void That<TException>(bool condition, Func<TException> configureException) where TException : Exception
    {
        if (!condition)
            throw configureException();
    }

    public static bool IsNull<TException>(object? obj) where TException : Exception
    {
        return (obj is null);
    }
}
