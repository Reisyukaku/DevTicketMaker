/*
*   MakeTicket.dll
*       by Reisyukaku
*   Builds a cetk file.
*/

#include <stdio.h>
#include <string.h>
#include <malloc.h>

#include "MakeTicket_dll.h"

EXPORT unsigned char *BuiltTicketData(const byte *titleID, const byte *tikID, const byte *encKey, const byte *eccPubKey, const u16 version, const byte *contIndex){
    TikData data[sizeof(TikData)];
    memcpy(data->issuer, "Root-CA00000004-XS00000009", 0x1B);
    memcpy(data->eccPubKey, eccPubKey, 0x3C);
    data->version = 1;
    data->tikTitleVersion = ((version & 0xFF00) >> 8) | (version << 8);
    data->audit = 1;
    memcpy(data->contIndex, contIndex, 0xAC); //Get contindex
    memcpy(data->titleKey, encKey, 0x10);
    memcpy(data->titleID, titleID, 8);
    memcpy(data->ticketID, tikID, 8);
    data->commKeyIndex = 1;
    return data;
}

EXPORT unsigned BuildCetk(const char *fileOut, const byte *tikData, const byte *sig, const byte *chainSig){    
    //Fill out info
    Cetk *tik = calloc(1, sizeof(Cetk));
    memcpy(tik->signature, sig, 0x140);
    memcpy(&tik->ticketData, tikData, sizeof(TikData));
    
    //Write CETK
    FILE *fp;
    fp = fopen(fileOut, "wb");
    if(!fp) return 1;
    fwrite(tik, 1, sizeof(Cetk), fp);
    fwrite(chainSig, 1, 0x700, fp);
    fclose(fp);
    
    free(tik);
    
    return 0;
}