#ifdef BUILD_DLL
// the dll exports
#define EXPORT __declspec(dllexport)
#else
// the exe imports
#define EXPORT __declspec(dllimport)
#endif

typedef unsigned char byte;
typedef unsigned short u16;

typedef struct{
    byte issuer[0x40];
    byte eccPubKey[0x3C];
    byte version;
    byte CaCrlVersion;
    byte SigCrlVersion;
    byte titleKey[0x10];
    byte reserved;
    byte ticketID[8];
    byte consoleID[4];
    byte titleID[8];
    byte reserved2[2];
    u16 tikTitleVersion;
    byte reserved3[8];
    byte licType;
    byte commKeyIndex;
    byte reserved4[0x2A];
    byte accntID[4];
    byte reserved5;
    byte audit;
    byte reserved6[0x42];
    byte limits[0x40];
    byte contIndex[0xAC];
} TikData;

typedef struct{
    byte signature[0x140];
    TikData ticketData;
} Cetk;

// function to be imported/exported
EXPORT unsigned char *BuiltTicketData(const byte *titleID, const byte *tikID, const byte *encKey, const byte *eccPubKey, const u16 version, const byte *contIndex);
EXPORT unsigned BuildCetk(const char *fileOut, const byte *tikData, const byte *sig, const byte *chainSig);