using System.Text;
using Microsoft.AspNetCore.WebUtilities;

namespace Butterfly.Account.Common.Extensions;

public static class DecodeExtension
{
    public static string Decode(this string value, Encoding encoding)
    {
        var bytes = WebEncoders.Base64UrlDecode(value);

        return encoding.GetString(bytes);
    }
}