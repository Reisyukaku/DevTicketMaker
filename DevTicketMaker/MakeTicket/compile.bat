@echo off
echo Building MakeTicket
gcc -c -DBUILD_DLL src\MakeTicket_dll.c
gcc -shared -o MakeTicket.dll -Wl,--out-implib,libtstdll.a MakeTicket_dll.o
echo Done!
rm *.o
pause