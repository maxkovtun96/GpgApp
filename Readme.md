### GpgApp description

This is a web .NET application for the decryption of GNU Privacy Guard (GnuPG, GPG) encrypted data.
Used for data encrypted with symmetric encryption algorithms.
Tests succeed in the Docker container only.

### To test service locally
Run the commands in ./app folder:
    
    docker build -t IMAGE_NAME .
    docker run -d -p 49567:80 IMAGE_NAME

Create HTTP POST (http://localhost:49567/decryptMessage) request with body:

    {
        "passphrase": "topsecret",
        "message": "-----BEGIN PGP MESSAGE-----\nVersion: GnuPG v2\njA0ECQMCVady3RUyJw3X0kcBF+zdkfZOMhISoYBRwR3uk3vNv+TEg+rJnp4/yYISpEoI2S82cDiCNBIVAYWB8WKPtH2R2YSussKhpSJ4mFgqyOA01uwroA==\n=KvJQ\n-----END PGP MESSAGE-----"
    }

### To run unit tests

Open the terminal in ./app folder and execute the following command:

    docker build -t IMAGE_NAME -f Dockerfile.Tests .


