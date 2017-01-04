#SignatureToDetour

Example:

Given a signature like the following from IDA Pro: 

```cpp
char __cdecl sub_1193D40(int a1, unsigned int a2, signed int *a3, _BYTE **a4, const char *a5)
```

SignatureToDetour will output ("InternalFunction" being the user supplied desired name):

```cpp
#define INTERNALFUNCTION_ADDRESS 0x1193D40
char(__cdecl* originalInternalFunction)(int, unsigned int, signed int *, BYTE **, const char *);
char hkInternalFunction(int a1,  unsigned int a2,  signed int *a3,  BYTE **a4,  const char *a5)
{
    return originalInternalFunction(a1, a2, a3, a4, a5);
}

originalInternalFunction = (char(__cdecl*)(int, unsigned int, signed int *, BYTE **, const char *))DetourFunction((PBYTE)INTERNALFUNCTION_ADDRESS, (PBYTE)hkInternalFunction);
```