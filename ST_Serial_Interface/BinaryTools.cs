using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST_Serial_Interface
{
    internal class BinaryTools
    {
        public static bool IsBinaryData(byte[] data)
        {
            foreach (byte b in data)
            {
                // Check for valid ASCII range (0-127)
                if (b < 0x20 && b != 0x09 && b != 0x0A && b != 0x0D) // 0x09: Tab, 0x0A: New Line, 0x0D: Carriage Return
                {
                    return true;
                }

                // Check for valid UTF-8 encoding (skip this if you just want to consider ASCII)
                if (b >= 0x80) // Start of multi-byte UTF-8 characters
                {
                    // If it reaches here, it means it's not ASCII
                    return !IsValidUtf8(data); // Check for valid UTF-8 encoding
                }
            }
            return false; // All characters are either ASCII or valid UTF-8
        }

        private static bool IsValidUtf8(byte[] data)
        {
            int i = 0;
            while (i < data.Length)
            {
                // Check for single-byte (ASCII) characters (0xxxxxxx)
                if ((data[i] & 0x80) == 0)
                {
                    i++; // ASCII character, move to next byte
                }
                // Check for valid 2-byte sequence (110xxxxx 10xxxxxx)
                else if ((data[i] & 0xE0) == 0xC0)
                {
                    if (i + 1 < data.Length && (data[i + 1] & 0xC0) == 0x80)
                    {
                        i += 2; // Valid 2-byte UTF-8 character
                    }
                    else
                    {
                        return false; // Invalid UTF-8 sequence
                    }
                }
                // Check for valid 3-byte sequence (1110xxxx 10xxxxxx 10xxxxxx)
                else if ((data[i] & 0xF0) == 0xE0)
                {
                    if (i + 2 < data.Length &&
                        (data[i + 1] & 0xC0) == 0x80 &&
                        (data[i + 2] & 0xC0) == 0x80)
                    {
                        i += 3; // Valid 3-byte UTF-8 character
                    }
                    else
                    {
                        return false; // Invalid UTF-8 sequence
                    }
                }
                // Check for valid 4-byte sequence (11110xxx 10xxxxxx 10xxxxxx 10xxxxxx)
                else if ((data[i] & 0xF8) == 0xF0)
                {
                    if (i + 3 < data.Length &&
                        (data[i + 1] & 0xC0) == 0x80 &&
                        (data[i + 2] & 0xC0) == 0x80 &&
                        (data[i + 3] & 0xC0) == 0x80)
                    {
                        i += 4; // Valid 4-byte UTF-8 character
                    }
                    else
                    {
                        return false; // Invalid UTF-8 sequence
                    }
                }
                else
                {
                    return false; // Invalid byte for UTF-8
                }
            }

            return true; // All valid UTF-8 characters
        }
    }
}
