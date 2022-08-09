//Could not include  c >= 'A' && c <= 'Z' as well, because z == Z (case insensitive equality)
private bool IsValidChar(char c) => c >= '0' && c <= '9' || c >= 'a' && c <= 'z';