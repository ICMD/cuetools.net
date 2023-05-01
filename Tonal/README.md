CUETools for Tonal app.

## Interoperability

CUETools was embedded as an executable (like `sacd_extract` and `dstcnv`). I
find it easier (in terms of compiling/linking) and safer (in terms of memory
management).

## Binary Size Optimization

I tried to reduce the size of the binary. Here is the observed size of the
binary file (arm64 only).

1. Hello world without trim: 73.0 MB
2. Hello world with trim: 12.0 MB
3. Hand-picked CUESheet.cs (from 4,500 lines to 700 lines): 16.9 MB
4. Original CUESheet.cs with 4 lines modified: 17.7 MB

I feel more confident with the last option (which only increases the size by 1
MB). The final universal binary is 36 MB.
