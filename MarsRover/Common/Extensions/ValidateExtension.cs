using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Common.Extensions
{
    public static class ValidateExtension
    {
        public static int ConvertInt(this string value)
        {
            int.TryParse(value, out int output);

            if (!value.IsInt())
            {
                throw new ArgumentException("Invalid input. You must enter number.");
            }

            if (!output.IsPositive())
            {
                throw new ArgumentException("Invalid input. Please positive value");
            }

            return output;
        }

        public static bool IsInt(this string value)
        {
            bool result = int.TryParse(value, out int output);

            if (!result)
            {
                result = false;
            }

            return result;
        }

        public static bool IsPositive(this int value)
        {
            bool result = true;
            if (value <= 0)
            {
                result = false;
            }

            return result;
        }

        public static TEnum GetEnum<TEnum>(this string enumValue)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), enumValue, true);
        }
        public static bool IsEnum<TEnum>(this string enumValue)
        {
            bool result = Enum.IsDefined(typeof(TEnum), enumValue);
            return result;
        }

    }
}
