using System.Text;

namespace StringCompressionTask
{
    public class StringCompressor
    {
      
        public static string Compress(string inputText)
        {
            if (string.IsNullOrEmpty(inputText))
                return inputText;

            StringBuilder compressed = new();
            int count = 1;

            for (int i = 1; i < inputText.Length; i++)
            {
                if (inputText[i] == inputText[i - 1])
                {
                    count++;
                }
                else
                {
                    compressed.Append(inputText[i - 1]);
                    if (count > 1)
                        compressed.Append(count);
                    count = 1;
                }
            }

            compressed.Append(inputText[inputText.Length - 1]);
            if (count > 1)
                compressed.Append(count);

            return compressed.ToString();
        }

        
        public static string Decompress(string compressed)
        {
            if (string.IsNullOrEmpty(compressed))
                return compressed;

            StringBuilder decompressed = new();

            for (int i = 0; i < compressed.Length; i++)
            {
                char currentChar = compressed[i];
                decompressed.Append(currentChar);

                StringBuilder number = new();
                int j = i + 1;
                while (j < compressed.Length && char.IsDigit(compressed[j]))
                {
                    number.Append(compressed[j]);
                    j++;
                }

                if (number.Length > 0)
                {
                    int count = int.Parse(number.ToString());
                    for (int k = 1; k < count; k++)
                    {
                        decompressed.Append(currentChar);
                    }
                    i = j - 1;
                }
            }

            return decompressed.ToString();
        }
    }
}