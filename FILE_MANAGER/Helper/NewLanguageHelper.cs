using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FILE_MANAGER.Helper
{
	public static class NewLanguageHelper
	{
        public static string HashPaymentSocialAccountName(this string accountName, bool allowSpecialChar = false)
        {
            if (string.IsNullOrWhiteSpace(accountName))
                return null;

            var isLong = accountName.Length >= 10;
            if (accountName.Contains("@") && !allowSpecialChar)
            {

                var pattern = isLong ? @"(?<=[\w]{3})[\w-\._\+%]*(?=[\w]{4}@)" : @"(?<=[\w]{1})[\w-\._\+%]*(?=[\w]{1}@)";
                return Regex.Replace(accountName, pattern, m => new string('*', m.Length));
            }
            //long display first 3 and last 4 chars
            return isLong ? accountName.Mask(3, accountName.Length - (4 + 3)) : accountName.Mask(1, accountName.Length - 2);
        }
        public static string Mask(this string source, int start, int maskLength)
        {
            return source.Mask(start, maskLength, '*');
        }
        public static string Mask(this string source, int start, int maskLength, char maskCharacter)
        {
            if (start > source.Length - 1)
                return null;

            if (maskLength > source.Length)
                return null;

            if (start + maskLength > source.Length)
                return null;

            var mask = new string(maskCharacter, maskLength);
            var unMaskStart = source.Substring(0, start);
            var unMaskEnd = source.Substring(start + maskLength);

            return unMaskStart + mask + unMaskEnd;
        }
    }
}
