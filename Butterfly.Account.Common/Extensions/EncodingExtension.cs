using System.Text;
using Microsoft.AspNetCore.WebUtilities;

namespace Butterfly.Account.Common.Extensions;

public static class EncodingExtension
{
    public static string Encode(this string value, Encoding encoding)
    {
        var bytes = encoding.GetBytes(value);

        return WebEncoders.Base64UrlEncode(bytes);
    }
}