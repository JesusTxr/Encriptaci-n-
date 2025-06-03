namespace CesarApi.Services
{
    public class CipherService
    {
        public string ProcessMessage(string message, int shift, bool decrypt)
        {
            if (string.IsNullOrEmpty(message))
                return string.Empty;

            // Si es desencriptación, invertimos el shift
            if (decrypt)
                shift = -shift;

            return new string(message.Select(c => TransformChar(c, shift)).ToArray());
        }

        private char TransformChar(char c, int shift)
        {
            // Solo transformamos letras
            if (!char.IsLetter(c))
                return c;

            // Determinamos el offset base (a=0, A=0)
            int offset = char.IsUpper(c) ? 'A' : 'a';
            
            // Aplicamos el shift y nos aseguramos de que esté en el rango 0-25
            int position = (c - offset + shift) % 26;
            
            // Ajustamos para números negativos
            if (position < 0)
                position += 26;

            // Convertimos de vuelta a char
            return (char)(position + offset);
        }
    }
} 