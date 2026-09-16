using System.Diagnostics;

namespace Utils;

/// <summary>
/// Provides helper method for opening links in browser.
/// </summary>
public static class Browser
{
    /// <summary>
    /// Opens link in default browser.
    /// </summary>
    /// <param name="uri">Link to open.</param>
    public static void Open(string uri)
    {
        if (string.IsNullOrWhiteSpace(uri))
            throw new ArgumentException("URI cannot be null or empty.", nameof(uri));

        if (!Uri.TryCreate(uri, UriKind.Absolute, out var uriResult) ||
            !(uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            throw new ArgumentException("URI must be a valid HTTP or HTTPS URL.", nameof(uri));

        Process.Start(new ProcessStartInfo(uri) { UseShellExecute = true });
    }
}

