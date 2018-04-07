using Newtonsoft.Json;
using System.IO;

namespace PredictionGuru.Helpers
{
    public static class StringExtensions
    {
        public static string SafeValue(this string value)
        {
            if (value == null) value = string.Empty;
            return value.Trim();
        }
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
        public static bool IsEqual(this string value, string valueToCompare)
        {
            var isEqual = value.IsEqual(valueToCompare, true);

            return isEqual;
        }
        public static bool IsEqual(this string value, string valueToCompare, bool ignoreCase)
        {
            var isEqual = false;

            if (value == null && valueToCompare == null)
            {
                isEqual = true;
            }

            if (value != null && valueToCompare != null)
            {
                if (!ignoreCase) isEqual = value.Trim() == valueToCompare.Trim();
                else isEqual = value.Trim().ToLower() == valueToCompare.Trim().ToLower();
            }

            return isEqual;
        }

        public static string ReadToString(this Stream stream)
        {
            var value = string.Empty;

            if (stream.CanRead)
            {
                using (var reader = new StreamReader(stream))
                {
                    value = reader.ReadToEnd();
                }
            }

            return value;
        }

        public static T FromJson<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
