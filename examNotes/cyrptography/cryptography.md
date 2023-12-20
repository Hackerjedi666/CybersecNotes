# Cryptography

Let’s review some terminology:

- **Cryptographic Algorithm or Cipher**: This algorithm defines the encryption and decryption processes.
- **Key**: The cryptographic algorithm needs a key to convert the plaintext into ciphertext and vice versa.
- Plaintext is the original message that we want to encrypt
- Ciphertext is the message in its encrypted form

## Symmetric cryptogrpahy

A symmetric encryption algorithm uses the same key for encryption and decryption. Consequently, the communicating parties need to agree on a secret key before being able to exchange any messages.

The sender provides the encrypt process with the plaintext and the key to get the ciphertext. The ciphertext is usually sent over some communication channel.
On the other end, the recipient provides the decrypt process with the same key used by the sender to recover the original plaintext from the received ciphertext. Without knowledge of the key, the recipient won’t be able to recover the plaintext.


National Institute of Standard and Technology (NIST) published the Data Encryption Standard (DES) in 1977. DES is a symmetric encryption algorithm that uses a key size of 56 bits

NIST published the Advanced Encryption Standard (AES) in 2001. Like DES, it is a symmetric encryption algorithm; however, it uses a key size of 128, 192, or 256 bits, and it is still considered secure and in use today.

## Diffie-Hellman

It is an asymmetric encryption algorithm. It allows the exchange of a secret over a public channel. We will skip the modular arithmetic background and provide a simple numeric example. We will need two mathematical operations: power and modulus. xp, i.e., x raised to the power p, is x multiplied by itself p times. Furthermore, x mod m, i.e., x modulus m, is the remainder of the division of x by m.
