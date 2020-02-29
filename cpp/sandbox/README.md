# RUN C++ IN VSCODE ON MAC

## How to run?

run the execute file directly like below:

```
./hello
```

## How to debug?

1. Setup tasks.json and launch.json as this [link](https://medium.com/gdplabs/build-and-debug-c-on-visual-studio-code-for-mac-77e05537105e)

2. Press F5

## Troubleshooting

1) Cannot stop on breakpoint when debugging! 

    a) Check `DEBUG CONSOLE` bar. If it has error message `Warning: Debuggee TargetArchitecture not detected, assuming x86_64`, then try to run `xcode-select --install` in terminal (if haven't install xcode, install it firstly).

    b) Also see [VSCode, MacOS Catalina - doesn't stop on breakpoints on C/C++ debug](https://stackoverflow.com/questions/58329611/vscode-macos-catalina-doesnt-stop-on-breakpoints-on-c-c-debug), which point to a known issue when upgrading to macOS Catalina.  See [Can't debug on macOS Catalina (LLDB)](https://github.com/microsoft/vscode-cpptools/issues/3829).  Recommand to i) install `CodeLLDB` extension in VSCode; ii) change the `launch.json` file according to this [README](https://github.com/vadimcn/vscode-lldb).

2) `PROBLEMS` bar has 2 errors, one says `#include errors detected`!

    Follow [Using Clang in Visual Studio Code](https://code.visualstudio.com/docs/cpp/config-clang-mac) to add `c_cpp_properties.json` file, which specify the `compilerPath` and `includePath`.