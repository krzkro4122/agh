REM Dopasuj poniższe ścieżki:
set MINGW_PATH=C:\Program Files\mingw-w64\x86_64-8.1.0-posix-seh-rt_v6-rev0\mingw64\bin
set CMAKE_PATH=C:\Program Files\CMake\bin


set PATH=%PATH%;%MINGW_PATH%;%CMAKE_PATH%;

cmake -G "MinGW Makefiles" -B build
mingw32-make.exe -C build

cmd /k