namespace ClashRoyale.Crypto
{
    using System.Collections.Generic;

    using ClashRoyale.Crypto.Nacl;

    public static class PepperFactory
    {
        /// <summary>
        /// Gets the latest supercell server public key for the <see cref="PepperCrypto"/>.
        /// </summary>
        public static byte[] PublicKey
        {
            get
            {
                return PepperFactory.PublicKeys[15];
            }
        }

        /// <summary>
        /// Gets the latest private server secret key for the <see cref="PepperCrypto"/>,
        /// and generates a public key with it.
        /// </summary>
        public static byte[] ModdedPublicKey
        {
            get
            {
                byte[] k = new byte[32];
                Curve25519Xsalsa20Poly1305.CryptoBoxGetpublickey(k, PepperFactory.SecretKeys[14]);
                return k;
            }
        }

        public static readonly Dictionary<int, byte[]> SecretKeys = new Dictionary<int, byte[]>
        {
            {
                14, new byte[]
                {
                    0x98, 0x0C, 0xF7, 0xBB, 0x72, 0x62, 0xB3, 0x86, 0xFE, 0xA6, 0x10, 0x34, 0xAB, 0xA7, 0x37, 0x06,
                    0x13, 0x62, 0x79, 0x19, 0x66, 0x6B, 0x34, 0xE6, 0xEC, 0xF6, 0x63, 0x07, 0xA3, 0x81, 0xDD, 0x61
                }
            }
        };

        public static readonly Dictionary<int, byte[]> PublicKeys = new Dictionary<int, byte[]>
        {
            {
                15, new byte[]
                {
                    0x99, 0xb6, 0x18, 0x76, 0xf3, 0xff, 0x18, 0xca, 0xec, 0xa0, 0xae, 0xc1, 0xf3, 0x26, 0xd9, 0x98,
                    0x1b, 0xbc, 0xaf, 0x64, 0xe7, 0xda, 0xa3, 0x17, 0xa7, 0xf1, 0x09, 0x66, 0x86, 0x7a, 0xf9, 0x68
                }
            }
        };
    }
}