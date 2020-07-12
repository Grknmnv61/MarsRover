using System;

namespace BusinessLayer.Helpers
{
    public static class UtilityHelper
    {
        public static bool IsNumberAndBiggerThanZero(this string value)
        {
            try
            {
                return Convert.ToInt32(value) > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }


        public static bool IsNumber(this string value)
        {
            try
            {
                Convert.ToInt32(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool EnumControl<T>(this string enumValue)
        {
            var enums = Enum.GetValues(typeof(T));

            foreach (var item in enums)
            {
                if (IsNumber(item.ToString())) return false;
                else if (item.ToString() == enumValue.ToUpper()) return true;
            }

            return false;
        }
    }
}
