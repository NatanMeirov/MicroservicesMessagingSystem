namespace MessageConsumerService.Repository
{
    public class StaticSubstitutionDecryptor : IDecryptor
    {

        private readonly string alphabet = "}{/abcde1f:gh2ijk3!lm'n4opq,5rst6u@vw7-xyz8ABC9DEFG HIJKLM.N0OPQRSTU?VWXYZ";
        private readonly string key = "X9Z.N3L-WEBGJHQ8D1YV TK5'FUOM?PCAISRr2s7iacp:mo0ufktv!ydq4hj@gb,ewln6zk}{/";

        public string DecryptMessage(string msg)
        {

            string decryptedMessage = string.Empty;
            int tempIndex = 0;

            foreach (var character in msg)
            {
                tempIndex = key.IndexOf(character);

                if (tempIndex != -1) // The character was found
                {
                    decryptedMessage += alphabet[tempIndex];
                }
                else
                {
                    decryptedMessage += character; // Itself
                }
            }

            return decryptedMessage;

        }
    }
}
