using IvalidDataException = RestaurantApp.Domain.Common.Exceptions.InvalidDataException;

namespace RestaurantApp.Domain.Utils
{
    public class Guard
    {
        public static GuardClause<T> Is<T>(T value, string paramName)
        {
            return new GuardClause<T>(value, paramName);
        }
    }

    public class GuardClause<T>
    {
        private T _value;
        private string _paramName;

        public GuardClause(T value, string paramName)
        {
            _value = value;
            _paramName = paramName;
        }

        public GuardClause<T> NotNullOrWhitespace()
        {
            if (_value is not string value)
                throw new InvalidDataException($"{_paramName} is not string");

            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidDataException($"{_paramName} should be not empty");

            return this;
        }

        public GuardClause<T> LengthLessThan(int length)
        {
            if (_value is not string value)
                throw new InvalidDataException($"{_paramName} is not string");

            if (value.Length > length)
                throw new InvalidDataException($"{_paramName} should contain less than {length} symbols");

            return this;
        }

        public GuardClause<T> NotNull()
        {
            if (_value is null)
            {
                throw new IvalidDataException($"{_paramName} shouldn't be null");
            }

            return this;
        }

        public GuardClause<T> NotNullOrEmpty()
        {
            NotNull();

            if (_value is not Array array)
            {
                throw new IvalidDataException($"{_paramName} is not array");
            }

            if(array.Length == 0)
            {
                throw new IvalidDataException($"{_paramName} should not be empty");
            }

            return this;
        }

        public GuardClause<T> IsEnumOf<R>()
            where R : Enum
        {
            if(_value == null)
            {
                throw new IvalidDataException($"{_paramName} shouldn't be null");
            }

            if (!typeof(R).IsEnum)
            {
                throw new IvalidDataException($"Type to comparison should be enum");
            }

            var type = _value.GetType();

            if (!type.IsEnum)
            {
                throw new IvalidDataException($"{_paramName} should be enum");
            }

            if(type != typeof(R))
            {
                throw new IvalidDataException($"{_paramName} should be enum of type {typeof(R).Name}");
            }

            return this;
        }

        public GuardClause<T> MoreThan(T value)
        {
            var result = Comparer<T>.Default.Compare(_value, value);
            
            if(result == 0 || result == -1)
            {
                throw new IvalidDataException($"{_paramName} should be more than {value}");
            }

            return this;
        }
    }
}
