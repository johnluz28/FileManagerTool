using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace FILE_MANAGER.Helper
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void NullCheck(this object obj, string message)
        {
            if (obj == null)
                throw new ArgumentNullException(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentException"></exception>
        public static void TypeCheck<T>(this object obj, string message)
        {
            if (obj.GetType() != typeof(T))
                throw new ArgumentException(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToStringSafe(this object obj)
        {
            return obj == null ? string.Empty : obj.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ToDateTimeSafe(this object obj)
        {
            DateTime tryParseDate;
            DateTime.TryParse(obj.ToStringSafe(), CultureInfo.InvariantCulture, DateTimeStyles.None, out tryParseDate);
            return tryParseDate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime FromOaDateSafe(this object obj)
        {
            var oleDateTime = obj.ToDoubleSafe();

            if (oleDateTime <= 0)
            {
                return DateTime.MinValue;
            }

            // Get the converted date from the OLE automation date.
            var tryParseDate = DateTime.FromOADate(oleDateTime);

            return tryParseDate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double ToDoubleSafe(this object obj)
        {
            double tryParseVal;
            double.TryParse(obj.ToStringSafe(), out tryParseVal);
            return tryParseVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ToDecimalSafe(this object obj)
        {
            decimal tryParseVal;
            decimal.TryParse(obj.ToStringSafe(), out tryParseVal);
            return tryParseVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long ToLongSafe(this object obj)
        {
            long tryParseVal;
            long.TryParse(obj.ToStringSafe(), out tryParseVal);
            return tryParseVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToIntSafe(this object obj)
        {
            int tryParseVal;
            int.TryParse(obj.ToStringSafe(), out tryParseVal);
            return tryParseVal;
        }

        public static int ToIntSafe(this object obj, int defaultValue)
        {
            int tryParseVal;
            int.TryParse(obj.ToStringSafe(), out tryParseVal);
            return tryParseVal == 0 ? defaultValue : tryParseVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToInt16Safe(this object obj)
        {
            short tryParseVal;
            short.TryParse(obj.ToStringSafe(), out tryParseVal);
            return tryParseVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ToBoolSafe(this object obj)
        {
            bool tryParseVal;
            bool.TryParse(obj.ToStringSafe(), out tryParseVal);
            return tryParseVal;
        }

        public static Guid ToGuidSafe(this object obj)
        {
            Guid tryParseVal;
            Guid.TryParse(obj.ToStringSafe(), out tryParseVal);
            return tryParseVal;
        }

        public static bool IsValidateJson(string s, out JToken jToken)
        {
            try
            {
                jToken = JToken.Parse(s);
                return true;
            }
            catch (Exception ex)
            {
                jToken = null;
                return false;
            }
        }

        

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            var knownKeys = new HashSet<TKey>();
            return source.Where(element => knownKeys.Add(keySelector(element)));
        }

        private static double TruncateDecimal(double value, int digits)
        {
            double mult = Math.Pow(10.0, digits);
            return Math.Truncate(value * mult) / mult;
        }
        public static double ToTruncateDecimalPlaces(this object obj)
        {
            double tryParseVal;
            double.TryParse(obj.ToStringSafe(), out tryParseVal);
            if (tryParseVal.ToString("#,0.0000#", System.Globalization.CultureInfo.InvariantCulture) == "0.0000")
                return 0.00;
            var stringVal = TruncateDecimal(tryParseVal, 2)
                .ToString("#,0.00#", System.Globalization.CultureInfo.InvariantCulture);
            return stringVal.ToDoubleSafe();
        }
        public static T TryParseJson<T>(this string json, string schema) where T : new()
        {
            var parsedSchema = JsonSchema.Parse(schema);
            var jObject = JObject.Parse(json);

            return jObject.IsValid(parsedSchema) ?
                JsonConvert.DeserializeObject<T>(json) : default(T);
        }
    }
}
